﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.BLL.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string PhoneNumber { get; set; }

        public string Token { get; set; }
    }
}
