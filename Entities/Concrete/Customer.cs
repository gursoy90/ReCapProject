using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:User,IEntity
    {
        public int CustomerId { get; set; }
        
        public string CustomerName { get; set; }
    }
}
