using DynamicForm.Domain.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Domain.Common.Dtos
{
    public class UpdateEmployerApplicationFormDto
    {
        [JsonProperty("programTitle")]
        public string ProgramTitle { get; set; }

        [JsonProperty("programDescription")]
        public string ProgramDescription { get; set; }

        [JsonProperty("questions")]
        public List<EmployeeQuestions> Questions { get; set; }
    }
}
