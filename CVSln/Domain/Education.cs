using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Education
    {
        //Education properties
        public int EducationId { get; set; }
        public string SchoolName { get; set; }
        public string EducationType { get; set; }
        public string StudyYears { get; set; }
        public string Programme { get; set; }
        public int OrderNo { get; set; }

        //Navigation properties
        public int CvId { get; set; }
        public Cv Cv { get; set; }
       

    }
}
