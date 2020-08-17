namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransaction1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tb_M_Transaction", "OrderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tb_M_Transaction", "OrderDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
