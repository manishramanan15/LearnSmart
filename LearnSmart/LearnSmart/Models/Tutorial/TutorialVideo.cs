using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LearnSmart.Models.Tutorial
{
    [DataContract]
    public class TutorialVideo
    {
        [DataMember(Name = "id")]
        public int TutorialId { get; set; }

        [DataMember(Name = "results")]
        public IList<TutorialVideoItem> Videos { get; set; }
    }
}
