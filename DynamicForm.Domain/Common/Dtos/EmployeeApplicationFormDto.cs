using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicForm.Domain.Common.Models;
using Newtonsoft.Json;

namespace DynamicForm.Domain.Common.Dtos
{
    public class EmployeeApplicationFormDto
    {
        [JsonProperty("programTitle")]
        public string ProgramTitle { get; set; }

        [JsonProperty("programDescription")]
        public string ProgramDescription { get; set; }

        [JsonProperty("questions")]
        public List<EmployerQuestionsDto> Questions { get; set; }
    }
}
