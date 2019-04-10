namespace Demo.ReactiveUI.Winforms.Commands.Views
{
    using Demo.ReactiveUI.Winforms.Commands.ViewModels;
    using global::ReactiveUI;
    using System.Windows.Forms;

    public partial class MainView : Form, IViewFor<MainViewModel>
    {
        #region Constructors

        public MainView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                // 绑定属性
                d(this.OneWayBind(ViewModel, vm => vm.ApplicationTitle, v => v.Text));
                // 绑定属性命令是否可以执行
                d(this.Bind(ViewModel, vm => vm.WithCanExecuteParameter, v => v.tbWithCanExecuteParameter.Text));
                // 绑定无参数命令
                d(this.BindCommand(ViewModel, vm => vm.ParameterlessCommand, v => v.btParameterless));
                // 使用参数绑定命令
                d(this.BindCommand(ViewModel, vm => vm.WithParameterCommand, v => v.btWithParameter, this.WhenAnyValue(v => v.tbParameter.Text)));
                // 绑定命令可以执行
                d(this.BindCommand(ViewModel, vm => vm.WithCanExecuteCommand, v => v.btWithCanExecute, this.WhenAnyValue(v => v.tbWithCanExecuteParameter.Text)));
            });

            ViewModel = new MainViewModel();
        }

        #endregion Constructors

        #region Properties

        public MainViewModel ViewModel
        {
            get; set;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainViewModel)value;
        }

        #endregion Properties
    }
}