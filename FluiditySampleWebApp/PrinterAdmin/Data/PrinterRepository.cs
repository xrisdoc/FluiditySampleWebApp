using Fluidity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fluidity;
using System.Linq.Expressions;
using Umbraco.Core.Models;
using FluiditySampleWebApp.PrinterAdmin.Entities;
using FluiditySampleWebApp.PrinterAdmin.Data;

namespace FluiditySampleWebApp.PrinterAdmin.Data
{
    public class PrinterRepository : FluidityRepository<Printer, int>
    {
        private readonly PrinterAdminDbContext _db;

        public PrinterRepository()
        {
            _db = new PrinterAdminDbContext();
        }

        protected override void DeleteImpl(int id)
        {
            var printer = _db.Printers.SingleOrDefault(x => x.Id == id);
            if(printer != null)
            {
                _db.Printers.Remove(printer);
                _db.SaveChanges();
            }
        }

        protected override IEnumerable<Printer> GetAllImpl()
        {
            return _db.Printers.ToList();
        }

        protected override int GetIdImpl(Printer entity)
        {
            return entity.Id;
        }

        protected override Printer GetImpl(int id)
        {
            return _db.Printers.FirstOrDefault(x => x.Id == id);
        }

        protected override PagedResult<Printer> GetPagedImpl(int pageNumber, int pageSize, Expression<Func<Printer, bool>> whereClause, Expression<Func<Printer, object>> orderBy, SortDirection orderDirection)
        {
            var entities = _db.Printers.ToList();
            var result = new PagedResult<Printer>(entities.Count(), pageNumber, pageSize);
            result.Items = entities;
            return result;
        }

        protected override long GetTotalRecordCountImpl()
        {
            return _db.Printers.Count();
        }

        protected override Printer SaveImpl(Printer entity)
        {
            if(entity.Id <= 0)
            {
                _db.Printers.Add(entity);
                _db.SaveChanges();
                return entity;
            }
            else
            {
                var printer = _db.Printers.SingleOrDefault(x => x.Id == entity.Id);

                printer.Name = entity.Name;
                printer.FriendlyName = entity.FriendlyName;
                printer.IpAddress = entity.IpAddress;

                _db.SaveChanges();
                return printer;
            }
        }
    }
}