using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DbCrud.Models
{
    public partial class Customer
    {
        [Key]
        [Column("CustomerID")]
        [StringLength(15)]
        public string CustomerId { get; set; }
        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(75)]
        public string LastName { get; set; }
        [StringLength(500)]
        public string PhotoUrl { get; set; }
        [StringLength(50)]
        [Required]
        public string PhoneNo { get; set; }

        [StringLength(75)]
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="E-mail is not valid")]
        public string EmailId { get; set; }
    }
}
