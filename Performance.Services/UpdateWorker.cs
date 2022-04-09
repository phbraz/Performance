using Performance2.Services.DTO;
using Performance2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performance2.Services
{
    public class UpdateWorker
    {
        public IEnumerable<PersonDto> UpdateUserName()
        {
            var DbContext = new AdventureWorks2019Context();

            var newWorkersUserName = DbContext.Employees.Join(
                DbContext.Persons,
                employees => employees.BusinessEntityId,
                persons => persons.BusinessEntityId,
                (employees, persons) => new PersonDto
                {
                    FirstName = persons.FirstName,
                    LastName = persons.LastName,
                    LoginID = @"Super\" + persons.FirstName + persons.LastName,
                    JobTitle = employees.JobTitle
                }
                ).Where(employees => employees.JobTitle.Contains("Production"));

            return newWorkersUserName;

            
        }
    }
}
