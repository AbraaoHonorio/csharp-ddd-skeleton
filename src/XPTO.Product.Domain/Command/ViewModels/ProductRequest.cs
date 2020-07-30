using System;
using System.Collections.Generic;
using System.Text;

namespace XPTO.Product.Domain.Command.ViewModels
{
   public class ProductPostRequest
    {
        public int StockBalance { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public Guid Id { get; set; }
    }
}
