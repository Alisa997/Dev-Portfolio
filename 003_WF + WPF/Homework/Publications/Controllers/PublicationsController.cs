using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Homework.Models;

namespace Homework.Controllers
{
    /*
     * Application functionality implementation   
    Sorting:
     * • Sorting by publication index
     * • Sorting by subscriber address
     * • Sorting by descending subscription duration
    Selection:
     * • Subscriptions by selected publication type
     * • Subscriptions by selected duration
     * • Subscriptions by selected subscriber's full name
     */
    public class PublicationsController {
        private string _fileName;
        public string FileName { get => _fileName; set => _fileName = value; }

        // collection of Subscribers
        private List<Subscriber> _subscribers;
        public List<Subscriber> Subscribers {
            get => _subscribers;
            set => _subscribers = value;
        }

        // constructors
        public PublicationsController() : this(new List<Subscriber>()) {
            _fileName = "publications.json";
            Initialize();
        } // PublicationsController

        public PublicationsController(List<Subscriber> subscribers) {
            Subscribers = subscribers;
        } // PublicationsController


        // initialize collection
        public void Initialize(int n = 12) {
            _subscribers.Clear();

            for (int i = 0; i < n; i++)
            {
                _subscribers.Add(Subscriber.Generate());
            } // for i
            SerializeData();
        } // Initialize


        // indexer 
        public Subscriber this[int index] {
            get => _subscribers[index];
            set => _subscribers[index] = value;
        } // indexer


        // get current number of elements in the collection
        public int Count => _subscribers.Count;


        // add a subscriber to the collection
        public void Add(Subscriber subscriber) {
            _subscribers.Add(subscriber);
            SerializeData();
        } // Add


        // remove a subscriber from the collection
        public void RemoveAt(int index) {
            _subscribers.RemoveAt(index);
            SerializeData();
        } // RemoveAt 


        // sort collection by publication index
        public List<Subscriber> OrderByIndex() {
            List<Subscriber> list = new List<Subscriber>(_subscribers);
            list.Sort((x, y) => x.PubIndex.CompareTo(y.PubIndex));
            return list;
        } // OrderByIndex

        // sort collection by subscriber address
        public List<Subscriber> OrderByAddress() {
            List<Subscriber> list = new List<Subscriber>(_subscribers);
            list.Sort((x, y) => x.Address.CompareTo(y.Address));
            return list;
        } // OrderByAddress

        // sort collection by descending subscription duration
        public List<Subscriber> OrderByDurationDesc() {
            List<Subscriber> list = new List<Subscriber>(_subscribers);
            list.Sort((x, y) => y.Duration.CompareTo(x.Duration));
            return list;
        } // OrderByDurationDesc

        // sort collection by publication type
        public List<Subscriber> OrderByPubType() {
            List<Subscriber> list = new List<Subscriber>(_subscribers);
            list.Sort((x, y) => x.PubType.CompareTo(y.PubType));
            return list;
        } // OrderByPubType

        // filter collection by selected publication type
        public List<Subscriber> SelectWherePubType(string pubType) =>
            _subscribers.FindAll(x => x.PubType == pubType);

        // filter collection by selected duration
        public List<Subscriber> SelectWhereDuration(int duration) =>
            _subscribers.FindAll(x => x.Duration == duration);

        // filter collection by selected full name
        public List<Subscriber> SelectWhereFullName(string fullName) =>
            _subscribers.FindAll(x => x.FullName == fullName);

        // filter collection by selected publication title
        public List<Subscriber> SelectWhereTitle(string title) =>
            _subscribers.FindAll(x => x.Title == title);

        // get list of full names from collection
        public List<string> GetFullNames() {
            Dictionary<string, int> fullNames = new Dictionary<string, int>();

            _subscribers.ForEach(s => fullNames[s.FullName] = 0);

            return fullNames.Keys.ToList();
        } // GetFullNames


        // get list of publication types from collection
        public List<string> GetPubTypes() {
            Dictionary<string, int> pubTypes = new Dictionary<string, int>();

            _subscribers.ForEach(s => pubTypes[s.PubType] = 0);

            return pubTypes.Keys.ToList();
        } // GetPubTypes


        // get list of publication titles from collection
        public List<string> GetTitles() {
            Dictionary<string, int> titles = new Dictionary<string, int>();

            _subscribers.ForEach(s => titles[s.Title] = 0);

            return titles.Keys.ToList();
        } // GetTitles

        // -----------------------------------------------------------------------------------

        // serialize data to JSON format
        public void SerializeData() {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<SubscriberSerializeModel>));

            List<SubscriberSerializeModel> temp = new List<SubscriberSerializeModel>();
            _subscribers.ForEach(x => temp.Add(new SubscriberSerializeModel(x)));
            // Write object to JSON file
            using (FileStream fs = new FileStream(FileName, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, temp);
            } // using
        } // SerializeData

        // deserialize data from JSON format
        public void DeserializeData() {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<SubscriberSerializeModel>));

            List<SubscriberSerializeModel> temp = new List<SubscriberSerializeModel>();
            // Read collection from JSON file
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                temp = (List<SubscriberSerializeModel>)jsonFormatter.ReadObject(fs);
            } // using

            _subscribers.Clear();
            temp.ForEach(x => _subscribers.Add(new Subscriber(x)));
        } // DeserializeData

        // -----------------------------------------------------------------------------------
    } // class PublicationsController
}