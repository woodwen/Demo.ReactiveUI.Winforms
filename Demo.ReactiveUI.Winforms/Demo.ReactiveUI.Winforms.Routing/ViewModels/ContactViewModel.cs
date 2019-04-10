namespace Demo.ReactiveUI.Winforms.Routing.ViewModels
{
    using global::ReactiveUI;

    public class ContactViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Fields

        private string _viewTitle;

        #endregion Fields

        #region Constructors

        public ContactViewModel()
        {
            ViewTitle = "Contact View";
        }

        #endregion Constructors

        #region Properties

        public IScreen HostScreen
        {
            get; protected set;
        }

        public string UrlPathSegment
        {
            get; protected set;
        }

        public string ViewTitle
        {
            get => _viewTitle;
            set => this.RaiseAndSetIfChanged(ref _viewTitle, value);
        }

        #endregion Properties
    }
}