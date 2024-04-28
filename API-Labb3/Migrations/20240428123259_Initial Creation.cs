using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Labb3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.PersonInterestId);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interestlinks",
                columns: table => new
                {
                    InterestLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonInterestId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interestlinks", x => x.InterestLinkId);
                    table.ForeignKey(
                        name: "FK_Interestlinks_PersonInterests_PersonInterestId",
                        column: x => x.PersonInterestId,
                        principalTable: "PersonInterests",
                        principalColumn: "PersonInterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Fotografering är en kreativ hobby och konstform där man fångar bilder med en kamera. Det ger möjlighet att uttrycka sig, dokumentera ögonblick och utforska olika perspektiv. Fotografer kan fokusera på områden som natur, porträtt eller evenemang. Hobbyn kombinerar teknisk kunskap om kameror och bildkomposition med ett öga för estetik, vilket gör det till en uppskattad sysselsättning både professionellt och som fritidsintresse.", "Fotografering" },
                    { 2, "Gaming är en populär hobby där spelare interagerar med digitala spel på olika plattformar som datorer, konsoler och mobila enheter. Det erbjuder en bred variation av genrer, från strategi och äventyr till sport och action, vilket möjliggör både underhållning och mental utmaning. Spelare kan utforska virtuella världar, tävla mot andra, eller samarbeta i team. Gaming förbättrar problemlösningsförmåga, hand-ögon-koordination och sociala färdigheter, och kan även vara en väg till professionell e-sport.", "Gaming" },
                    { 3, "Hästar är fascinerande och ädla djur som engagerar människor världen över, både som husdjur och inom olika ridsporter. De används inom ridskola, dressyr, hoppning och westernridning. Att arbeta med hästar främjar fysisk aktivitet, ansvarskänsla och en djupare förståelse för djur. Många upplever ridning som terapeutiskt och avkopplande. Intresset för hästar kan även leda till yrken som stallskötare, tränare eller veterinär, vilket gör det till ett berikande och mångsidigt intresse.", "Hästar" },
                    { 4, "Läsning är en berikande hobby som öppnar dörrar till olika världar och perspektiv genom böcker. Den erbjuder både underhållning och kunskap, från historiska berättelser till framtida spekulationer. Läsare kan dyka in i skönlitteratur för att fly verkligheten eller utforska facklitteratur för att lära sig nya fakta och färdigheter. Läsning stärker ordförrådet, förbättrar minnet och analytiska förmågor, och ger en lugn stund i en annars hektisk vardag. Det är ett intresse som enkelt kan anpassas till varje livsstil.", "Läsning" },
                    { 5, "Vandring och friluftsliv är populära aktiviteter som ger människor möjlighet att komma närmare naturen och främja fysisk hälsa. Dessa aktiviteter inkluderar allt från lätta promenader i lokala parker till utmanande bergsbestigningar. Vandring erbjuder en unik kombination av motion, äventyr och avkoppling. Många uppskattar möjligheten att andas frisk luft, uppleva vilda landskap och observera djur i deras naturliga miljö. Friluftsliv kan även innebära camping, paddling och fågelskådning, vilket gör det till ett mångsidigt och berikande intresse.", "Vandring och friluftsliv" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Eddie Halling", "0704862648" },
                    { 2, "Sara Liljedahl", "0704126534" },
                    { 3, "Vincent Johansson", "0704734977" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "PersonInterestId", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 5, 1 },
                    { 4, 3, 2 },
                    { 5, 4, 2 },
                    { 6, 2, 3 },
                    { 7, 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Interestlinks",
                columns: new[] { "InterestLinkId", "PersonInterestId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://digitalfotoforalla.se/fotografering" },
                    { 2, 2, "https://gamerant.com/gaming/" },
                    { 3, 3, "https://www.friluftsframjandet.se/lat-aventyret-borja/hitta-aventyr/vandring/" },
                    { 4, 4, "https://hastsverige.se/om-hasten/" },
                    { 5, 5, "https://www.adlibris.com/se" },
                    { 6, 6, "https://www.pcgamer.com/news/" },
                    { 7, 7, "https://www.reldinadventures.com/tips-om-vandring-och-friluftsliv-for-nyborjaren/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interestlinks_PersonInterestId",
                table: "Interestlinks",
                column: "PersonInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interestlinks");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
