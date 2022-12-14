using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tryitter.Migrations
{
    public partial class RepopulaUsers : Migration
    {
        protected override void Up(MigrationBuilder mB)
        {
            mB.Sql("Insert into Users(Nome, Email, Senha, Modulo, Status) Values('Amanda', 'amandagayotto@hotmail.com', 'minhasenha', 'c#', 'finalizando projeto aceleração')");
            mB.Sql("Insert into Users(Nome, Email, Senha, Modulo, Status) Values('Marcelo', 'marcelodc@hotmail.com', 'senha123', 'python', 'finalizando módulo')");
            mB.Sql("Insert into Users(Nome, Email, Senha, Modulo, Status) Values('Laura', 'laurasouza@hotmail.com', 'senhasecreta', 'css', 'projeto com estilização')");
            mB.Sql("Insert into Users(Nome, Email, Senha, Modulo, Status) Values('Antonio', 'antoniodb@hotmail.com', 'senha456', 'html', 'início do curso desenvolvimento web')");
        }

        protected override void Down(MigrationBuilder mB)
        {
            mB.Sql("Delete from Users");
        }
    }
}
