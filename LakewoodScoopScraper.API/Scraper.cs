using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LakewoodScoopScraper.API
{
    public class Scraper
    {
        public IEnumerable<Post> GetNews()
        {
            string url = "http://thelakewoodscoop.com";
            var client = new WebClient();
            var html = client.DownloadString(url);
            var parser = new HtmlParser();
            var document = parser.Parse(html);
            IEnumerable<IElement> posts = document.QuerySelectorAll(".post");
            return posts.Select(ParseStory).Where(p => p != null);
        }

        public Post ParseStory(IElement post)
        {
            var result = new Post();
            var h2 = post.QuerySelector("h2");
            if (h2 != null)
            {
                result.Title = h2.TextContent;
            }

            var url = post.QuerySelector("href");
            if (url != null)
            {
                result.Url = url.Attributes["href"].Value;
            }

            var imageUrl = post.QuerySelector("img");
            if (imageUrl != null)
            {
                result.ImageUrl = imageUrl.Attributes["src"].Value;
            }

            var text = post.QuerySelector("p");
            if (text != null)
            {
                result.Text = text.TextContent;
            }

            return result;
        }
    }
}
