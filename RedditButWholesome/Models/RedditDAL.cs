using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static RedditButWholesome.Models.Post;

namespace RedditButWholesome.Models
{
    public class RedditDAL
    {
        public string GetPostData()
        {
            string url = @"https://www.reddit.com/r/aww/.json";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rs = new StreamReader(response.GetResponseStream());

            string json = rs.ReadToEnd();
            return json;
        }
        
        public PostRoot GetPost()
        {
            string post = GetPostData();
            PostRoot pr = JsonConvert.DeserializeObject<PostRoot>(post);
            return pr;
        }
    }
}
