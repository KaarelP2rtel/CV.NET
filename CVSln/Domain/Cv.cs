using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cv
    {
        //Cv Properties
        public int CvId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageLink { get; set; }

        //Navigation properties
        public List<Education> Educations { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }
        public List<Skill> Skills { get; set; }




    }
}
