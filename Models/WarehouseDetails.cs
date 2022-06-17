using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class WarehouseDetails
    {
        public WarehouseDetails()
        {
            ImportWarehouse = new HashSet<ImportWarehouse>();
            Products = new HashSet<Products>();
            Warehouse = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string Shipment { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<ImportWarehouse> ImportWarehouse { get; set; }
        public virtual ICollection<Products> Products { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
