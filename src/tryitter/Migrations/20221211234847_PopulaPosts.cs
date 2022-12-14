using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tryitter.Migrations
{
    public partial class PopulaPosts : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("Insert into Posts(Texto, ImagemUrl, UserId) Values('Como se preparar para o mercado de trabalho', 'coffeimage.jpeg', 1)");
            mB.Sql("Insert into Posts(Texto, ImagemUrl, UserId) Values('Ferramentas para criar protótipos de projetos web', 'fotofigma.jpeg', 2)");
            mB.Sql("Insert into Posts(Texto, ImagemUrl, UserId) Values('A vida real de um dev', 'computersimage.png', 3)");
        }

        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("Delete from Posts");
        }
    }
}
