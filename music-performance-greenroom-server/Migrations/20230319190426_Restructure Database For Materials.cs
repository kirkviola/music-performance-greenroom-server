using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace music_performance_greenroom_server.Migrations
{
    /// <inheritdoc />
    public partial class RestructureDatabaseForMaterials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentMaterial");

            migrationBuilder.DropTable(
                name: "UserMaterial");

            migrationBuilder.RenameColumn(
                name: "UserPermissionId",
                table: "UserPermission",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "UserGroup",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserCourseId",
                table: "UserCourse",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Group",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Group",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Course",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CourseDescription",
                table: "Course",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Course",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AssignmentName",
                table: "Assignement",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AssignmentMaxValue",
                table: "Assignement",
                newName: "MaxValue");

            migrationBuilder.RenameColumn(
                name: "AssignmentEarnedValue",
                table: "Assignement",
                newName: "EarnedValue");

            migrationBuilder.RenameColumn(
                name: "AssignmentDescription",
                table: "Assignement",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AssignmentId",
                table: "Assignement",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsOwner",
                table: "UserGroup",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AssignmentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Material_Assignement_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Material_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_AssignmentId",
                table: "Material",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_UserId",
                table: "Material",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropColumn(
                name: "IsOwner",
                table: "UserGroup");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserPermission",
                newName: "UserPermissionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserGroup",
                newName: "UserGroupId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserCourse",
                newName: "UserCourseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Group",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Group",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Course",
                newName: "CourseName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Course",
                newName: "CourseDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Course",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Assignement",
                newName: "AssignmentName");

            migrationBuilder.RenameColumn(
                name: "MaxValue",
                table: "Assignement",
                newName: "AssignmentMaxValue");

            migrationBuilder.RenameColumn(
                name: "EarnedValue",
                table: "Assignement",
                newName: "AssignmentEarnedValue");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Assignement",
                newName: "AssignmentDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Assignement",
                newName: "AssignmentId");

            migrationBuilder.CreateTable(
                name: "AssignmentMaterial",
                columns: table => new
                {
                    AssignmentMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    AssignmentMaterialAttachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AssignmentMaterialDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AssignmentMaterialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentMaterial", x => x.AssignmentMaterialId);
                    table.ForeignKey(
                        name: "FK_AssignmentMaterial_Assignement_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignement",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserMaterial",
                columns: table => new
                {
                    UserMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserMaterialAttachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserMaterialDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    UserMaterialName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMaterial", x => x.UserMaterialId);
                    table.ForeignKey(
                        name: "FK_UserMaterial_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentMaterial_AssignmentId",
                table: "AssignmentMaterial",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMaterial_UserId",
                table: "UserMaterial",
                column: "UserId");
        }
    }
}
