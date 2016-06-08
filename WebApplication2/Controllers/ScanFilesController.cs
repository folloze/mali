
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using bxMSCLIScanner;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace ScanFilesBuffer.Controllers
{
    
    [RoutePrefix("api")]
    public class ScanFilesController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Route("scans")]
        [HttpPost]

        public HttpResponseMessage ScanFromUrl()
        {
            string filepath = Request.RequestUri.Query.Replace("?filepath=", "");
            string guid = Guid.NewGuid().ToString();
            WebApplication2.ApplicationSettings settings = (WebApplication2.ApplicationSettings)System.Configuration.ConfigurationManager.GetSection("folloze/url");

            ScanExecuter scan = new ScanExecuter();
            string info_message = string.Format("Incoming file path: {0} ...", filepath);
            log.Info(info_message);

            Task task = new Task(() => scan.execute(filepath, guid, settings.path));
            task.Start();

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(guid, System.Text.Encoding.UTF8, "text/plain");
            return resp;
        }

    }
}