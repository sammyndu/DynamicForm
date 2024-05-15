using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Data.Entities
{
    public class ApplicationForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone {  get; set; }
        public string? Nationality {  get; set; }
        public string? CurrentResidence {  get; set; }
        public string? IdNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
    }
}
