using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
            Comment = new HashSet<Comment>();
            ImageProduct = new HashSet<ImageProduct>();
            InvoiceDetails = new HashSet<InvoiceDetails>();
            Invoices = new HashSet<Invoices>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int? ProductTypeId { get; set; }
        public string? ImageName { get; set; }
        public int? WarehouseId { get; set; }
        public int? ShipmentId { get; set; }
        public bool Status { get; set; }

        public virtual ProductTypes ProductType { get; set; }
        public virtual WarehouseDetails Shipment { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<ImageProduct> ImageProduct { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
