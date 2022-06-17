using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Carts = new HashSet<Carts>();
            Comment = new HashSet<Comment>();
            Invoices = new HashSet<Invoices>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
