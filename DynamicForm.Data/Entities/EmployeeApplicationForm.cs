using DynamicForm.Domain.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Entities
{
    public class EmployeeApplicationForm
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("programTitle")]
        public string ProgramTitle { get; set; }

        [JsonProperty("programDescription")]
        public string ProgramDescription { get; set; }

        [JsonProperty("questions")]
        public List<EmployeeQuestions> Questions { get; set; } = [];

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("dateModified")]
        public DateTime DateModified { get; set; }
    }
}
