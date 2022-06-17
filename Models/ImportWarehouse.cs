using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class ImportWarehouse
    {
        public int Id { get; set; }
        public int SupplierCode { get; set; }
        public string Supplier { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int ShipmentId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual WarehouseDetails Shipment { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
