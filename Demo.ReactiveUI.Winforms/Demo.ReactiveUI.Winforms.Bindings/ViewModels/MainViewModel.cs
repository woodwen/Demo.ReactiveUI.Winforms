namespace Demo.ReactiveUI.Winforms.Bindings.ViewModels
{
    using System;
    using global::ReactiveUI;

    public class MainViewModel : ReactiveObject
    {
        #region Fields

        private string _applicationTitle;
        private string _valueOne;
        private long _valueTwo;

        #endregion Fields

        #region Constructors

        public MainViewModel()
        {
            // Set properties
            ApplicationTitle = "ReactiveUI Winforms Demo - Bindings";
            ValueOne = "Type somthing";
            ValueTwo = DateTime.Now.Date.ToFileTime();
        }

        #endregion Constructors

        #region Properties

        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => this.RaiseAndSetIfChanged(ref _applicationTitle, value);
        }

        public string ValueOne
        {
            get => _valueOne;
            set => this.RaiseAndSetIfChanged(ref _valueOne, value);
        }

        public long ValueTwo
        {
            get => _valueTwo;
            set => this.RaiseAndSetIfChanged(ref _valueTwo, value);
        }

        #endregion Properties
    }
}