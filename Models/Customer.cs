using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api_example.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int customerId {get; set;}
        [Column("first_name")]
        public string firstName {get; set;}
        [Column("last_name")]
        public string lastName{get;set;}
        [Column("birth_date")]
        public DateTime birthDate{get;set;}
        [Column("phone")]
        public string phone {get;set;}
        [Column("address")]
        public string address {get;set;}
        [Column("city")]
        public string city {get;set;}
        [Column("state")]
        public string state {get;set;}
        [Column("points")]
        public int points {get; set;}

        public ICollection<Order> Orders{get;set;}
    }
}