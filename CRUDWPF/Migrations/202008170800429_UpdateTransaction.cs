namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Transaction", "OrderDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tb_M_Transaction", "DatePicker", c => c.DateTime(nullable: false));
        }
    }
}
