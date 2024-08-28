﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entity.Concretes
{
    public class Cart
    {
      
        public List<CartLine>? Lines { get; set; }
         public Cart()
        {
           Lines=new List<CartLine>();
        }
 public decimal Total
        {
            get { return (decimal)Lines.Sum(c => c.Quantity * c.Product.UnitPrice); }
        }
    }
}
