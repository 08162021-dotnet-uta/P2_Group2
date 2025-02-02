﻿using System;
using System.Collections.Generic;

#nullable disable

namespace NotFightClub_Models.Models
{
    public partial class Location
    {
        public Location()
        {
            Fights = new HashSet<Fight>();
        }

        public int LocationId { get; set; }
        public string Location1 { get; set; }

        public virtual ICollection<Fight> Fights { get; set; }
    }
}
