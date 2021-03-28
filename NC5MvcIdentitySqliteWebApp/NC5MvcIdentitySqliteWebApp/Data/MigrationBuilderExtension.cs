using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public static void AddRole(
			this MigrationBuilder migration, 
			string roleName, 
			out Guid roleId)
		{
			roleId = Guid.NewGuid();
			if (string.IsNullOrWhiteSpace(roleName))
			{
				return;
			}

			string normalizedRoleName = roleName.ToUpperInvariant();
			
			// TODO: migration.ActiveProvider -- check msdn
			// SQLite syntax (if there's no INT AUTOINCREMENT, the hidden ROWID is auto.-used as such):
			migration.Sql($@"
				INSERT INTO AspNetRoles (Id, Name, NormalizedName, ConcurrencyStamp)
				SELECT '{roleId}', '{roleName}', '{normalizedRoleName}', '{Guid.NewGuid()}'
				WHERE NOT EXISTS (
									SELECT	* 
									FROM	AspNetRoles 
									WHERE	NormalizedName = '{normalizedRoleName}'
								 );
			");
		}

		public static void AddUser(
			this MigrationBuilder migration,
			string email, 
			string password,
			out Guid userId)
		{
			userId = Guid.NewGuid();
			if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
			{ 
				return;
			}

			string normalizedEmail = email.ToUpperInvariant();
			// TODO: UserName, UserID and Email MUST NEVER be the same, they are completely different things !!
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

			if (passwordHasher.VerifyHashedPassword(identityUser, passwordHash, password) ==
				PasswordVerificationResult.Failed)
			{
				throw new Exception("Unable to correctly generate password hash!");
			}

			migration.Sql($@"
				INSERT INTO AspNetUsers (
					Id, 
					UserName, 
					NormalizedUserName, 
					Email, 
					NormalizedEmail, 
					EmailConfirmed, 
					PasswordHash, 
					SecurityStamp, 
					ConcurrencyStamp, 
					PhoneNumberConfirmed, 
					TwoFactorEnabled, 
					LockoutEnabled, 
					AccessFailedCount)
				SELECT 
					'{userId}',							/* Id */
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
					0 									/* AccessFailedCount */
				WHERE NOT EXISTS (
									SELECT	* 
									FROM	AspNetUsers 
									WHERE	NormalizedUserName = '{normalizedEmail}' OR								   NormalizedEmail = '{normalizedEmail}'
								 );
			");
		}

		public static void MapUserRole(
			this MigrationBuilder migration,
			Guid userId,
			Guid roleId)
		{
			migration.Sql($@"
				INSERT INTO AspNetUserRoles (UserID, RoleId)
				SELECT	'{userId}', '{roleId}' 
				WHERE NOT EXISTS (
									SELECT	* 
									FROM	AspNetUserRoles
									WHERE	UserId = '{userId}' 
											AND RoleId = '{roleId}'
								 );
			");
		}

		public static void AddUserWithRoles(
			this MigrationBuilder migration,
			string email, 
			string password, 
			params Guid[] roleIds)
		{
			migration.AddUser(email, password, out Guid userId);

			// SQLite: https://www.sqlitetutorial.net/sqlite-autoincrement/

			if (roleIds != null && roleIds.Any())
			{
				foreach (Guid roleId in roleIds)
				{
					migration.MapUserRole(userId, roleId);
				}
			}
		}
	}
}
