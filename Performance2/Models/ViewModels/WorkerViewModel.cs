using System;
using System.Collections.Generic;
using Performance2.Services.DTO;
using System.Linq;

namespace Performance2.Models.ViewModels
{
    public class WorkerViewModel
    {
        public IEnumerable<PersonDto> Workers { get; set; }
    }
}
