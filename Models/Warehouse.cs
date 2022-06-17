using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            ImportWarehouse = new HashSet<ImportWarehouse>();
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int ImportWarehouseId { get; set; }
        public int WarehouseId { get; set; }
        public int WarehouseDetailsId { get; set; }

        public virtual WarehouseDetails WarehouseDetails { get; set; }
        public virtual ICollection<ImportWarehouse> ImportWarehouse { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
