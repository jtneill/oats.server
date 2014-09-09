using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class OatsServerContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public OatsServerContext() : base("name=OatsServerContext")
    {
    }

	public DbSet<oats.server.Models.Deal> Deals { get; set; }

	public DbSet<oats.server.Models.DealTask> DealTasks { get; set; }

	public DbSet<oats.server.Models.Person> People { get; set; }

}
