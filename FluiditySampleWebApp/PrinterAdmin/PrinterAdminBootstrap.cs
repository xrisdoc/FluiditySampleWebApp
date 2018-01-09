using Fluidity.Configuration;
using FluiditySampleWebApp.PrinterAdmin.Data;
using FluiditySampleWebApp.PrinterAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluiditySampleWebApp.PrinterAdmin
{
    public class PrinterAdminBootstrap : FluidityConfigModule
    {
        public override void Configure(FluidityConfig config)
        {
            // Create the Printer Admin section
            config.AddSection("Printer Admin", "icon-print", sectionConfig => {

                // Create the tree for the Printer Admin section
                sectionConfig.SetTree("Printer Admin", treeConfig => {

                    // Create the collection that will hold the Printers that are to be listed
                    treeConfig.AddCollection<Printer>(x => x.Id, "Printer", "Printers", "A collection of printers", "icon-print", "icon-folder", collectionConfig =>
                    {
                        collectionConfig.SetNameFormat(x => { return $"{x.FriendlyName} ({x.IpAddress})"; });
                        collectionConfig.SetRepositoryType<PrinterRepository>();

                        // Create the editor that will allow a user to update the Printer details
                        collectionConfig.Editor(editorConfig => {
                            editorConfig.AddTab("General", tabConfig =>
                            {
                                tabConfig.AddField(x => x.Name, field => {
                                    field.SetLabel("Name")
                                         .SetDescription("Specify the name of the entity that is used internally")
                                         .MakeRequired();
                                });

                                tabConfig.AddField(x => x.FriendlyName, field => {
                                    field.SetLabel("Friendly Name")
                                         .SetDescription("The friendly name of the printer")
                                         .MakeRequired();
                                });

                                tabConfig.AddField(x => x.IpAddress, field => {
                                    field.SetLabel("IP Address")
                                         .SetDescription("The IP Address that the printer can be accessed on")
                                         .MakeRequired();
                                });
                            });
                        });
                    });
                });
            });
        }
    }
}