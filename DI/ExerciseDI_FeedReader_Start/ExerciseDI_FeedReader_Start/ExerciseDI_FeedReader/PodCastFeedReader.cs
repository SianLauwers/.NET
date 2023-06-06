using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseDI_FeedReader 
{

    public class PodCastFeedReader : IFeedReader
    {
        public PodCastFeedReader()
        {
            ReturnType = "Audio";
        }

        public string ReturnType { get; }

        public string GetSingleFeed()
        {
            return ReturnType + ":item 1";
        }
    }
}
