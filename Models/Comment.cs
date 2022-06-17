using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifyAt { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Products Product { get; set; }
    }
}
