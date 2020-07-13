using Enversoft.BusinessLogic;
using Enversoft.DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Enversoft.UI.Controllers
{
    [RoutePrefix("api")]
    public class SupplierController : ApiController
    {
        SupplierBusLogic supplierBusLogic = new SupplierBusLogic();

        [HttpGet]
        [Route("suppliers")]
        public HttpResponseMessage GetSuppliers()
        {
            try
            {
                var data =  supplierBusLogic.GetAllSuppliers();
                if (data.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    string message = string.Format("No Suppliers found on databse.");
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("suppliers")]
        public HttpResponseMessage GetSupplierByName(string Name)
        { 
            try
            {
                var data = supplierBusLogic.GetSupplierByName(Name);
                if (data.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);              
                }
                else
                {
                    string message = string.Format("No Suppliers containing {0} found.", Name);
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("suppliers")]
        public HttpResponseMessage AddSupplier(Supplier data)
        {
            try
            {
                var result = supplierBusLogic.AddSupplier(data);
                if (result > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    string message = string.Format("Error saving details.");
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
