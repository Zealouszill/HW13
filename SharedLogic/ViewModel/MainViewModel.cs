using HW11Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace SharedLogic.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public ICommand addPotentialCommand;
        public ICommand resultsCommand;
        public ICommand removePotentialCommand;

        public List<string> Items { get; }
        public ObservableCollection<Potential> ListOfAllPotentials { get; }


        //private readonly IDataStorage dataStorage;

        public MainViewModel()
        {
            Console.WriteLine("This code executed");
            TestString = "This word";

            Items = new List<string>()
            {
                "Yes",
                "No"
            };

        }

        public MainViewModel(PotentialRepository potentialRepo)
        {
            this.potentialRepo = potentialRepo;

            Items = new List<string>()
            {
                "Yes",
                "No"
            };            
            //var p = dataStore.GetById(2);

        }

        //public IDataStorage DataStore => dataStorage;

        private readonly PotentialRepository potentialRepo;
        
        private string TestString;
        public string testStringFunction
        {
            get { return TestString; }
            set { SetField(ref TestString, value); }
        }

        private string TextEnjoysSports;
        public string textEnjoysSportsFunction
        {
            get { return TextEnjoysSports; }
            set { SetField(ref TextEnjoysSports, value); }
        }

        /* Display Database Values Code block: */

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

        /* End Display Database Values Code Block 
         * Add and remove Functionality Code block: */

        private int IdSelection;
        public int idSelectionFunction
        {
            get { return IdSelection; }
            set { SetField(ref IdSelection, value); }
        }

        private int RemovePotentialID;
        public int removePotentialIDFunction
        {
            get { return RemovePotentialID; }
            set { SetField(ref RemovePotentialID, value); }
        }

        /* End Add and remove Functionality Code block
         * Show results Code block: */

        private string FirstNameResults;
        public string firstNameResultsFunction
        {
            get { return FirstNameResults; }
            set { SetField(ref FirstNameResults, value); }
        }

        private string LastNameResults;
        public string lastNameResultsFunction
        {
            get { return LastNameResults; }
            set { SetField(ref LastNameResults, value); }
        }

        private string AdditionalDetailsResults;
        public string additionalDetailsResultsFunction
        {
            get { return AdditionalDetailsResults; }
            set { SetField(ref AdditionalDetailsResults, value); }
        }

        private int AgeResults;
        public int ageResultsFunction
        {
            get { return AgeResults; }
            set { SetField(ref AgeResults, value); }
        }

        private int PersonalityRatingResults;
        public int personalityRatingResultsFunction
        {
            get { return PersonalityRatingResults; }
            set { SetField(ref PersonalityRatingResults, value); }
        }

        private string EnjoysSportsResults;
        public string enjoysSportsResultsFunction
        {
            get { return EnjoysSportsResults; }
            set { SetField(ref EnjoysSportsResults, value); }
        }

        /* End  Show results Code block
         * Start of Compatability input code for user: */

        private string UserFirstName;
        public string userFirstNameFunction
        {
            get { return UserFirstName; }
            set { SetField(ref UserFirstName, value); }
        }

        private string UserLastName;
        public string userLastNameFunction
        {
            get { return UserLastName; }
            set { SetField(ref UserLastName, value); }
        }

        private int UserAge;
        public int userAgeFunction
        {
            get { return UserAge; }
            set { SetField(ref UserAge, value); }
        }

        private int UserEnjoysSportsRating;
        public int userEnjoysSportsRatingFunction
        {
            get { return UserEnjoysSportsRating; }
            set { SetField(ref UserEnjoysSportsRating, value); }
        }

        private string UserFrugalityRating;
        public string userFrugalityRatingFunction
        {
            get { return UserFrugalityRating; }
            set { SetField(ref UserFrugalityRating, value); }
        }


        private int UserPhysicallyActiveRating;
        public int userPhysicallyActiveRatingFunction
        {
            get { return UserPhysicallyActiveRating; }
            set { SetField(ref UserPhysicallyActiveRating, value); }
        }

        private int UserDesireForKidsRating;
        public int userDesireForKidsRatingFunction
        {
            get { return UserDesireForKidsRating; }
            set { SetField(ref UserDesireForKidsRating, value); }
        }

        private int UserSenseOfHumorRating;
        public int userSenseOfHumorRatingFunction
        {
            get { return UserSenseOfHumorRating; }
            set { SetField(ref UserSenseOfHumorRating, value); }
        }

        private int UserDrivenRating;
        public int userDrivenRatingFunction
        {
            get { return UserDrivenRating; }
            set { SetField(ref UserDrivenRating, value); }
        }

        private int UserAdditionalDetails;
        public int userAdditionalDetailsFunction
        {
            get { return UserAdditionalDetails; }
            set { SetField(ref UserAdditionalDetails, value); }
        }

        /*  
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            EnjoysSportsRating = enjoysSportsRating;
            FrugalityRating = frugalityRating;
            PhysicallyActiveRating = physicallyActiveRating;
            DesireForKidsRating = desireForKidsRating;
            SenseOfHumorRating = senseOfHumorRating;
            DrivenRating = drivenRating;
            AdditionalDetails = additionalDetails;
         */

        public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(
            () =>
            {
                return true;
            },
            () =>
            {
                //Potential test = new Potential();

                if (TextEnjoysSports == "Yes")
                    enjoysSportsFunction = true;
                else
                    enjoysSportsFunction = false;

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
                Potential tempPotential = potentialRepo.GetASpecificId(IdSelection);
                firstNameResultsFunction = tempPotential.FirstName;
                lastNameResultsFunction = tempPotential.LastName;
                additionalDetailsResultsFunction = tempPotential.AdditionalDetails;
                ageResultsFunction = tempPotential.Age;
                personalityRatingResultsFunction = tempPotential.PersonalityRating;

                if (tempPotential.EnjoysSports)
                    enjoysSportsResultsFunction = "Yes";
                else
                    enjoysSportsResultsFunction = "No";
                //firstNameResultsFunction = potentialRepo.GetASpecificId(IdSelection).FirstName;

                //FirstName = firstName;
                //LastName = lastName;
                //AdditionalDetails = additionalDetails;
                //Age = age;
                //PersonalityRating = personalityRating;
                //EnjoysSports = enjoysSports;
            }));

        public ICommand RemovePotentialCommand => removePotentialCommand ?? (removePotentialCommand = new SimpleCommand(
            () =>
            {
                var removalResult = potentialRepo.RemovePotentialById(RemovePotentialID);
                Console.WriteLine("The removal Result is: " + removalResult);
            }));

        //public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(() => ChildControlViewModel = new AddCardViewModel(cardRepo)));
        //public ICommand AddPotentialCommand => addPotentialCommand ?? (addPotentialCommand = new SimpleCommand(() => ChildControlViewModel = new AddPotentialViewModel(potentialRepo)));

        //public object ChildControlViewModel { get; set; }

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
