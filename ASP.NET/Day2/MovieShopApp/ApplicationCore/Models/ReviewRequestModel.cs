﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
    public class ReviewRequestModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public double Rating { get; set; }
    }
}
