namespace Demo.ReactiveUI.Winforms.Bindings.Views
{
    using Demo.ReactiveUI.Winforms.Bindings.BindingTypeConverter;
    using Demo.ReactiveUI.Winforms.Bindings.ViewModels;
    using global::ReactiveUI;
    using System.Windows.Forms;

    public partial class MainView : Form, IViewFor<MainViewModel>
    {
        #region Constructors

        public MainView()
        {
            InitializeComponent();
            var converter = new DateTimeFileTimeConverter();
            this.WhenActivated(d =>
            {
                // viewmodel绑定到视图标题(单向)
                d(this.OneWayBind(ViewModel, vm => vm.ApplicationTitle, v => v.Text));
                // viewmodel绑定到视图文本框文字(双向)
                d(this.Bind(ViewModel, vm => vm.ValueOne, v => v.tbInputOne.Text));
                // viewmodel绑定到视图标签文字(单向)
                d(this.OneWayBind(ViewModel, vm => vm.ValueOne, v => v.lOutputOne.Text));
                //viewmodel绑定到视图文本框文字(双向)带转换
                d(this.Bind(ViewModel, vm => vm.ValueTwo, v => v.dtpInputTwo.Value, null, converter, converter));
                //viewmodel绑定到视图标签文字(单向向)带转换
                d(this.OneWayBind(ViewModel, vm => vm.ValueTwo, v => v.lOutputTwo.Text));
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