using ShopApp.Data.Enums;
using ShopApp.Data.Interfaces;
using ShopApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShopApp.Data.Entities
{
    [Table("Bills")]
    public class Bill : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Bill()
        {

        }

        public Bill(string customeName, string customerAddress, string customerMobie, string customerMessage,
        BillStatus billStatus, PaymentMethod paymentMethod, Status status, string customerId
        )
        {
            CustomerName = customeName;
            CustomerAddress = customerAddress;
            CustomerMobie = customerMobie;
            CustomerMessage = customerMobie;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        public Bill(int id,string customeName, string customerAddress, string customerMobie, string customerMessage,
        BillStatus billStatus, PaymentMethod paymentMethod, Status status, string customerId
        )
        {
            Id = id;
            CustomerName = customeName;
            CustomerAddress = customerAddress;
            CustomerMobie = customerMobie;
            CustomerMessage = customerMobie;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
            CustomerId = customerId;
        }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { get; set;}
            
        public PaymentMethod PaymentMethod {  get; set; }
        public BillStatus BillStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [DefaultValue(Status.Active)]
        public Status Status { get; set; } = Status.Active;

        [StringLength(450)]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobie { get; set; }

        [ForeignKey("CustomerId")]
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; } 
    }
}
