namespace Demo.ReactiveUI.Winforms.Routing.Views
{
    using System.Windows.Forms;

    using Demo.ReactiveUI.Winforms.Routing.ViewModels;
    using global::ReactiveUI;

    public partial class ContactView : UserControl, IViewFor<ContactViewModel>
    {
        #region Constructors

        public ContactView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.ViewTitle, v => v.lViewTitle.Text));
            });
        }

        #endregion Constructors

        #region Properties

        public ContactViewModel ViewModel
        {
            get; set;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ContactViewModel)value;
        }

        #endregion Properties
    }
}