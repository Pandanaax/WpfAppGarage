namespace WpfAppGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voitures", "Voiture_Id", c => c.Int());
            CreateIndex("dbo.Voitures", "Voiture_Id");
            AddForeignKey("dbo.Voitures", "Voiture_Id", "dbo.Voitures", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voitures", "Voiture_Id", "dbo.Voitures");
            DropIndex("dbo.Voitures", new[] { "Voiture_Id" });
            DropColumn("dbo.Voitures", "Voiture_Id");
        }
    }
}
