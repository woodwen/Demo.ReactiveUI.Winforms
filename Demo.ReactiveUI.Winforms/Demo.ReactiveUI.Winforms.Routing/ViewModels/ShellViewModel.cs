namespace Demo.ReactiveUI.Winforms.Routing.ViewModels
{
    using global::ReactiveUI;
    using System;
    using System.Reactive.Linq;

    public class ShellViewModel : ReactiveObject, IScreen
    {
        #region Fields

        private string _applicationTitle;

        #endregion Fields

        #region Constructors

        public ShellViewModel()
        {
            // 初始化路由
            Router = new RoutingState();
            // 初始化属性
            ApplicationTitle = "ReactiveUI Winforms Demo - Routing";
            // 初始化命令
            ShowHomeCommand = ReactiveCommand.Create();
            ShowHomeCommand.Subscribe(new Action<object>(ShowHome));
            ShowAboutCommand = ReactiveCommand.Create();
            ShowAboutCommand.Subscribe(new Action<object>(ShowAbout));
            ShowContactCommand = ReactiveCommand.Create();
            ShowContactCommand.Subscribe(new Action<object>(ShowContact));
            GoBackCommand = ReactiveCommand.Create(Router.NavigateBack.CanExecuteObservable);
            GoBackCommand.Subscribe(new Action<object>(GoBack));

            Router.NavigateAndReset.Execute(new HomeViewModel());
        }

        #endregion Constructors

        #region Properties

        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => this.RaiseAndSetIfChanged(ref _applicationTitle, value);
        }

        public ReactiveCommand<object> GoBackCommand
        {
            get;
        }

        public RoutingState Router
        {
            get;
        }

        public ReactiveCommand<object> ShowAboutCommand
        {
            get;
        }

        public ReactiveCommand<object> ShowContactCommand
        {
            get;
        }

        public ReactiveCommand<object> ShowHomeCommand
        {
            get;
        }

        #endregion Properties

        #region Methods

        private void GoBack(object obj)
        {
            if (Router.NavigationStack.Count > 0)
            {
                Router.NavigateBack.Execute(obj);
            }
        }

        private void ShowAbout(object obj)
        {
            // 导航到AboutViewModel
            Router.Navigate.Execute(new AboutViewModel());
        }

        private void ShowContact(object obj)
        {
            // 导航到ContactViewModel
            Router.Navigate.Execute(new ContactViewModel());
        }

        private void ShowHome(object obj)
        {
            // 导航到HomeViewModel
            Router.Navigate.Execute(new HomeViewModel());
        }

        #endregion Methods
    }
}