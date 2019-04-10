namespace Demo.ReactiveUI.Winforms.Routing.Views
{
    using System.Windows.Forms;

    using Demo.ReactiveUI.Winforms.Routing.ViewModels;
    using global::ReactiveUI;

    public partial class AboutView : UserControl, IViewFor<AboutViewModel>
    {
        #region Constructors

        public AboutView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.ViewTitle, v => v.lViewTitle.Text));
            });
        }

        #endregion Constructors

        #region Properties

        public AboutViewModel ViewModel
        {
            get; set;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (AboutViewModel)value;
        }

        #endregion Properties
    }
}