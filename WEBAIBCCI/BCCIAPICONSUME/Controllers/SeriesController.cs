using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WEBAIBCCI;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Text;

namespace BCCIAPICONSUME.Controllers
{
    public class SeriesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44360/api");



        HttpClient client;

        public SeriesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
;
        }


        [HttpGet]
        // GET: Series
        public ActionResult Index()
        {
            List<Serieswinsoft> modellist = new List<Serieswinsoft>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/series").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modellist = JsonConvert.DeserializeObject<List<Serieswinsoft>>(data);
            }
            return View(modellist);

        }



        [HttpGet]
        public ActionResult Details(int id,Serieswinsoft serieswinsoft)
        {

            List<Matchwinsoft> modellist = new List<Matchwinsoft>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/match?SeriesId="+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modellist = modellist.Where(m => m.SeriesId == id).ToList();

                modellist = JsonConvert.DeserializeObject<List<Matchwinsoft>>(data);
            }
            return View(modellist);

        }



        // GET: Series/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Serieswinsoft series)
        {
            HttpResponseMessage response = client.PostAsJsonAsync("api/series", series).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the error
                return View("Error");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/series/{id}");
            if (response.IsSuccessStatusCode)
            {
                var series = await response.Content.ReadAsAsync<Serieswinsoft>();
                return View(series);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Series/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Serieswinsoft series)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/series/{id}", series);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }


        public ActionResult Delete(int id)
        {

            //Serieswinsoft model = new Serieswinsoft();
            List<Serieswinsoft> seriesList = new List<Serieswinsoft>();


            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/series?SeriesId=" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                //model = JsonConvert.DeserializeObject<Serieswinsoft>(data);
                seriesList = JsonConvert.DeserializeObject<List<Serieswinsoft>>(data);

            }

            return View(seriesList);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult ConfirmDeleteDelete(int id)
        {

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/series/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }







    }
}