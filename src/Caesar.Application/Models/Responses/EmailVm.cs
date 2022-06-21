using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar.Application.Models.Responses
{
    public class EmailVm
    {
        public Guid Id { get; set; }

        public string EmailValue { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
