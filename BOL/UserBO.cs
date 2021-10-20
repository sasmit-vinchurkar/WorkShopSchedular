using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UserBO
    {
        public int? UserID { get; set; }
        public string UserNameEmail { get; set; }
        public string  Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserGender { get; set; }
        public string Mobile { get; set; }
        public int? IsActive { get; set; }
        public DateTime? UserDOB { get; set; }
        public string SkillsSet { get; set; }
        public string Experience { get; set; }
        public int? RoleID { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }



    }
}
