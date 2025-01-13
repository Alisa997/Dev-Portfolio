using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Homework.Models
{
    // Subscription class for serialization
    [DataContract]
    public class SubscriberSerializeModel {
        [DataMember]
        public string FullName { get; set; }

        // Street
        [DataMember]
        public string Street { get; set; }

        // Building
        [DataMember]
        public string Building { get; set; }

        // Apartment
        [DataMember]
        public int Flat { get; set; }

        // Publication type
        [DataMember]
        public string PubType { get; set; }

        // Publication index
        [DataMember]
        public int PubIndex { get; set; }

        // Publication title (name)
        [DataMember]
        public string Title { get; set; }

        // Subscription start date
        [DataMember]
        public DateTime DateStart { get; set; }

        // Subscription duration
        [DataMember]
        public int Duration { get; set; }

        public SubscriberSerializeModel(Subscriber subscriber) {
            FullName = subscriber.FullName;
            Street = subscriber.Street;
            Building = subscriber.Building;
            Flat = subscriber.Flat;
            PubType = subscriber.PubType;
            PubIndex = subscriber.PubIndex;
            Title = subscriber.Title;
            DateStart = subscriber.DateStart;
            Duration = subscriber.Duration;
        } // SubscriberSerializeModel 

    } // SubscriberSerializeModel
}
