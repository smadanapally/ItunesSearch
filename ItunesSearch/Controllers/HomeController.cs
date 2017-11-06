    using ItunesSearch.Bll.DTO;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;
    using System.Web.Mvc;

    namespace ItunesSearch.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
        /* This action method takes the search string from the index view and searches the term using the Itunes api */
            [HttpGet]
            public ActionResult Search(String searchTerm)
            {

                try
                {
                    SearchResult releases = new SearchResult();
                    String actual_url = "https://itunes.apple.com/search?term=";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(actual_url + searchTerm);

                    request.Method = "GET";
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 58.0.3029.110 Safari / 537.36";
                    request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                    request.ContentType = "application/json";
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    string content = string.Empty;
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(stream))
                        {
                            content = sr.ReadToEnd();
                        }
                    }

                    releases = JsonConvert.DeserializeObject<SearchResult>(content);
                    return View(releases);
                }
                catch(Exception ex) {
                    throw ex;
                }
            }
         /* This action method takes the result object from the view when any result is clicked, it check with the database if the result already exists, if yes it increases
          the click counter. If no it adds a new record to the database.*/
            public ActionResult UpdateAndRedirect(SearchResultDTO x )
            {
         
                var bll = new Bll.Bll();
                var searchReturn = bll.GetSearchCount(x.TrackId);
                if ( searchReturn != null)
                {
                    bll.UpdateCounter(searchReturn.Id, searchReturn.ClickCount);
                }
                else
                {
                    string ip = Request.UserHostAddress;
                    string useragent = Request.Browser.Type;
                    x.UserIP = ip;
                    x.UserAgent = useragent;
                    bll.AddSearchResult(x);
                }
                return Json(new { Success = true, ErrorMessage = "Done" }, JsonRequestBehavior.AllowGet);
            }
        /* This controller action method gets the click count data from the database. It returns top 25 records ordered by click count */
            public ActionResult ViewClickCount()
            {
                var bll = new Bll.Bll();           
                return View(bll.GetClickData());
            }
        }
    }