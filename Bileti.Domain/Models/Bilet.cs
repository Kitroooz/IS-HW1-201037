using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bileti.Domain.Models
{
    public class Bilet : BaseEntity
    {
        [Required]
        public string BiletName { get; set; }

        [Required]
        public string BiletDescription { get; set; }
        [Required]
        public double BiletPrice { get; set; }

        [Required]
        public int BiletCount { get; set; }

        [Required]
        public DateTime BiletDate { get; set; }


        public virtual ICollection<BiletInShoppingCart> BiletInShoppingCarts { get; set; }
        public virtual ICollection<BiletInOrder> BiletInOrders { get; set; }
    }
}
