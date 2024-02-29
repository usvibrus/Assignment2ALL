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

namespace BCCIAPICONSUME.Controllers
{
    public class MatchController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:44360/api");



        HttpClient client;

        public MatchController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            
        }

        // POST: Match/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Matchwinsoft series)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/match", series);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }


        // GET: Match/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/matches/{id}");
            if (response.IsSuccessStatusCode)
            {
                var match = await response.Content.ReadAsAsync<Matchwinsoft>();
                return View(match);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: Match/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Matchwinsoft match)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/matches/{id}", match);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync($"api/series/{id}").Result;
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


    }
}