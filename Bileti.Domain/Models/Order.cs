using System;
using System.Collections.Generic;
using System.Text;

namespace Bileti.Domain.Models
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public BiletUser User { get; set; }

        public virtual ICollection<BiletInOrder> BiletInOrders { get; set; }
    }
}
