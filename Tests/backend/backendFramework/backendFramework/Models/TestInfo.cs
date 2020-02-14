using System;
using System.Runtime.Serialization;

namespace backendFramework.Models
{
    //Mandatory to specify that the data in this can be serialized/deserialized --in json for instance
    [DataContract]
    public class TestInfo
    {
        [DataMember(Name = "changedNameOfString")]
        public string BasicString { get; set; }
        [DataMember(Name = "changedNameOfInt")]
        public int BasicInt { get; set; }
        [DataMember(Name = "changedNameOfFloat")]
        public float BasicFloat { get; set; }
        [DataMember(Name = "changedNameOfDate")]
        public DateTime BasicDate { get; set; }

        //No datamember so it is not sent
        public string NotSentData { get; set; }
    }
}