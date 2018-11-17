using HW11Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NewSharedLogic
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Console.WriteLine("This code executed");
            TestString = "This word";



        }

        //public IDataStorage DataStore => dataStore;

        private string TestString;
        public string testStringFunction
        {
            get { return TestString; }
            set { SetField(ref TestString, value); }
        }

        private string FirstName;
        public string firstNameFunction
        {
            get { return FirstName; }
            set { SetField(ref FirstName, value); }
        }

        private string LastName;
        public string lastNameFunction
        {
            get { return LastName; }
            set { SetField(ref LastName, value); }
        }

        private string AdditionalDetails;
        public string additionalDetailsFunction
        {
            get { return AdditionalDetails; }
            set { SetField(ref AdditionalDetails, value); }
        }

        private int Age;
        public int ageFunction
        {
            get { return Age; }
            set { SetField(ref Age, value); }
        }

        private int PersonalityRating;
        public int personalityRatingFunction
        {
            get { return PersonalityRating; }
            set { SetField(ref PersonalityRating, value); }
        }

        private bool EnjoysSports;
        public bool enjoysSportsFunction
        {
            get { return EnjoysSports; }
            set { SetField(ref EnjoysSports, value); }
        }

        private ICommand addPotentialCommand;
        public ICommand AddPotentialCommand => AddPotentialCommand ?? (addPotentialCommand = new Command(
            () =>
            {
                DataStore.AddPotential(new Potential(
                    firstNameFunction,
                    lastNameFunction,
                    additionalDetailsFunction,
                    ageFunction,
                    personalityRatingFunction,
                    enjoysSportsFunction));
                Potentials.Clear();
                foreach (var c in DataStore.GetAllPotentials())
                    Potentials.Add(c);
                FirstName = null;
            }));

        public ObservableCollection<Potential> Potentials { get; private set; }



        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion



    }
}
