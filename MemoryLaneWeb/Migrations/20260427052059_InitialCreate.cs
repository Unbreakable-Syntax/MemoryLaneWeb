using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MemoryLaneWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderID = table.Column<int>(type: "integer", nullable: false),
                    SenderName = table.Column<string>(type: "text", nullable: true),
                    SenderRole = table.Column<string>(type: "text", nullable: true),
                    RecipientID = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    PatientID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    MedicalNotes = table.Column<string>(type: "text", nullable: true),
                    EmergencyContact = table.Column<string>(type: "text", nullable: true),
                    EmergencyPhone = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CaregiverID = table.Column<int>(type: "integer", nullable: false),
                    LinkedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaregiverPatient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CaregiverID = table.Column<int>(type: "integer", nullable: false),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaregiverPatient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaregiverPatient_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaregiverPatient_Users_CaregiverID",
                        column: x => x.CaregiverID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyAlerts",
                columns: table => new
                {
                    AlertID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    AlertType = table.Column<int>(type: "integer", nullable: false),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: true),
                    Longitude = table.Column<double>(type: "double precision", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true),
                    IsResolved = table.Column<bool>(type: "boolean", nullable: false),
                    ResolvedBy = table.Column<int>(type: "integer", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TriggeredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyAlerts", x => x.AlertID);
                    table.ForeignKey(
                        name: "FK_EmergencyAlerts_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyAlerts_Users_ResolvedBy",
                        column: x => x.ResolvedBy,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPatient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FamilyID = table.Column<int>(type: "integer", nullable: false),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: true),
                    CanViewLocation = table.Column<bool>(type: "boolean", nullable: false),
                    CanViewAlerts = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPatient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyPatient_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FamilyPatient_Users_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientLocations",
                columns: table => new
                {
                    LocationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Altitude = table.Column<double>(type: "double precision", nullable: true),
                    AccuracyM = table.Column<double>(type: "double precision", nullable: true),
                    Source = table.Column<int>(type: "integer", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLocations", x => x.LocationID);
                    table.ForeignKey(
                        name: "FK_PatientLocations_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    ReminderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ReminderType = table.Column<int>(type: "integer", nullable: false),
                    RemindAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Recurrences = table.Column<int>(type: "integer", nullable: false),
                    IsAcknowledged = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.ReminderID);
                    table.ForeignKey(
                        name: "FK_Reminders_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reminders_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SafeZones",
                columns: table => new
                {
                    ZoneID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientID = table.Column<int>(type: "integer", nullable: false),
                    ZoneName = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    RadiusMeters = table.Column<double>(type: "double precision", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeZones", x => x.ZoneID);
                    table.ForeignKey(
                        name: "FK_SafeZones_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SafeZones_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverPatient_CaregiverID",
                table: "CaregiverPatient",
                column: "CaregiverID");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverPatient_CaregiverID_PatientID",
                table: "CaregiverPatient",
                columns: new[] { "CaregiverID", "PatientID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverPatient_PatientID",
                table: "CaregiverPatient",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_PatientID",
                table: "ChatMessages",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_RecipientID_IsRead",
                table: "ChatMessages",
                columns: new[] { "RecipientID", "IsRead" });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderID_RecipientID",
                table: "ChatMessages",
                columns: new[] { "SenderID", "RecipientID" });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyAlerts_IsResolved",
                table: "EmergencyAlerts",
                column: "IsResolved");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyAlerts_PatientID",
                table: "EmergencyAlerts",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyAlerts_ResolvedBy",
                table: "EmergencyAlerts",
                column: "ResolvedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyAlerts_TriggeredAt",
                table: "EmergencyAlerts",
                column: "TriggeredAt");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPatient_FamilyID",
                table: "FamilyPatient",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPatient_FamilyID_PatientID",
                table: "FamilyPatient",
                columns: new[] { "FamilyID", "PatientID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyPatient_PatientID",
                table: "FamilyPatient",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLocations_PatientID",
                table: "PatientLocations",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLocations_RecordedAt",
                table: "PatientLocations",
                column: "RecordedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserID",
                table: "Patients",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_CreatedBy",
                table: "Reminders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_PatientID",
                table: "Reminders",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_RemindAt",
                table: "Reminders",
                column: "RemindAt");

            migrationBuilder.CreateIndex(
                name: "IX_SafeZones_CreatedBy",
                table: "SafeZones",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SafeZones_PatientID",
                table: "SafeZones",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role",
                table: "Users",
                column: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaregiverPatient");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "EmergencyAlerts");

            migrationBuilder.DropTable(
                name: "FamilyPatient");

            migrationBuilder.DropTable(
                name: "PatientLocations");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "SafeZones");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
