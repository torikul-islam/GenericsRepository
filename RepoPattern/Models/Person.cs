﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepoPattern.Models
{
    public class Person
    {

        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Profession { get; set; }

        [Required]
        public string Address { get; set; }
        
    }
}