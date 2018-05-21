using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LearnSmart.Models.Tutorial
{
    [DataContract]
    public class TutorialStatus
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string TutorialName { get; set; }

        [DataMember(Name = "playedtime")]
        public string LastPayedTime { get; set; }

        [DataMember(Name = "lastaction")]
        public string LastAction { get; set; }
    }
}
