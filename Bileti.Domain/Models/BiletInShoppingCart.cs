using System;
using System.Collections.Generic;
using System.Text;

namespace Bileti.Domain.Models
{
    public class BiletInShoppingCart : BaseEntity
    {
        public Guid BiletId { get; set; }
        public virtual Bilet CurrnetProduct { get; set; }

        public Guid ShoppingCartId { get; set; }
        public virtual ShoppingCart UserCart { get; set; }

        public int Quantity { get; set; }
    }
}
