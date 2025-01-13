using Homework.Helpers;
using System;
using System.Windows;


namespace Homework.Models
{
    // Subscriber model 
    public class Subscriber : DependencyObject {
        // Full name (Last Name, First Initial, Middle Initial)
        public static readonly DependencyProperty FullNameProperty;  // storage for values
        public string FullName {
            get => (string)GetValue(FullNameProperty);
            set => SetValue(FullNameProperty, value);
        } // FullName

        // Street
        public static readonly DependencyProperty StreetProperty;  // storage for values
        public string Street {
            get => (string)GetValue(StreetProperty);
            set => SetValue(StreetProperty, value);
        } // Street

        // Building number
        public static readonly DependencyProperty BuildingProperty;  // storage for values
        public string Building {
            get => (string)GetValue(BuildingProperty);
            set => SetValue(BuildingProperty, value);
        } // Building

        // Apartment number
        public static readonly DependencyProperty FlatProperty;  // storage for values
        public int Flat {
            get => (int)GetValue(FlatProperty);
            set => SetValue(FlatProperty, value);
        } // Flat

        // Subscriber address
        public string Address { get => $"{Flat}, {Building} {Street}"; }

        // Publication type
        public static readonly DependencyProperty PubTypeProperty;  // storage for values
        public string PubType {
            get => (string)GetValue(PubTypeProperty);
            set => SetValue(PubTypeProperty, value);
        } // PubType

        // Publication index
        public static readonly DependencyProperty PubIndexProperty;  // storage for values
        public int PubIndex {
            get => (int)GetValue(PubIndexProperty);
            set => SetValue(PubIndexProperty, value);
        } // PubIndex

        // Publication title
        public static readonly DependencyProperty TitleProperty;  // storage for values
        public string Title {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        } // Title

        // Subscription start date
        public static readonly DependencyProperty DateStartProperty;  // storage for values
        public DateTime DateStart {
            get => (DateTime)GetValue(DateStartProperty);
            set => SetValue(DateStartProperty, value);
        } // DateStart

        // Subscription duration
        public static readonly DependencyProperty DurationProperty;  // storage for values
        public int Duration{
            get => (int)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        } // Duration

        public Subscriber() { }
        public Subscriber(SubscriberSerializeModel subscriber) {
            FullName = subscriber.FullName;
            Street = subscriber.Street;
            Building = subscriber.Building;
            Flat = subscriber.Flat;
            PubType = subscriber.PubType;
            PubIndex = subscriber.PubIndex;
            Title = subscriber.Title;
            DateStart = subscriber.DateStart;
            Duration = subscriber.Duration;
        } // Subscriber 

        // Static constructor
        static Subscriber() {
            FullNameProperty = DependencyProperty
                .Register("FullName", typeof(string), typeof(Subscriber));

            StreetProperty = DependencyProperty
                .Register("Street", typeof(string), typeof(Subscriber));

            BuildingProperty = DependencyProperty
                .Register("Building", typeof(string), typeof(Subscriber));

            FlatProperty = DependencyProperty
                .Register("Flat", typeof(int), typeof(Subscriber));

            PubTypeProperty = DependencyProperty
                .Register("PubType", typeof(string), typeof(Subscriber));

            PubIndexProperty = DependencyProperty
                .Register("PubIndex", typeof(int), typeof(Subscriber));

            TitleProperty = DependencyProperty
                .Register("Title", typeof(string), typeof(Subscriber));

            DateStartProperty = DependencyProperty
                .Register("DateStart", typeof(DateTime), typeof(Subscriber));

            DurationProperty = DependencyProperty
                .Register("Duration", typeof(int), typeof(Subscriber));
        } // Subscriber

        // Factory method to create a subscriber
        public static Subscriber Generate() {
            // indices from data arrays to create a subscriber
            int indexFullName = Utils.GetRandom(0, Utils.FullNames.Length - 1);
            int indexStreet = Utils.GetRandom(0, Utils.Streets.Length - 1);
            int indexPublication = Utils.GetRandom(0, Utils.Publications.Length - 1);
            int duration = Utils.GetRandom(0, 3);

            // create object from template data arrays, validation is not needed during creation
            return new Subscriber {
                FullName = Utils.FullNames[indexFullName],
                Building = $"{Utils.GetRandom(1, 200)}",
                DateStart = new DateTime(Utils.GetRandom(2020, 2022), Utils.GetRandom(1, 12), Utils.GetRandom(1, 28)),
                Flat = Utils.GetRandom(1, 500),
                Street = Utils.Streets[indexStreet],
                PubIndex = Utils.GetRandom(10000, 99999),
                Title = Utils.Publications[indexPublication].Name,
                PubType = Utils.Publications[indexPublication].pubType,
                Duration = duration == 0 ? 1 : duration == 1 ? 3 : duration == 2 ? 6 : duration == 3 ? 12 : 0,
            };
        } // Generate
    } // Subscriber
}