using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ask.Models.DbModels
{
    public class Tag
    {
        public long TagId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
