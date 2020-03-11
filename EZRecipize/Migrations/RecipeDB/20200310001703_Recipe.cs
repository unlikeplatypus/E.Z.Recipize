using Microsoft.EntityFrameworkCore.Migrations;

namespace EZRecipize.Migrations.RecipeDB
{
    public partial class Recipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    //Id = table.Column<int>(nullable: false)
                    //    .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeName = table.Column<string>(nullable: false),
                    RecipeDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    //table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instructions = table.Column<string>(nullable: false),
                    TempRequiredCookware = table.Column<string>(nullable: true),
                    TempSuggestedCookware = table.Column<string>(nullable: true),
                    IsTimer = table.Column<bool>(nullable: false),
                    Timer = table.Column<int>(nullable: false),
                    TimerName = table.Column<string>(nullable: true),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => x.id);
                    table.ForeignKey(
                        name: "FK_RecipeStep_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    SpecialInstructions = table.Column<string>(nullable: true),
                    RecipeStepid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingredient_RecipeStep_RecipeStepid",
                        column: x => x.RecipeStepid,
                        principalTable: "RecipeStep",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeStepid",
                table: "Ingredient",
                column: "RecipeStepid");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStep_RecipeId",
                table: "RecipeStep",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
