using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAIBCCI.Controllers
{
    [RoutePrefix("api/series")]
    public class SeriesController : ApiController
    {


        private BCCIEntities1 db = new BCCIEntities1();


        // GET: api/Series
        [HttpGet]
        [Route("")]
       public IEnumerable<Serieswinsoft> Get()
        {
            return db.Serieswinsofts.ToList();
        }

        // GET: api/Series/5
        [HttpGet]
        [Route("{id:int}")]
        public Serieswinsoft Get(int id)
        {
            return db.Serieswinsofts.FirstOrDefault(s => s.SeriesId == id);
        }

        // POST: api/Series
        [HttpPost]
        [Route("")]
        public void Post([FromBody] Serieswinsoft series)
        {
            db.Serieswinsofts.Add(series);
            db.SaveChanges();
        }


        // PUT: api/Series/5
        [HttpPut]
        [Route("{id:int}")]
        public void Put(int id, [FromBody] Serieswinsoft series)
        {
            var existingSeries = db.Serieswinsofts.FirstOrDefault(s => s.SeriesId == id);
            if (existingSeries != null)
            {
                existingSeries.SeriesName = series.SeriesName;
                db.SaveChanges();
            }
        }



        // DELETE: api/Series/5
        [HttpDelete]
        [Route("{id:int}")]
        public void Delete(int id)
        {
            var series = db.Serieswinsofts.FirstOrDefault(s => s.SeriesId == id);
            if (series != null)
            {
                db.Serieswinsofts.Remove(series);
                db.SaveChanges();
            }
        }


    }




}
