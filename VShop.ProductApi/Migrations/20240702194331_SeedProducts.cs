using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name,Price,Description,Stock, ImageURL, CategoryId) " +
                "Values('Caderno', 7.55, 'Caderno Esirais',10,'caderno1.jpg', 1 )");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Lápis', 3.45, 'Lápis Preto',20,'lapis1.jpg', 1 )");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Clips', 5.35, 'Clips para papel',50,'clips1.jpg', 2 )");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
