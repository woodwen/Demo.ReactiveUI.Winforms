namespace Demo.ReactiveUI.Winforms.Routing.Views
{
    using Demo.ReactiveUI.Winforms.Routing.ViewModels;
    using global::ReactiveUI;
    using System.Windows.Forms;

    public partial class ShellView : Form, IViewFor<ShellViewModel>
    {
        #region Constructors

        public ShellView()
        {
            InitializeComponent();

            this.WhenActivated(b =>
            {
                // 绑定路由
                b(this.OneWayBind(ViewModel, vm => vm.Router, v => v.routedControlHost.Router));

                // 绑定属性
                b(this.OneWayBind(ViewModel, vm => vm.ApplicationTitle, v => v.Text));

                // 绑定命令
                b(this.BindCommand(ViewModel, vm => vm.ShowHomeCommand,v => v.btHome));
                b(this.BindCommand(ViewModel, vm => vm.ShowAboutCommand, v => v.btAbout));
                b(this.BindCommand(ViewModel, vm => vm.ShowContactCommand, v => v.btContact));
                b(this.BindCommand(ViewModel, vm => vm.GoBackCommand, v => v.btGoBack));
            });
        }

        #endregion Constructors

        #region Properties

        public ShellViewModel ViewModel
        {
            get; set;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ShellViewModel)value;
        }

        #endregion Properties
    }
}