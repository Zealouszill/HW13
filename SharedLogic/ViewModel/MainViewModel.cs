﻿using HW11Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace SharedLogic.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public ICommand addPotentialCommand;
        public ICommand resultsCommand;

        private readonly IDataStorage dataStorage;

        public MainViewModel()
        {
            Console.WriteLine("This code executed");
            TestString = "This word";

            //addPotentialCommand = new RelayCommand();

        }

        public MainViewModel(PotentialRepository potentialRepo)
        {
            this.potentialRepo = potentialRepo;

            //var p = dataStore.GetById(2);

        }

        public IDataStorage DataStore => dataStorage;

        private readonly PotentialRepository potentialRepo;
        
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

        private int IdSelection;
        public int idSelectionFunction
        {
            get { return IdSelection; }
            set { SetField(ref IdSelection, value); }
        }

        private string FirstNameResults;
        public string firstNameResultsFunction
        {
            get { return FirstNameResults; }
            set { SetField(ref FirstNameResults, value); }
        }

        //FirstName = firstName;
        //LastName = lastName;
        //AdditionalDetails = additionalDetails;
        //Age = age;
        //PersonalityRating = personalityRating;
        //EnjoysSports = enjoysSports;

        //    public ICommand Add2
        //{
        //    get
        //    {
        //        if(addPotentialCommand == null)
        //        {
        //            addPotentialCommand = new SimpleCommand(add_CanExecute, add_Execute);
        //        }
        //        return addPotentialCommand;
        //    }
        //}
        //private bool add_CanExecute()
        //{
        //    return true;
        //}
        //private void add_Execute()
        //{
        //    //do your stuff
        //}

        //private ICommand addPotentialCommand;
        public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(
            () =>
            {
                return true;
            },
            () =>
            {
                //Potential test = new Potential();

                potentialRepo.AddPotential(new Potential(
                    firstNameFunction,
                    lastNameFunction,
                    additionalDetailsFunction,
                    ageFunction,
                    personalityRatingFunction,
                    enjoysSportsFunction));
                //Potentials.Clear();
                //foreach (var c in potentialRepo.GetAllPotentials())
                //    Potentials.Add(c);
                FirstName = null;
            }));

        public ICommand GetDBResults => resultsCommand ?? (resultsCommand = new SimpleCommand(
            () =>
            {
                Console.WriteLine("This code was called CardRepository");

                //DataStore.GetPotentialById(1);
                //var p = DataStore.GetPotentialById(1);


                Console.WriteLine("The ID Selection is: " + 1);

                var temp1 = potentialRepo;
                var temp2 = temp1.GetASpecificId(1);
                var temp3 = temp2.FirstName;

                Console.WriteLine("temp3 is " + temp3);

                firstNameResultsFunction = temp3;

                //firstNameResultsFunction = potentialRepo.GetASpecificId(IdSelection).FirstName;
            }));

        //public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(() => ChildControlViewModel = new AddCardViewModel(cardRepo)));
        //public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(() => ChildControlViewModel = new AddPotentialViewModel(potentialRepo)));

        public object ChildControlViewModel { get; set; }

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

    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { /*CommandManager.RequerySuggested += value;*/ }
            remove { /*CommandManager.RequerySuggested -= value;*/ }
        }
        private Action methodToExecute;
        private Func<bool> canExecuteEvaluator;
        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }
        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }
        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }
        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }
    }
}
