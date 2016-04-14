namespace ProntMed.Todo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todo",
                c => new
                    {
                        idTodo = c.Int(nullable: false, identity: true),
                        dsTitulo = c.String(nullable: false),
                        dsTodo = c.String(nullable: false),
                        dtCadastro = c.DateTime(nullable: false),
                        dsStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idTodo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Todo");
        }
    }
}
