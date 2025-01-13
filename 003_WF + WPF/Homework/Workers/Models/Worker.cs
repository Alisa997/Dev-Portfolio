using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Workers.Helpers;
using System.Runtime.Serialization;

namespace Workers.Models
{
    public class Worker : DependencyObject
    {
        public const int MaxAge = 190;          // Maximum age
        public const int MaxSalary = 1_000_000; // Maximum salary

        // Surname
        public static readonly DependencyProperty SurnameProperty;  // Value storage
        public string Surname {
            get => (string)GetValue(SurnameProperty);
            set => SetValue(SurnameProperty, value);
        } // Surname

        // Name
        public static readonly DependencyProperty NameProperty;  // Value storage
        public string Name {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        } // Name

        // Patronymic
        public static readonly DependencyProperty PatronymicProperty;  // Value storage
        public string Patronymic {
            get => (string)GetValue(PatronymicProperty);
            set => SetValue(PatronymicProperty, value);
        } // Patronymic

        // Age
        public static readonly DependencyProperty AgeProperty;
        public int Age  {
            get => (int)GetValue(AgeProperty);
            set => SetValue(AgeProperty, value);
        }  // Age

        // Salary
        public static readonly DependencyProperty SalaryProperty;
        public int Salary  {
            get => (int)GetValue(SalaryProperty);
            set => SetValue(SalaryProperty, value);
        } // Salary

        // City of residence
        public static readonly DependencyProperty CityProperty;  // Value storage
        public string City {
            get => (string)GetValue(CityProperty);
            set => SetValue(CityProperty, value);
        } // City

        public Worker() { }
        public Worker(WorkerSerializeModel worker)  {
            Surname = worker.Surname;
            Name = worker.Name;
            Patronymic = worker.Patronymic;
            Age = worker.Age;
            Salary = worker.Salary;
            City = worker.City;
        } // Worker 

        // Static constructor
        static Worker() {
            SurnameProperty = DependencyProperty
                .Register("Surname", typeof(string), typeof(Worker));

            NameProperty = DependencyProperty
                .Register("Name", typeof(string), typeof(Worker));

            PatronymicProperty = DependencyProperty
                .Register("Patronymic", typeof(string), typeof(Worker));

            CityProperty = DependencyProperty
                .Register("City", typeof(string), typeof(Worker));

            // Register delegate for correct validation
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata { CoerceValueCallback = CorrectAge };

            AgeProperty = DependencyProperty
                .Register("Age", typeof(int), typeof(Worker), metadata);

            // Register delegate for correct validation
            metadata = new FrameworkPropertyMetadata { CoerceValueCallback = CorrectSalary };

            SalaryProperty = DependencyProperty
                .Register("Salary", typeof(int), typeof(Worker), metadata);
        } // Worker

        // ---------------------- Corrective Validators ---------------------------------

        // Corrective validation - delegate CoerceValueCallback for worker's salary
        private static object CorrectSalary(DependencyObject d, object baseValue) {
            int currentValue = (int)baseValue;

            if (currentValue < 0) currentValue = 0;
            if (currentValue > MaxSalary) currentValue = MaxSalary;

            return currentValue;
        } // CorrectSalary

        // Corrective validation - delegate CoerceValueCallback for worker's age
        private static object CorrectAge(DependencyObject d, object baseValue) {
            // Get the new age value - what will be recorded
            int currentValue = (int)baseValue;

            if (currentValue < 0) currentValue = 0;
            else if (currentValue > MaxAge) currentValue = MaxAge;

            return currentValue;
        } // CorrectAge

        // Factory method to create a worker
        public static Worker Generate() {
            // Indexes from data arrays for creating a worker
            int indexName = Utils.GetRandom(0, Utils.FullNames.Length - 1);
            int indexCity = Utils.GetRandom(0, Utils.Cities.Length - 1);

            // Create an object from template data arrays, no validation needed during creation
            return new Worker {
                Surname = Utils.FullNames[indexName].Surname,
                Name = Utils.FullNames[indexName].Name,
                Patronymic = Utils.FullNames[indexName].Patronymic,
                City = Utils.Cities[indexCity],
                Age = Utils.GetRandom(18, 70),
                Salary = Utils.GetRandom(20_000, 1_000_000),
            };
        } // Generate
    } // Worker
}
