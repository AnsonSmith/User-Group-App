using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToTwitter;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var twitterCtx = new TwitterContext();

            var queryResults =
                from search in twitterCtx.Search
                where search.Type == SearchType.Search &&
                      search.Query == "HubCityNug"
                select search;

            var queryResult = queryResults.SingleOrDefault();

            foreach (var entry in queryResult.Entries)
            {
                var statusID = entry.ID.Substring(entry.ID.LastIndexOf(":") + 1);

                var status =
                    (from tweet in twitterCtx.Status
                     where tweet.Type == StatusType.Show &&
                           tweet.ID == statusID
                     select tweet)
                     .SingleOrDefault();

                Console.WriteLine(
                    "ID: {0}, User: {1}\nTweet: {2}\nPicUrl: {3}",
                    status.ID, status.User.Name, status.Text, status.User.ProfileImageUrl);
            }

            foreach (var search in queryResults)
            {
                Console.WriteLine("\nQuery:\n" + search.Title);

                foreach (var entry in search.Entries)
                {
                    Console.WriteLine(
                        "ID: {0}, As of: {1}\nContent: {2}\n",
                        entry.ID, entry.Updated, entry.Content);
                }
            }

            var srch = queryResults.SingleOrDefault();

            Console.WriteLine("Number of references to HubCityNug: " + srch.Entries.Count);

            Console.ReadLine();
        }
    }
}
