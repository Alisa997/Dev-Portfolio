using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Workers.Models;

namespace Workers.Controllers
{
    internal class WorkersController {
        private string _fileName;
        public string FileName { get => _fileName; set => _fileName = value; }

        // collection of Workers
        private List<Worker> _workers;
        public List<Worker> Workers {
            get => _workers;
            private set => _workers = value;
        } // Workers


        // constructors
        public WorkersController():this(new List<Worker>()) {
            _fileName = "workers.json";
            Initialize();
        } // WorkersController

        public WorkersController(List<Worker> workers) {
            Workers = workers;
        } // WorkersController


        // initializing the collection
        public void Initialize(int n = 12) {
            _workers.Clear();

            for (int i = 0; i < n; i++) {
                _workers.Add(Worker.Generate());
            } // for i
            SerializeData();
        } // Initialize


        // indexer
        public Worker this[int index] {
            get => _workers[index];
            set => _workers[index] = value;
        } // indexer


        // getting the current number of items in the collection
        public int Count => _workers.Count;


        // adding a worker to the collection
        public void Add(Worker worker) {
            _workers.Add(worker);
            OrderByName();
        } // Add


        // removing a worker from the collection
        public void RemoveAt(int index) => _workers.RemoveAt(index);

        // sorting the collection by the worker's first name
        public void OrderByName() =>
            _workers.Sort((x, y) => x.Name.CompareTo(y.Name));

        // sorting the collection by the worker's last name
        public void OrderBySurname() =>
            _workers.Sort((x, y) => x.Surname.CompareTo(y.Surname));

        // sorting the collection by the worker's patronymic
        public void OrderByPatronymic() =>
            _workers.Sort((x, y) => x.Patronymic.CompareTo(y.Patronymic));

        // sorting the collection by the worker's salary in descending order
        public void OrderBySalaryDesc() =>
            _workers.Sort((x, y) => y.Salary.CompareTo(x.Salary));

        // -----------------------------------------------------------------------------------

        // serializing data into JSON format
        public void SerializeData() {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<WorkerSerializeModel>));

            List<WorkerSerializeModel> temp = new List<WorkerSerializeModel>();
            _workers.ForEach(x => temp.Add(new WorkerSerializeModel(x)));
            // Writing the object to a JSON file
            using (FileStream fs = new FileStream(FileName, FileMode.Create)) {
                jsonFormatter.WriteObject(fs, temp);
            } // using
        } // SerializeData

        // deserializing data from JSON format
        public void DeserializeData() {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<WorkerSerializeModel>));

            List<WorkerSerializeModel> temp = new List<WorkerSerializeModel>();
            // Reading the collection from the JSON file
            using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate)) {
                temp = (List<WorkerSerializeModel>)jsonFormatter.ReadObject(fs);
            } // using

            _workers.Clear();
            temp.ForEach(x => _workers.Add(new Worker(x)));
        } // DeserializeData

        // -----------------------------------------------------------------------------------

    } // WorkersController
}
