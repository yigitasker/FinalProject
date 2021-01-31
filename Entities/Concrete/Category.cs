using Entities.Abstract;                     // burdan bilgi alıyorum demek IEntity burdan geliyor.
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    // çıplak class kalmasın 
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
