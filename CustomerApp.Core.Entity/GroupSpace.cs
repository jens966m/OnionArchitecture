using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.Entity
{
    public class GroupSpace
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string DatabaseConnectionString { get; set; }
        public List<User> Users { get; set; }
    }
}
