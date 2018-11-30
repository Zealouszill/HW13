using System;
using System.Collections.Generic;
using System.Text;
using SharedLogic.ViewModel;


namespace HW11Xamarain
{
    public class ViewModelLocator
    {
        private readonly MainViewModel _viewModel = new MainViewModel();

        public MainViewModel Main
        {
            get { return _viewModel; }
        }
    }
}
