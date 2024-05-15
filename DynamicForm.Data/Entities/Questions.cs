using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Entities
{
    public class Questions
    {
        public string Category { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }

        public List<string> Options { get; set; }
        public int MaxNumberOfOptions { get; set; }
        public bool YesNoChoice { get; set; }
    }
}
