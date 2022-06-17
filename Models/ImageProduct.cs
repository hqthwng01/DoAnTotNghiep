using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class ImageProduct
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int? ProductsID { get; set; }
        public bool Status { get; set; }

        public virtual Products Products { get; set; }
    }
}
