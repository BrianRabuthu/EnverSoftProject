
using Enversoft.DataObject;
using Enversoft.DataObject;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DataObject
{
    public class SupplierDataAcess
    {

        private EnversoftEntities db;

        public SupplierDataAcess()
        {
            this.db = new EnversoftEntities();
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            return this.db.tb_Supplier;
        }

        public Supplier GetSupplierByID(int id)
        {
            return this.db.tb_Supplier.Find(id);
        }
        public IQueryable<Supplier> GetSupplierByName(string supplierName)
        {
             var query =
             from supplier in this.db.tb_Supplier
            where supplier.SupplierName.ToLower().Contains(supplierName.ToLower())
             select supplier;
            //      return query;
            return query;
        }

        public int AddSupplier(Supplier supplier)
        {
            this.db.tb_Supplier.Add(supplier);
            return this.Save();
        }

        public void Delete(int id)
        {
            Supplier supplier = this.db.tb_Supplier.Find(id);
            this.db.tb_Supplier.Remove(supplier);
            this.Save();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            this.db.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
        }

        public int Save()
        {
            return this.db.SaveChanges();
        }

    }
}
