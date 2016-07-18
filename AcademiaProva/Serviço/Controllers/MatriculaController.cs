using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Serviço.Controllers
{
    public class MatriculaController : ApiController
    {
        public IEnumerable<Models.Matricula> Get()
        {
            Models.AcademiaDataContext dc = new Models.AcademiaDataContext();
            var r = from f in dc.Matriculas select f;
            return r.ToList();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            
            Models.AcademiaDataContext dc = new Models.AcademiaDataContext();

            int maxM, maxP;
            if (dc.Matriculas.Count() == 0) maxM = 1;
            else maxM = dc.Matriculas.Max(x => x.Id) + 1;
            if (dc.Parcelas.Count() == 0) maxP = 1;
            else maxP = dc.Parcelas.Max(x => x.Id) + 1;

            Models.Matricula m = JsonConvert.DeserializeObject<Models.Matricula>(value);
            m.Id = maxM;
            dc.Matriculas.InsertOnSubmit(m);

            switch(m.Pacote)
            {
                case fiqueFortinho
                    break;
                case fiqueforte
                    break;
                case  fiquefortao
                    break;
            }

            List<Models.Matricula> r = JsonConvert.DeserializeObject<List<Models.Matricula>>(value);

            dc.Matriculas.InsertAllOnSubmit(r);
            dc.SubmitChanges();

        }
    }
}
