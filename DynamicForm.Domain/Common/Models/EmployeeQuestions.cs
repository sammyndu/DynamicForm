using Newtonsoft.Json;
using SampleForms.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Domain.Common.Models
{
    public class EmployeeQuestions
    {
        public EmployeeQuestions()
        {
            this.Options = [];
        }
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("formCategory")]
        public FormCategory FormCategory { get; set; }

        [JsonProperty("fieldName")]
        public string FieldName { get; set; }

        [JsonProperty("fieldType")]
        public QuestionType FieldType { get; set; }

        [JsonProperty("isRequired")]
        public bool IsRequired { get; set; }

        [JsonProperty("isInternal")]
        public bool IsInternal { get; set; }

        [JsonProperty("isHidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("options")]
        public List<string> Options { get; set; }

        [JsonProperty("maxNumberOfOptions")]
        public int MaxNumberOfOptions { get; set; }

    }
}
