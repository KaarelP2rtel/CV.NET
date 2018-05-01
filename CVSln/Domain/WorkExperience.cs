using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class WorkExperience
    {
        //WorkExperience properties
        public int WorkExperienceId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string WorkYears { get; set; }

        //Navigation Properties
        public int CvId { get; set; }
        public Cv Cv { get; set; }


    }
}
