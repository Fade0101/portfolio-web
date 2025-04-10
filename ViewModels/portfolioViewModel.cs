﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class portfolioViewModel
    {
        public int id { get; set; }
        public string projectName { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public IFormFile file { get; set; }
    }
}