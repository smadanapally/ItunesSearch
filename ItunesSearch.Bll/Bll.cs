using ItunesSearch.Bll;
using ItunesSearch.Bll.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
/*
    This class is used for all the DB Operations involved in the project.
    Add new result records to the Database, Updating the click counter.    
*/

namespace ItunesSearch.Bll
{
    public class Bll
    {
        public DTO.SearchResultDTO GetSearchCount(string TrackId)
        {
            try
            {
                using (Models.EnterpriseContext db = new Models.EnterpriseContext())
                {
                    var searchCount = db.SearchResultCounters
                        .Where(x => x.TrackId == TrackId).ToList();

                    if (searchCount.Any())
                    {
                        DTO.SearchResultDTO search = new DTO.SearchResultDTO();
                        search.Id = searchCount.FirstOrDefault().Id;
                        search.TrackId = searchCount.FirstOrDefault().TrackId;
                        search.TrackName = searchCount.FirstOrDefault().TrackName;
                        search.ArtistName = searchCount.FirstOrDefault().ArtistName;
                        search.Category = searchCount.FirstOrDefault().Category;
                        search.ClickCount = searchCount.FirstOrDefault().ClickCount;
                        search.UserIP = searchCount.FirstOrDefault().UserIP;
                        search.UserAgent = searchCount.FirstOrDefault().UserAgent;
                        search.RowCreateTS = searchCount.FirstOrDefault().RowCreateTS;
                        search.RowMaintainedTS = searchCount.FirstOrDefault().RowMaintainedTS;

                        return search;
                    }
                    else
                    {
                        return null;
                    }


                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<DTO.SearchResultDTO> GetClickData()
        {
            try
            {
                using (var db = new Models.EnterpriseContext())
                {
                    List<DTO.SearchResultDTO> lview = new List<DTO.SearchResultDTO>();
                    var searchView = db.SearchResultCounters
                        .OrderByDescending(x => x.ClickCount).Take(25);
                    foreach (var x in searchView)
                    {
                        SearchResultDTO search = new SearchResultDTO();
                        search.Id = x.Id;
                        search.TrackId = x.TrackId;
                        search.TrackName = x.TrackName;
                        search.ArtistName = x.ArtistName;
                        search.Category = x.Category;
                        search.ClickCount = x.ClickCount;
                        search.UserIP = x.UserIP;
                        search.UserAgent = x.UserAgent;
                        search.RowCreateTS = x.RowCreateTS;
                        search.RowMaintainedTS = x.RowMaintainedTS;
                        lview.Add(search);
                    }
                    return lview;

                }

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public void UpdateCounter(long id, long clickCount)
        {
            try
            {
                using (var cntxt = new Models.EnterpriseContext())
                {
                    var cupdate = new Models.SearchResultDTO
                    {
                        Id = id,
                        ClickCount = clickCount + 1,
                        RowMaintainedTS = DateTime.Now
                    };

                    cntxt.SearchResultCounters.Attach(cupdate);
                    cntxt.Entry(cupdate).Property(x => x.ClickCount).IsModified = true;
                    cntxt.Entry(cupdate).Property(x => x.RowMaintainedTS).IsModified = true;
                    cntxt.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddSearchResult(DTO.SearchResultDTO abs)
        {
            try
            {
                using (var context = new Models.EnterpriseContext())
                {
                    var addRecord = new Models.SearchResultDTO
                    {
                        TrackId = abs.TrackId,
                        TrackName = abs.TrackName,
                        ArtistName = abs.ArtistName,
                        Category = abs.Category,
                        UserAgent = abs.UserAgent,
                        UserIP = abs.UserIP,
                        ClickCount = 1,
                        RowCreateTS = DateTime.Now,
                        RowMaintainedTS = DateTime.Now
                    };

                    context.SearchResultCounters.Add(addRecord);
                    context.SaveChanges();

                }


            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
