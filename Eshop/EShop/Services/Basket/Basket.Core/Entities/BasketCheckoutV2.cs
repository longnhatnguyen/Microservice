using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entities
{
    public class BasketCheckoutV2
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
