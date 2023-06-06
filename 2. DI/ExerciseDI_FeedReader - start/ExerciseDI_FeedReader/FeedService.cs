using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseDI_FeedReader
{
    public class FeedService
    {
        public string GetFeed()
        {
            PodcastFeedReader podcast = new PodcastFeedReader();
            return podcast.GetSingleFeed() ;      
        }
    }
}
