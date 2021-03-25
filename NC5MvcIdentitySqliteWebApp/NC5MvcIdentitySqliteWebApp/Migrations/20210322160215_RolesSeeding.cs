using Microsoft.EntityFrameworkCore.Migrations;
using NC5MvcIdentitySqliteWebApp.Data;
using System;

namespace NC5MvcIdentitySqliteWebApp.Migrations
{
    public partial class RolesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddRole("admin", out Guid adminRoleGuid);
            migrationBuilder.AddRole("mod", out Guid modRoleGuid );

            migrationBuilder.AddUserWithRoles(
                email: "user_admin@mail.com",
                password: "Admin-User!",
                new[] { adminRoleGuid }
            );

            migrationBuilder.AddUserWithRoles(
                email: "user_1_mod@mail.com",
                password: "Mod-User_1!",
                new[] { modRoleGuid }
            );

            migrationBuilder.AddUserWithRoles(
                email: "user_2_mod@mail.com",
                password: "Mod-User_2!",
                new[] { modRoleGuid }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // NOTE: implement code for DB downgrating through migration.
            // Not necessary, when necessary the Admin can do it in the DB without touching the App code.
        }
    }
}
