using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebJobChollometro.Data;
using WebJobChollometro.Models;

namespace WebJobChollometro.Repositories
{
    public class RepositoryChollos
    {
        private readonly ChollometroContext chollometroContext;

        public RepositoryChollos(ChollometroContext chollometroContext)
        {
            this.chollometroContext = chollometroContext;
        }

        private async Task<int> GetMaxChollos()
        {
            int max = 1;

            if (await this.chollometroContext.Chollos.AnyAsync())
            {
                max = await this.chollometroContext.Chollos.MaxAsync(x => x.IdChollo) + 1;
            }

            return max;
        }

        public Task<List<Chollo>> GetCHollos()
        {
            return this.chollometroContext.Chollos.ToListAsync();
        }

        private async Task<List<Chollo>> GetChollosWebAsync()
        {
            string url = "https://www.chollometro.com/rss";

            //HttpClient client = new();

            //var request = new HttpRequestMessage()
            //{
            //    RequestUri = new Uri(url),
            //};

            //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(@"text/html application/xhtml+xml, *.*"));
            //request.Headers.Host = "www.chollometro.com";
            ////request.Headers.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";


            //var task = client.SendAsync(request)
            //.ContinueWith((taskwithmsg) =>
            //{
            //    var response = taskwithmsg.Result;

            //    var jsonTask = response.Content.ReadAsAsync<JsonObject>();
            //    jsonTask.Wait();
            //    var jsonObject = jsonTask.Result;
            //});
            //task.Wait();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = @"text/html application/xhtml+xml, *.*";
            request.Referer = "https://www.chollometro.com/";
            request.Headers.Add("Accept-Language", "ES-es");
            request.Host = "www.chollometro.com";
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string xmlData = "";
            using (StreamReader reader = new(response.GetResponseStream()))
            {
                xmlData = await reader.ReadToEndAsync();
            }

            XDocument document = XDocument.Parse(xmlData);

            int idChollo = await this.GetMaxChollos();

            var consulta = from datos in document.Descendants("item")
                           select new Chollo
                           {
                               Titulo = datos.Element("title").Value,
                               Link = datos.Element("link").Value,
                               Descripcion = datos.Element("description").Value,
                               Fecha = DateTime.Now,
                               IdChollo = idChollo += 1
                           };
            return consulta.ToList();
        }

        public async Task PopulateChollosAsync()
        {
            List<Chollo> chollos = await this.GetChollosWebAsync();
            await this.chollometroContext.Chollos.AddRangeAsync(chollos);
            await this.chollometroContext.SaveChangesAsync();
        }
    }
}
