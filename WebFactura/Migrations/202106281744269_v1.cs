namespace WebFactura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Dni = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        Address = c.String(maxLength: 100),
                        InvoiceDetail_InvoiceDetailID = c.Int(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.InvoiceDetails", t => t.InvoiceDetail_InvoiceDetailID)
                .Index(t => t.InvoiceDetail_InvoiceDetailID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        RucEmisor = c.Int(nullable: false),
                        AddressInv = c.String(maxLength: 100),
                        RucClient = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        State = c.String(),
                        Total = c.Double(nullable: false),
                        IGV = c.Double(nullable: false),
                        Client_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailID = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        SubTotal = c.Double(nullable: false),
                        Invoice_InvoiceID = c.Int(),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceDetailID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Invoice_InvoiceID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Price = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        Brand = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "Invoice_InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.Clients", "InvoiceDetail_InvoiceDetailID", "dbo.InvoiceDetails");
            DropForeignKey("dbo.Invoices", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.InvoiceDetails", new[] { "Product_ProductID" });
            DropIndex("dbo.InvoiceDetails", new[] { "Invoice_InvoiceID" });
            DropIndex("dbo.Invoices", new[] { "Client_ClientID" });
            DropIndex("dbo.Clients", new[] { "InvoiceDetail_InvoiceDetailID" });
            DropTable("dbo.Products");
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Invoices");
            DropTable("dbo.Clients");
        }
    }
}
