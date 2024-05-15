using SampleForms.Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Domain.Common.Dtos
{
    public class CandidateAnswerDto
    {
        public string QuestionId { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public QuestionType FieldType { get; set; }
    }
}
