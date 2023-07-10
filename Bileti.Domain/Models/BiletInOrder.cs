using System;
using System.Collections.Generic;
using System.Text;

namespace Bileti.Domain.Models
{
    public class BiletInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public Guid BiletId { get; set; }
        public Bilet Bilet { get; set; }
        public int Quantity { get; set; }
    }
}
