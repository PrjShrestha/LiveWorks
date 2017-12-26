// ======================================
// Author: liveworks  
// Email:  info@liveworks.com
// Copyright (c) 2017 www.liveworks.com
// 
// ==> Gun4Hire: contact@liveworks.com
// ======================================

using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Interfaces
{
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
