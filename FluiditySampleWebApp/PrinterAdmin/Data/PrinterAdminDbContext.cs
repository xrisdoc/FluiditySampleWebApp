using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using FluiditySampleWebApp.PrinterAdmin.Entities;

namespace FluiditySampleWebApp.PrinterAdmin.Data
{
    public class PrinterAdminDbContext : DbContext
    {
        public PrinterAdminDbContext()
            : base("PrinterAdminDb")
        {
            //InitializeDatabase();
        }

        protected virtual void InitializeDatabase()
        {
            if (!Database.Exists())
            {
                Database.Initialize(true);
                //new PrinterAdminDbInitializer().Seed(this);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Printer>().Property(x => x.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Printer>().Property(x => x.FriendlyName).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Printer>().Property(x => x.IpAddress).HasMaxLength(15).IsRequired();
        }

        public virtual DbSet<Printer> Printers { get; set; }
    }
}