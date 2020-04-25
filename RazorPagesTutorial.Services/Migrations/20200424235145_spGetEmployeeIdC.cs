using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesTutorial.Services.Migrations
{
    public partial class spGetEmployeeIdC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create Procedure spGetEmployeeById (@Id int)
                                    as
                                    BEGIN
                                    Select* from Employees where Id = @Id
                                    END";


            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"DROP Create Procedure spGetEmployeeById";
            migrationBuilder.Sql(procedure);


        }


    }
}
