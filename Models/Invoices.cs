using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DA_TOTNGHIEP.Models
{
    public partial class Invoices
    {
        public Invoices()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int AccountId { get; set; }
        public DateTime IssuedDate { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingPhone { get; set; }
        public int Total { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public int StatusId { get; set; }
        public int? ProductItemsId { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Products ProductItems { get; set; }
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
