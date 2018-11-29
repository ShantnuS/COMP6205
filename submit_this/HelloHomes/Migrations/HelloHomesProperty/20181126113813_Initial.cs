using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloHomes.Migrations.HelloHomesProperty
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Bedrooms = table.Column<int>(nullable: false),
                    RentPerMonth = table.Column<decimal>(nullable: false),
                    LandlordID = table.Column<long>(nullable: false),
                    LandlordName = table.Column<string>(nullable: false),
                    LandlordNumber = table.Column<string>(nullable: false),
                    ApprovalStatus = table.Column<int>(nullable: false),
                    ApprovalComment = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    ImageContentType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
