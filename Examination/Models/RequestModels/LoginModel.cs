﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examination.Models.RequestModels
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}