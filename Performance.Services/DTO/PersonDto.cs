using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Performance2.Data.Models;

namespace Performance2.Services.DTO
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginID { get; set; }
        public string JobTitle { get; set; }
        public ICollection<Employee> employees { get; set; }
    }
}
