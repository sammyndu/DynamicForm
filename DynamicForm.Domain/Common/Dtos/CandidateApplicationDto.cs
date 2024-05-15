using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Domain.Common.Dtos
{
    public class CandidateApplicationDto
    {
        public string ProgamId { get; set; }
        public List<CandidateAnswerDto> Answers { get; set; }
    }
}
