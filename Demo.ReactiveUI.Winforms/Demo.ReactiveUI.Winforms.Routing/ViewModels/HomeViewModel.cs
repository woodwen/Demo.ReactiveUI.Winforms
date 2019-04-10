namespace Demo.ReactiveUI.Winforms.Routing.ViewModels
{
    using global::ReactiveUI;

    public class HomeViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Fields

        private string _viewTitle;

        #endregion Fields

        #region Constructors

        public HomeViewModel()
        {
            ViewTitle = "Home View";
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