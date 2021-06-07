﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{

    public class Crew
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
      
        public string ProfilePath { get; set; }

        public ICollection<MovieCrew> MovieCrews { get; set; }

    }
}
