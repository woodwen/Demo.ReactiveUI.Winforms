namespace Demo.ReactiveUI.Winforms.Routing.ViewModels
{
    using global::ReactiveUI;

    public class AboutViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Fields

        private string _viewTitle;

        #endregion Fields

        #region Constructors

        public AboutViewModel()
        {
            ViewTitle = "About View";
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