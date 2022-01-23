using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string ImageURL { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
