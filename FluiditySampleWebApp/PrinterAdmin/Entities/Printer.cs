using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace FluiditySampleWebApp.PrinterAdmin.Entities
{
    public class Printer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string IpAddress { get; set; }
    }

    [TableName("Printer")]
    public class PrinterPoco
    {
        [PrimaryKeyColumn]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public string IpAddress { get; set; }
    }
}