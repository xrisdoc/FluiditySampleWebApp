using FluiditySampleWebApp.PrinterAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace FluiditySampleWebApp.PrinterAdmin.Data
{
    public class PrinterAdminDbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<PrinterAdminDbContext>
    {
        protected override void Seed(PrinterAdminDbContext context)
        {
            var printers = new List<Printer>
            {
                new Printer { Name = "SamsungPrinter1", FriendlyName= "Samsung Printer ", IpAddress = "192.168.0.91" },
                new Printer { Name = "KyoceraPrinter1", FriendlyName= "Kyocera Printer", IpAddress = "192.168.0.92" },
                new Printer { Name = "HPOfficePrinter", FriendlyName= "HP Office Printer", IpAddress = "192.168.0.93" },
                new Printer { Name = "HPDespatchPrinter", FriendlyName= "HP Despatch Printer", IpAddress = "192.168.0.94" },
            };

            printers.ForEach(p => context.Printers.Add(p));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}