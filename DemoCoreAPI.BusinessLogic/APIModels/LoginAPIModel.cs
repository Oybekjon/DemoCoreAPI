﻿using DemoCoreAPI.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.ViewModels
{
    public class LoginApiModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Roles Role { get; set; }
    }
}
