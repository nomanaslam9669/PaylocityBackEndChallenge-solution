using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Relationship = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1960, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4639), "Charlotte", "Johnson", 103027m },
                    { 2, new DateTime(1999, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4709), "William", "Williams", 134500m },
                    { 3, new DateTime(1977, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4714), "Amelia", "Brown", 108453m },
                    { 4, new DateTime(1988, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4716), "James", "Jones", 75513m },
                    { 5, new DateTime(1960, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4720), "Harper", "Garcia", 78857m },
                    { 6, new DateTime(1988, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4725), "Benjamin", "Miller", 57522m },
                    { 7, new DateTime(1993, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4728), "Evelyn", "Davis", 51454m },
                    { 8, new DateTime(1993, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4731), "Lucas", "Rodriguez", 121082m },
                    { 9, new DateTime(1991, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4734), "Abigail", "Martinez", 71628m },
                    { 10, new DateTime(1992, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4737), "Henry", "Hernandez", 141530m },
                    { 11, new DateTime(1994, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4740), "Ella", "Lopez", 106734m },
                    { 12, new DateTime(1975, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4742), "Alexander", "Gonzalez", 133473m },
                    { 13, new DateTime(1992, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4745), "Mia", "Wilson", 149168m },
                    { 14, new DateTime(1968, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4748), "Michael", "Anderson", 120879m },
                    { 15, new DateTime(1989, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4751), "Scarlett", "Thomas", 78556m },
                    { 16, new DateTime(1965, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4754), "Elijah", "Taylor", 104481m },
                    { 17, new DateTime(1998, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4756), "Aria", "Moore", 97525m },
                    { 18, new DateTime(1971, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4760), "Jackson", "Jackson", 101094m },
                    { 19, new DateTime(1996, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4762), "Grace", "Martin", 61107m },
                    { 20, new DateTime(1968, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4765), "Sebastian", "Lee", 126266m },
                    { 21, new DateTime(1985, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4768), "Chloe", "Perez", 110980m },
                    { 22, new DateTime(1979, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4770), "Aiden", "Thompson", 63298m },
                    { 23, new DateTime(1966, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4773), "Sofia", "White", 101600m },
                    { 24, new DateTime(1978, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4814), "Matthew", "Harris", 145548m },
                    { 25, new DateTime(1994, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4817), "Riley", "Sanchez", 126631m },
                    { 26, new DateTime(1977, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4820), "Samuel", "Clark", 98823m },
                    { 27, new DateTime(1983, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4823), "Victoria", "Ramirez", 86465m },
                    { 28, new DateTime(1984, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4826), "David", "Lewis", 53455m },
                    { 29, new DateTime(1992, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4828), "Lily", "Robinson", 60374m },
                    { 30, new DateTime(1998, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4831), "Joseph", "Walker", 130833m }
                });

            migrationBuilder.InsertData(
                table: "Dependents",
                columns: new[] { "Id", "DateOfBirth", "EmployeeId", "FirstName", "LastName", "Relationship" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4927), 1, "Aurora", "Young", 1 },
                    { 2, new DateTime(2013, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(4997), 1, "Carter", "Allen", 0 },
                    { 3, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5003), 1, "Zoey", "King", 3 },
                    { 4, new DateTime(2019, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5007), 2, "Carter", "Allen", 2 },
                    { 5, new DateTime(2005, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5011), 2, "Zoey", "King", 3 },
                    { 6, new DateTime(2024, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5015), 3, "Zoey", "King", 1 },
                    { 7, new DateTime(2009, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5019), 3, "Owen", "Wright", 2 },
                    { 8, new DateTime(2020, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5024), 3, "Hannah", "Scott", 0 },
                    { 9, new DateTime(2014, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5027), 3, "Wyatt", "Torres", 2 },
                    { 10, new DateTime(2024, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5032), 3, "Penelope", "Nguyen", 3 },
                    { 11, new DateTime(2002, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5036), 4, "Owen", "Wright", 3 },
                    { 12, new DateTime(2016, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5040), 4, "Hannah", "Scott", 1 },
                    { 13, new DateTime(2008, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5044), 4, "Wyatt", "Torres", 1 },
                    { 14, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5047), 5, "Hannah", "Scott", 0 },
                    { 15, new DateTime(2004, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5051), 5, "Wyatt", "Torres", 1 },
                    { 16, new DateTime(2023, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5094), 6, "Wyatt", "Torres", 0 },
                    { 17, new DateTime(2006, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5099), 6, "Penelope", "Nguyen", 1 },
                    { 18, new DateTime(2000, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5103), 6, "John", "Hill", 2 },
                    { 19, new DateTime(2013, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5107), 7, "Penelope", "Nguyen", 3 },
                    { 20, new DateTime(2016, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5110), 7, "John", "Hill", 0 },
                    { 21, new DateTime(2005, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5114), 7, "Layla", "Flores", 2 },
                    { 22, new DateTime(2010, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5118), 7, "Jack", "Green", 0 },
                    { 23, new DateTime(2007, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5121), 7, "Lillian", "Adams", 3 },
                    { 24, new DateTime(2000, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5125), 8, "John", "Hill", 3 },
                    { 25, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5128), 8, "Layla", "Flores", 3 },
                    { 26, new DateTime(2015, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5131), 8, "Jack", "Green", 0 },
                    { 27, new DateTime(2004, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5135), 8, "Lillian", "Adams", 3 },
                    { 28, new DateTime(2018, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5138), 8, "Luke", "Nelson", 2 },
                    { 29, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5142), 9, "Layla", "Flores", 1 },
                    { 30, new DateTime(2009, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5145), 9, "Jack", "Green", 1 },
                    { 31, new DateTime(2018, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5148), 10, "Jack", "Green", 0 },
                    { 32, new DateTime(2015, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5151), 10, "Lillian", "Adams", 3 },
                    { 33, new DateTime(2004, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5154), 10, "Luke", "Nelson", 3 },
                    { 34, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5159), 11, "Lillian", "Adams", 3 },
                    { 35, new DateTime(2010, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5162), 11, "Luke", "Nelson", 0 },
                    { 36, new DateTime(2017, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5165), 11, "Addison", "Baker", 0 },
                    { 37, new DateTime(2016, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5169), 12, "Luke", "Nelson", 1 },
                    { 38, new DateTime(2005, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5200), 12, "Addison", "Baker", 1 },
                    { 39, new DateTime(2019, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5204), 12, "Daniel", "Hall", 2 },
                    { 40, new DateTime(2023, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5207), 12, "Eleanor", "Rivera", 2 },
                    { 41, new DateTime(2016, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5211), 13, "Addison", "Baker", 0 },
                    { 42, new DateTime(2020, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5215), 13, "Daniel", "Hall", 0 },
                    { 43, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5219), 13, "Eleanor", "Rivera", 2 },
                    { 44, new DateTime(2024, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5222), 13, "Gabriel", "Campbell", 2 },
                    { 45, new DateTime(2008, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5226), 14, "Daniel", "Hall", 3 },
                    { 46, new DateTime(2014, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5230), 14, "Eleanor", "Rivera", 2 },
                    { 47, new DateTime(2004, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5233), 14, "Gabriel", "Campbell", 3 },
                    { 48, new DateTime(2015, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5237), 15, "Eleanor", "Rivera", 0 },
                    { 49, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5240), 15, "Gabriel", "Campbell", 0 },
                    { 50, new DateTime(2011, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5243), 15, "Natalie", "Mitchell", 1 },
                    { 51, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5246), 16, "Gabriel", "Campbell", 1 },
                    { 52, new DateTime(2007, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5249), 16, "Natalie", "Mitchell", 0 },
                    { 53, new DateTime(2014, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5253), 16, "Logan", "Carter", 2 },
                    { 54, new DateTime(2017, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5256), 16, "Savannah", "Roberts", 0 },
                    { 55, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5260), 17, "Natalie", "Mitchell", 0 },
                    { 56, new DateTime(2015, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5263), 17, "Logan", "Carter", 3 },
                    { 57, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5266), 17, "Savannah", "Roberts", 3 },
                    { 58, new DateTime(2012, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5269), 17, "Anthony", "Gomez", 2 },
                    { 59, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5273), 18, "Logan", "Carter", 0 },
                    { 60, new DateTime(2005, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5276), 18, "Savannah", "Roberts", 1 },
                    { 61, new DateTime(2017, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5279), 18, "Anthony", "Gomez", 1 },
                    { 62, new DateTime(2013, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5283), 19, "Savannah", "Roberts", 2 },
                    { 63, new DateTime(2018, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5312), 19, "Anthony", "Gomez", 0 },
                    { 64, new DateTime(2020, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5315), 19, "Isla", "Phillips", 3 },
                    { 65, new DateTime(2016, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5319), 19, "Isaac", "Evans", 1 },
                    { 66, new DateTime(2016, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5324), 20, "Anthony", "Gomez", 1 },
                    { 67, new DateTime(2008, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5327), 20, "Isla", "Phillips", 0 },
                    { 68, new DateTime(2008, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5331), 20, "Isaac", "Evans", 2 },
                    { 69, new DateTime(2002, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5334), 20, "Hazel", "Turner", 3 },
                    { 70, new DateTime(2024, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5338), 20, "Julian", "Diaz", 2 },
                    { 71, new DateTime(2011, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5341), 21, "Isla", "Phillips", 0 },
                    { 72, new DateTime(2006, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5344), 21, "Isaac", "Evans", 0 },
                    { 73, new DateTime(2019, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5348), 21, "Hazel", "Turner", 2 },
                    { 74, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5351), 21, "Julian", "Diaz", 0 },
                    { 75, new DateTime(2014, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5354), 22, "Isaac", "Evans", 1 },
                    { 76, new DateTime(2013, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5358), 22, "Hazel", "Turner", 3 },
                    { 77, new DateTime(2013, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5361), 22, "Julian", "Diaz", 2 },
                    { 78, new DateTime(2016, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5364), 22, "Violet", "Parker", 3 },
                    { 79, new DateTime(2020, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5368), 23, "Hazel", "Turner", 3 },
                    { 80, new DateTime(2000, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5371), 23, "Julian", "Diaz", 2 },
                    { 81, new DateTime(2007, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5374), 23, "Violet", "Parker", 0 },
                    { 82, new DateTime(2008, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5378), 24, "Julian", "Diaz", 3 },
                    { 83, new DateTime(2014, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5381), 24, "Violet", "Parker", 1 },
                    { 84, new DateTime(2007, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5384), 24, "Levi", "Cruz", 1 },
                    { 85, new DateTime(2010, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5412), 24, "Aubrey", "Edwards", 2 },
                    { 86, new DateTime(2002, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5416), 25, "Violet", "Parker", 3 },
                    { 87, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5419), 25, "Levi", "Cruz", 3 },
                    { 88, new DateTime(2013, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5423), 26, "Levi", "Cruz", 2 },
                    { 89, new DateTime(2018, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5427), 26, "Aubrey", "Edwards", 3 },
                    { 90, new DateTime(2008, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5430), 26, "Ryan", "Collins", 3 },
                    { 91, new DateTime(2017, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5434), 26, "Claire", "Reyes", 1 },
                    { 92, new DateTime(2013, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5437), 27, "Aubrey", "Edwards", 1 },
                    { 93, new DateTime(2006, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5440), 27, "Ryan", "Collins", 1 },
                    { 94, new DateTime(2023, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5444), 27, "Claire", "Reyes", 2 },
                    { 95, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5447), 28, "Ryan", "Collins", 2 },
                    { 96, new DateTime(2006, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5451), 28, "Claire", "Reyes", 2 },
                    { 97, new DateTime(2010, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5454), 28, "Ethan", "Brooks", 0 },
                    { 98, new DateTime(2019, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5457), 28, "Madison", "Powell", 3 },
                    { 99, new DateTime(2015, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5461), 29, "Claire", "Reyes", 2 },
                    { 100, new DateTime(2004, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5464), 29, "Ethan", "Brooks", 0 },
                    { 101, new DateTime(2004, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5467), 29, "Madison", "Powell", 1 },
                    { 102, new DateTime(2018, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5471), 30, "Ethan", "Brooks", 0 },
                    { 103, new DateTime(2001, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5474), 30, "Madison", "Powell", 2 },
                    { 104, new DateTime(2003, 5, 24, 21, 52, 27, 990, DateTimeKind.Local).AddTicks(5477), 30, "Mason", "Long", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_EmployeeId",
                table: "Dependents",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
