﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SkillExtra
    {
        //Properties
        
        public string Name { get; set; }
        public string Content { get; set; }

        //Navigation Properties
        public int CvId { get; set; }
        public Cv Cv { get; set; }

    }
}
