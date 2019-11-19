namespace Aircraft.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1_base : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aircraft",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(maxLength: 256),
                        SerialNumber = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aircraft");
        }
    }
}
