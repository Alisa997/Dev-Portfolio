using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Workers.Models
{
    // Worker class for serialization
    [DataContract]
    public class WorkerSerializeModel {
        // Surname
        [DataMember]
        public string Surname { get; set; } // Surname

        // Name
        [DataMember]
        public string Name { get; set; } // Name

        // Patronymic
        [DataMember]
        public string Patronymic { get; set; } // Patronymic

        // Age
        [DataMember]
        public int Age { get; set; } // Age

        // Salary
        [DataMember]
        public int Salary { get; set; } // Salary

        // City of residence
        [DataMember]
        public string City { get; set; } // City

        public WorkerSerializeModel(Worker worker) {
            Surname = worker.Surname;
            Name = worker.Name;
            Patronymic = worker.Patronymic;
            Age = worker.Age;
            Salary = worker.Salary;
            City = worker.City;
        } // WorkerSerializeModel
    } // WorkerSerializeModel
}
