using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tryitter.Migrations
{
    public partial class PopulaTryitterPosts : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("Insert into TryitterPosts(Texto, ImagemUrl, UserId) Values('Como se preparar para o mercado de trabalho', 'coffeimage.jpeg', 1)");
            mB.Sql("Insert into TryitterPosts(Texto, ImagemUrl, UserId) Values('Ferramentas para criar protótipos de projetos web', 'fotofigma.jpeg', 2)");
            mB.Sql("Insert into TryitterPosts(Texto, ImagemUrl, UserId) Values('A vida real de um dev', 'computersimage.png', 3)");
            mB.Sql("Insert into TryitterPosts(Texto, ImagemUrl, UserId) Values('Resumo do livro: HTML e CSS for beginners', 'imageti.png', 4)");
        }

        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("Delete from TryitterPosts");
        }
    }
}
