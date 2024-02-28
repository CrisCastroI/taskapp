using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Class13.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProficienciesE",
                columns: table => new
                {
                    IdProficiency = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProficienciesE", x => x.IdProficiency);
                });

            migrationBuilder.CreateTable(
                name: "UserE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCompleted = table.Column<int>(type: "int", nullable: false),
                    completionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors_Id", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_UserE_UserId",
                        column: x => x.UserId,
                        principalTable: "UserE",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoalsE",
                columns: table => new
                {
                    GoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GoalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoalCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isCompleted = table.Column<int>(type: "int", nullable: false),
                    completionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProficiencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalsE", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_GoalsE_ProficienciesE_ProficiencyId",
                        column: x => x.ProficiencyId,
                        principalTable: "ProficienciesE",
                        principalColumn: "IdProficiency",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalsE_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId");
                });

            migrationBuilder.CreateTable(
                name: "MilestonesE",
                columns: table => new
                {
                    IdMilestone = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuccessCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletionDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCompleted = table.Column<int>(type: "int", nullable: false),
                    GoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilestonesE", x => x.IdMilestone);
                    table.ForeignKey(
                        name: "FK_MilestonesE_GoalsE_GoalId",
                        column: x => x.GoalId,
                        principalTable: "GoalsE",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProficienciesE",
                columns: new[] { "IdProficiency", "Level" },
                values: new object[,]
                {
                    { new Guid("86bccc4f-7f23-4074-93e7-258e7faeceaf"), "Expert" },
                    { new Guid("996eaabc-809b-4ba7-861e-5fd6de533b93"), "Medium" },
                    { new Guid("d7e9c485-22f9-49bc-9ca0-b07730a040c5"), "Initial" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "TaskDescription", "TaskName", "UserId", "completionDate", "creationDate", "isCompleted" },
                values: new object[,]
                {
                    { new Guid("04a973b1-8bcf-4a7b-ac72-2ee6696ed3a1"), "Improve your task", "Math 3", null, "", "16-02-2024", 0 },
                    { new Guid("32be2947-3aeb-499e-8449-0396c5407f70"), "Improve your task", "Cooking", null, "", "16-02-2024", 0 },
                    { new Guid("3e0735d4-cbaa-44a2-a013-59326fed788b"), "Improve your task", "French", null, "", "16-02-2024", 0 },
                    { new Guid("452df5d2-190e-43ab-b37f-708887fed430"), "Improve your task", "Calculus 2", null, "", "16-02-2024", 0 },
                    { new Guid("6f965003-fe46-40cd-8212-00a23f7d078e"), "Improve your task", "Calculus 4", null, "", "16-02-2024", 0 },
                    { new Guid("884886da-e2d0-43b1-875b-28c27ce8cc6b"), "Improve your task", "Math 2", null, "", "16-02-2024", 0 },
                    { new Guid("954127e0-e993-4955-8866-e7a7764da7e6"), "Improve your task", "Math 4", null, "", "16-02-2024", 0 },
                    { new Guid("9c2f40e9-b323-4cbe-91aa-ee8d5b884755"), "Improve your task", "Calculus", null, "", "16-02-2024", 0 },
                    { new Guid("ab46b282-92c1-4745-a3e9-9316d3d92209"), "Improve your task", "Calculus 3", null, "", "16-02-2024", 0 },
                    { new Guid("c9c1c635-5f2e-45e1-a979-c10ab8d77d08"), "Improve your task", "Fix Procastrination", null, "", "16-02-2024", 0 },
                    { new Guid("cf01895c-c97b-4924-a32c-032550d78dfc"), "Improve your task", "Chore list", null, "", "16-02-2024", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserE",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { new Guid("be9d19ec-8903-45b9-84dd-9857c5c5e220"), "user2@gmail.com", "second", "last", "password" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b36"), "user1@gmail.com", "first", "last", "password" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "TaskDescription", "TaskName", "UserId", "completionDate", "creationDate", "isCompleted" },
                values: new object[,]
                {
                    { new Guid("0179fed6-7ff9-44b4-b017-3eaf9368350b"), "Improve your english from start", "English", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b36"), "", "16-02-2024", 0 },
                    { new Guid("36879055-294b-42e3-9db2-88792d34c1df"), "Improve your task", "Cooking 2", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b36"), "", "16-02-2024", 0 },
                    { new Guid("38c3aa57-0e9f-467f-8e16-493cf4962a4f"), "Desc 1", "Task 1", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b36"), "", "16-02-2024", 0 },
                    { new Guid("9f68d19b-4742-4f50-9233-98498315cd06"), "Improve your task", "Gym Routine", new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b36"), "", "16-02-2024", 0 }
                });

            migrationBuilder.InsertData(
                table: "GoalsE",
                columns: new[] { "GoalId", "GoalCondition", "GoalDescription", "GoalName", "ProficiencyId", "TaskId", "completionDate", "creationDate", "isCompleted" },
                values: new object[,]
                {
                    { new Guid("1aae8ba5-0251-4845-9f3f-bba4779189fb"), "Understand conversations", "Practice listening", "Improve Listening", new Guid("d7e9c485-22f9-49bc-9ca0-b07730a040c5"), new Guid("0179fed6-7ff9-44b4-b017-3eaf9368350b"), "", "16-02-2024", 0 },
                    { new Guid("7500dd79-bf27-43db-a329-6ada5fbb4129"), "Finish Text", "Practice reading", "Read English text", new Guid("d7e9c485-22f9-49bc-9ca0-b07730a040c5"), new Guid("0179fed6-7ff9-44b4-b017-3eaf9368350b"), "", "16-02-2024", 0 }
                });

            migrationBuilder.InsertData(
                table: "MilestonesE",
                columns: new[] { "IdMilestone", "CompletionDate", "Description", "GoalId", "Name", "SuccessCondition", "isCompleted" },
                values: new object[] { new Guid("476d5695-d378-47a9-9c11-0915715355c7"), "", "Practice listening", new Guid("1aae8ba5-0251-4845-9f3f-bba4779189fb"), "Watch movie in English", "Understand Movie Dialog", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_GoalsE_ProficiencyId",
                table: "GoalsE",
                column: "ProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalsE_TaskId",
                table: "GoalsE",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_MilestonesE_GoalId",
                table: "MilestonesE",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilestonesE");

            migrationBuilder.DropTable(
                name: "GoalsE");

            migrationBuilder.DropTable(
                name: "ProficienciesE");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "UserE");
        }
    }
}
