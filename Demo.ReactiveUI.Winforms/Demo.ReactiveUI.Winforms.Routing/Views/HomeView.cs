namespace Demo.ReactiveUI.Winforms.Routing.Views
{
    using Demo.ReactiveUI.Winforms.Routing.ViewModels;
    using global::ReactiveUI;
    using System.Windows.Forms;

    public partial class HomeView : UserControl, IViewFor<HomeViewModel>
    {
        #region Constructors

        public HomeView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.ViewTitle, v => v.lViewTitle.Text));
            });
        }

        #endregion Constructors

        #region Properties

        public HomeViewModel ViewModel
        {
            get; set;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (HomeViewModel)value;
        }

        #endregion Properties
    }
}