﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination.Models.RequestModels
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public int DepartmentId { get; set; }
    }
}