using System;
using System.Collections.Generic;
using System.Text;

namespace Bileti.Domain.Models
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public virtual BiletUser Owner { get; set; }

        public virtual ICollection<BiletInShoppingCart> BiletInShoppingCarts { get; set; }

    }
}
