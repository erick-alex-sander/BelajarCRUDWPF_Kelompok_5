namespace CRUDWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tb_M_Transaction", "DatePicker", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tb_M_Transaction", "DatePicker");
        }
    }
}
