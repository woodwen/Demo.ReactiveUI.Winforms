namespace Demo.ReactiveUI.Winforms.Routing
{
    using System.Windows.Forms;

    using Demo.ReactiveUI.Winforms.Routing.ViewModels;
    using Demo.ReactiveUI.Winforms.Routing.Views;

    using global::ReactiveUI;

    using Splat;

    public class Bootstrapper
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public Bootstrapper()
        {
            ConfigureServices();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// 运行
        /// </summary>
        public void Run()
        {
            // 创建ShellViewModel并注册为IScreen
            var viewModel = new ShellViewModel();
            Locator.CurrentMutable.RegisterConstant(viewModel, typeof(IScreen));
            // 解析ShellViewModel的视图
            var view = ViewLocator.Current.ResolveView(viewModel);
            view.ViewModel = viewModel;
            // 运行应用程序
            Application.Run((Form)view);
        }

        private void ConfigureServices()
        {
            // 注册 views
            Locator.CurrentMutable.Register(() => new ShellView(), typeof(IViewFor<ShellViewModel>));
            Locator.CurrentMutable.Register(() => new HomeView(), typeof(IViewFor<HomeViewModel>));
            Locator.CurrentMutable.Register(() => new AboutView(), typeof(IViewFor<AboutViewModel>));
            Locator.CurrentMutable.Register(() => new ContactView(), typeof(IViewFor<ContactViewModel>));
        }

        #endregion Methods
    }
}