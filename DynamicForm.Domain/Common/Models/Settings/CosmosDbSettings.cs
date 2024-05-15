using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Domain.Common.Models.Settings
{
    public class CosmosDbSettings
    {
        public string DatabaseName { get; set; }
        public string Primarykey { get; set; }
        public string EndpointUri { get; set; }
    }
}
