﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public int RentalId { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; }
        public string CustomerName { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
        public double TotalPrice { get; set; }


    }
}
