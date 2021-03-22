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
			if(string.IsNullOrWhiteSpace(roleName))
			{
				return;
			}

			string normalizedRoleName = roleName.ToUpperInvariant();
			//migration.ActiveProvider -- check msdn
			// SQLite syntax:
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
	}
}
