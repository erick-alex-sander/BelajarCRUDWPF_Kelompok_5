namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addModelDatabases : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_Item", new[] { "Supplier_Id" });
            AlterColumn("dbo.Tb_M_Item", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Tb_M_Item", "Supplier_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tb_M_Item", "Supplier_Id");
            AddForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier", "Id", cascadeDelete: true);
            DropColumn("dbo.Tb_M_Transaction", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_M_Transaction", "OrderDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier");
            DropIndex("dbo.Tb_M_Item", new[] { "Supplier_Id" });
            AlterColumn("dbo.Tb_M_Item", "Supplier_Id", c => c.Int());
            AlterColumn("dbo.Tb_M_Item", "Price", c => c.Long(nullable: false));
            CreateIndex("dbo.Tb_M_Item", "Supplier_Id");
            AddForeignKey("dbo.Tb_M_Item", "Supplier_Id", "dbo.Tb_M_Supplier", "Id");
        }
    }
}
