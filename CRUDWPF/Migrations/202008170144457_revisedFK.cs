namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revisedFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tb_M_TransactionItem", "Item_Id", "dbo.Tb_M_Item");
            DropForeignKey("dbo.Tb_M_TransactionItem", "Transaction_Id", "dbo.Tb_M_Transaction");
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Item_Id" });
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Transaction_Id" });
            AlterColumn("dbo.Tb_M_TransactionItem", "Item_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Tb_M_TransactionItem", "Transaction_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Tb_M_TransactionItem", "Item_Id");
            CreateIndex("dbo.Tb_M_TransactionItem", "Transaction_Id");
            AddForeignKey("dbo.Tb_M_TransactionItem", "Item_Id", "dbo.Tb_M_Item", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tb_M_TransactionItem", "Transaction_Id", "dbo.Tb_M_Transaction", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_TransactionItem", "Transaction_Id", "dbo.Tb_M_Transaction");
            DropForeignKey("dbo.Tb_M_TransactionItem", "Item_Id", "dbo.Tb_M_Item");
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Transaction_Id" });
            DropIndex("dbo.Tb_M_TransactionItem", new[] { "Item_Id" });
            AlterColumn("dbo.Tb_M_TransactionItem", "Transaction_Id", c => c.Int());
            AlterColumn("dbo.Tb_M_TransactionItem", "Item_Id", c => c.Int());
            CreateIndex("dbo.Tb_M_TransactionItem", "Transaction_Id");
            CreateIndex("dbo.Tb_M_TransactionItem", "Item_Id");
            AddForeignKey("dbo.Tb_M_TransactionItem", "Transaction_Id", "dbo.Tb_M_Transaction", "Id");
            AddForeignKey("dbo.Tb_M_TransactionItem", "Item_Id", "dbo.Tb_M_Item", "Id");
        }
    }
}
