using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepositoryDesignPatternInASP.NETMVC.Models
{
    public class CRUDDbContext: DbContext
    {
        public CRUDDbContext() : base("name=CRUDDbEntities")
        {

        }
        public virtual DbSet<Employee> Employees { get; set; }

    }
}