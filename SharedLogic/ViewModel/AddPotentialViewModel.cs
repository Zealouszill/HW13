using HW11Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace SharedLogic.ViewModel
{
    public class AddPotentialViewModel : INotifyPropertyChanged
    {
        private readonly PotentialRepository repo;

        public AddPotentialViewModel(PotentialRepository repo)
        {
            this.repo = repo ?? throw new ArgumentNullException(nameof(repo));
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


        private ICommand addPotential;
        public ICommand AddPotential => addPotential ?? (addPotential = new SimpleCommand(() =>
        {
            if (repo.AddPotential(new Potential(FirstName, LastName, AdditionalDetails, Age, PersonalityRating, EnjoysSports)));
                //IsClosed = true;
        }));



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
