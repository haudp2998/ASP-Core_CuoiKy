﻿using System;
using System.Collections.Generic;

namespace ASP_Core_CuoiKy.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool? Status { get; set; }
    }
}
