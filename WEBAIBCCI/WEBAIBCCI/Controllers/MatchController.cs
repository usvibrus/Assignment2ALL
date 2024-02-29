using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEBAIBCCI.Controllers
{
    [RoutePrefix("api/Match")]
    public class MatchController : ApiController
    {

     

            private BCCIEntities1 db = new BCCIEntities1();


            // GET: api/Match
            [HttpGet]
            [Route("")]
            public IEnumerable<Matchwinsoft> Get()
            {
            return db.Matchwinsofts.ToList();
            }


            // GET: api/Match/5
            [HttpGet]
            [Route("{id:int}")]
            public Matchwinsoft Get(int id)
            {
                return db.Matchwinsofts.FirstOrDefault(m => m.MatchId == id);
            }


            // POST: api/Match
            [HttpPost]
            [Route("")]
            public void Post([FromBody] Matchwinsoft match)
            {
                db.Matchwinsofts.Add(match);
                db.SaveChanges();
            }


            // PUT: api/Match/5
            [HttpPut]
            [Route("{id:int}")]
            public void Put(int id, [FromBody] Matchwinsoft match)
            {
                var existingMatch = db.Matchwinsofts.FirstOrDefault(m => m.MatchId == id);
                if (existingMatch != null)
                {
                    existingMatch.SeriesId = match.SeriesId;
                    existingMatch.MatchName = match.MatchName;
                    existingMatch.MatchDate = match.MatchDate;
                    db.SaveChanges();
                }
            }

            // DELETE: api/Match/5
            [HttpDelete]
            [Route("{id:int}")]
            public void Delete(int id)
            {
                var match = db.Matchwinsofts.FirstOrDefault(m => m.MatchId == id);
                if (match != null)
                {
                    db.Matchwinsofts.Remove(match);
                    db.SaveChanges();
                }
            }

       
        
    }
}
