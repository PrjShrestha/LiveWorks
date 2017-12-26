// ======================================
// Author: liveworks  
// Email:  info@liveworks.com
// Copyright (c) 2017 www.liveworks.com
// 
// ==> Gun4Hire: contact@liveworks.com
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Models
{
    public class ProductCategory : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
