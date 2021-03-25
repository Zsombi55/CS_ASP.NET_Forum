﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NC5MvcIdentitySqliteWebApp.Data
{
	public static class MigrationBuilderExtension
	{
		/// <summary>
		/// Thy to perform migration, ading a new role.
		/// If there is no Role name throw error, else try.
		/// </summary>
		/// <param name="migration">Object: contains migration data.</param>
		/// <param name="roleName">String: name of the desired User role.</param>
		/// <remarks>Best not to hardcode the SQL code, syntax differs, eg.: SQLServer != SQLite.</remarks>
		public static void AddRole(this MigrationBuilder migration, string roleName)
		{
			if (string.IsNullOrWhiteSpace(roleName))
			{
				return;
			}

			string normalizedRoleName = roleName.ToUpperInvariant();
			//migration.ActiveProvider -- check msdn
			// SQLite syntax (if there's no INT AUTOINCREMENT, the hidden ROWID is automatically used as such):
			migration.Sql($@"
				INSERT INTO AspNetRoles (Name, NormalizedName, ConcurrencyStamp)
				SELECT '{roleName}', '{normalizedRoleName}', '{Guid.NewGuid().ToString()}'
				WHERE NOT EXISTS (
					SELECT * FROM AspNetRoles WHERE NormalizedName = '{normalizedRoleName}');
			");

			// MS SQL Server syntax:
			//migration.Sql($@"
			//	IF NOT EXISTS (SELECT * FROM AspNetRoles WHERE NormalizedName = '{normalizedRoleName}')
			//	BEGIN
			//		INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
			//		VALUES (NEWID(), '{roleName}', '{normalizedRoleName}', '{Guid.NewGuid().ToString()}')
			//	END;
			//");
		}

		public static void AddUserWithRoles(this MigrationBuilder migrationBuilder,
			string email, string password, string[] roleNames)
		{
			if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{ return; }

			string normalizedEmail = email.ToUpperInvariant();
			// TODO: Add "UserName" and "normalizedUserName" too; they MUST NOT be the same as Email !!
			var identityUser = new IdentityUser
			{
				UserName = email,
				NormalizedUserName = normalizedEmail,
				Email = email,
				NormalizedEmail = normalizedEmail,
				EmailConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString(),
				ConcurrencyStamp = Guid.NewGuid().ToString(),
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnabled = false,
				AccessFailedCount = 0
			};

			var options = Microsoft.Extensions.Options.Options.Create<PasswordHasherOptions>(
				new PasswordHasherOptions
				{
					CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3,
					IterationCount = 10000
				}
			);

			var passwordHasher = new PasswordHasher<IdentityUser>(options);
			string passwordHash = passwordHasher.HashPassword(identityUser, password);

			if(passwordHasher.VerifyHashedPassword(identityUser, passwordHash, password) ==
				PasswordVerificationResult.Failed)
			{
				throw new Exception("Unable to correctly generate password hash!");
			}

			// ---IF ALL WENT WELL, BEGIN NEW USER INSERTION---
			// SQLite: No need to insert "Id": https://www.sqlitetutorial.net/sqlite-autoincrement/
			migrationBuilder.Sql($@"
				INSERT INTO AspNetUsers (UserName, NormalizedUserName, Email, NormalizedEmail, 
					EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, 
					PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
				SELECT 
					'{email}',							/* UserName */
					'{normalizedEmail}', 				/* NormailzedEmail */
					'{email}', 							/* Email */
					'{normalizedEmail}', 				/* NormailzedEmail */
					1, 									/* EmailConfirmed */
					'{passwordHash}', 					/* PasswordHash */
					'{identityUser.SecurityStamp}', 	/* SecurityStamp */
					'{identityUser.ConcurrencyStamp}', 	/* ConcurrencyStamp */
					0, 									/* PhoneNumberConfirmed */
					0, 									/* TwoFactorEnabled */
					0, 									/* LockoutEnabled */
					0, 									/* AccessFailedCount */
				WHERE NOT EXISTS (
					SELECT * FROM AspNetUsers 
					WHERE NormalizedUserName = '{normalizedEmail}' OR NormalizedEmail = '{normalizedEmail}');
			");
		}
	}
}
