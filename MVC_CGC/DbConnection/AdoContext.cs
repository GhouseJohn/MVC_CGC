using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC_CGC.Models;

namespace MVC_CGC.DbConnection
{
    public class AdoContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedbackForm>().ToTable("FeedbackForm");
        }
        public DbSet<FeedbackForm> FeedbackForm { get; set; }
    }
}