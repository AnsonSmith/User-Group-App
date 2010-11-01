using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Windows;

namespace UgBoard.Models
{
    public class DefaultBackend : IBackend
    {
        private readonly IEnumerable<MethodInfo> _methods =
           typeof(DefaultBackend).GetMethods().Where(x => x.Name == "Handle");

        private ITwitterService twitterService;

        public ITwitterService TwitterService
        {
            get { return twitterService; }
            set { twitterService = value; }
        }

        #region IBackend Members

        public void Send(ICommand command)
        {
            Invoke(command, command);
        }

        public void Send<TResponse>(IQuery<TResponse> query, Action<TResponse> reply)
        {
            Invoke(query, query, reply);
        }

        #endregion


        private void Invoke(object request, params object[] args)
        {
            try
            {

                ThreadPool.QueueUserWorkItem(state =>
                {
                    Type requestType = request.GetType();
                    MethodInfo handler =
                        _methods.Where(
                            x =>
                            requestType.IsAssignableFrom(
                                x.GetParameters().First().ParameterType)).First();

                    handler.Invoke(this, args);
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show("UG Board has encountered an unexpected error. Please restart");
            }
        }
           
        



        public void Handle(SearchTwitter search, Action<IEnumerable<TwitterSearchResult>> reply)
        {
            try
            {
                reply(TwitterService.Search(search.SearchText));
            }
            catch (Exception ex)
            {
                MessageBox.Show("UG Board has encountered an unexpected error. DefaultBackend - Handle");

            }
        }

        public void Handle(SearchSponsors search, Action<IEnumerable<SponsorSearchResult>> reply)
        {
            IList<string> imageTypes = new List<string>();
            imageTypes.Add(".BMP");
            imageTypes.Add(".GIF");
            imageTypes.Add(".JPG");
            imageTypes.Add(".PNG");
            imageTypes.Add(".JPEG");


            IList<SponsorSearchResult> sponsors = new List<SponsorSearchResult>();

            DirectoryInfo di = new DirectoryInfo(search.DirectoryToScan);
            FileInfo[] rgFiles = di.GetFiles();
            foreach (FileInfo fi in rgFiles)
            {
                if (imageTypes.Contains(fi.Extension.ToUpper())) 
                {
                    string path = fi.FullName;
                    System.Drawing.Image objImage = System.Drawing.Image.FromFile(path);
                    
                    int height = objImage.Height;
                    int width = objImage.Width;
                    objImage.Dispose();

                    SponsorSearchResult sponsor = new SponsorSearchResult() { Height = height, Width = width, Path = path };

                    sponsors.Add(sponsor);

                    
                }
            }


            reply(sponsors);
        }

        public void Handle(SearchSwag search, Action<IEnumerable<SwagItemResult>> reply)
        {
            IList<SwagItemResult> items = new List<SwagItemResult>();

            XDocument doc = XDocument.Load(search.SwagFileName);

            var decendants = doc.Descendants("SwagItem");
            foreach (XElement xElem in decendants)
            {
                SwagItemResult res = new SwagItemResult() { Company = xElem.Element("Company").Value, Description = xElem.Element("Description").Value, ItemValue = xElem.Element("ItemValue").Value, Qty = xElem.Element("Qty").Value, Title = xElem.Element("Title").Value };

                items.Add(res);
            }
            reply(items);
        }
    }
}

