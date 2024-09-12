using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Level4._3_Party_Deployment
{


    public class RunProgram
    {
        LegacyMediaGroup _mediaGroup;
        public RunProgram(IMediaGroup mediaGroup)
        {
            _mediaGroup = mediaGroup.CreateMediaGroup();
        }
    }


    public interface IMediaGroup
    {
        LegacyMediaGroup CreateMediaGroup();
    }


    public class MediaGroup : IMediaGroup
    {
        public LegacyMediaGroup CreateMediaGroup()
        {
            return new LegacyMediaGroup();
        }
    }


    public class LegacyMediaGroup
    {      

        public  List<LegacyMedia> Medias { get; set; } = new List<LegacyMedia>();
        public int MediaGroup1 { get; set; }
    }

    public class LegacyMedia
    {
        public  string Media1 { get; set; }
        public string Media2 { get; set; }
        public string Media3 { get; set; }
    }
}
