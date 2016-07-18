using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serviço.Controllers
{
    public class ParcelaController : ApiController
    {

        public IEnumerable<Models.Parcela> Get()
        {
            Models.AcademiaDataContext dc = new Models.AcademiaDataContext();
            var r = from f in dc.Parcelas select f;
            return r.ToList();
        }

        public void Put(int id, [FromBody]string value)
        {
            Models.Parcela x = JsonConvert.DeserializeObject<Models.Parcela>(value);
            Models.AcademiaDataContext dc = new Models.AcademiaDataContext();
            Models.Parcela rest = (from f in dc.Parcelas where f.Id == id select f).Single();
            rest.Pago = rest.Valor.Value;
            dc.SubmitChanges();
        }
    }
}
