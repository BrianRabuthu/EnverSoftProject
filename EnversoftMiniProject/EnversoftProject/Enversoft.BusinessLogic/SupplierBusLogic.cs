using Enversoft.DataObject;
using Enversoft.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.BusinessLogic
{
    public class SupplierBusLogic
    {

        private SupplierDataAcess objDb;

        public SupplierBusLogic()
        {
            this.objDb = new SupplierDataAcess();
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return this.objDb.GetAllSuppliers();
        }

        public Supplier GetSupplierByID(int id)
        {
            return this.objDb.GetSupplierByID(id);
        }
        public IQueryable<Supplier> GetSupplierByName(string supplierName)
        {
            return this.objDb.GetSupplierByName(supplierName);
        }

        public int AddSupplier(Supplier supplier)
        {
           return this.objDb.AddSupplier(supplier);
        }

        public void Delete(int id)
        {
            this.objDb.Delete(id);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            this.objDb.UpdateSupplier(supplier);
        }

    }
}
