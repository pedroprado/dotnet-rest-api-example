using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_example.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("order_id")]
        public int? orderId {get; set;}
        [Column("customer_id")]
        public int? customerId {get; set;}
        [Column("order_date")]
        public DateTime? orderDate {get; set;}
        [Column("status")]
        public int? status {get; set;}
        [Column("comments")]
        public string comments {get;set;}
        [Column("shipped_date")]
        public DateTime? shippedDate {get;set;}
        [Column("shipper_id")]
        public int? shipperId {get;set;}

        public Customer Customer{get;set;}
    }


}