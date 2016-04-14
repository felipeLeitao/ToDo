namespace ProntMed.Todo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TB_TODO : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Todo", newName: "TB_TODO");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TB_TODO", newName: "Todo");
        }
    }
}
