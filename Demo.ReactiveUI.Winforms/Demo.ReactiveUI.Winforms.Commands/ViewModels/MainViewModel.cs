namespace Demo.ReactiveUI.Winforms.Commands.ViewModels
{
    using global::ReactiveUI;
    using System;
    using System.Reactive.Linq;
    using System.Windows.Forms;

    public class MainViewModel : ReactiveObject
    {
        #region Fields

        private string _applicationTitle;
        private string _withCanExecuteParameter;

        #endregion Fields

        #region Constructors

        public MainViewModel()
        {
            // 设置属性
            ApplicationTitle = "ReactiveUI Winforms Demo - Commands";

            // 创建无参数命令
            ParameterlessCommand = ReactiveCommand.Create();
            ParameterlessCommand.Subscribe(new Action<object>(Parameterless));

            // 使用参数创建命令
            WithParameterCommand = ReactiveCommand.Create();
            WithParameterCommand.Subscribe(new Action<object>(WithParameter));

            // 带判断执行创建命令
            var canExecute = this.WhenAnyValue(vm => vm.WithCanExecuteParameter).Select(s => string.IsNullOrEmpty(s) == false);
            WithCanExecuteCommand = ReactiveCommand.Create(canExecute);
            WithCanExecuteCommand.Subscribe(new Action<object>(WithCanExecute));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// 标题
        /// </summary>
        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => this.RaiseAndSetIfChanged(ref _applicationTitle, value);
        }

        /// <summary>
        /// 无参数命令
        /// </summary>
        public ReactiveCommand<object> ParameterlessCommand
        {
            get;
        }

        /// <summary>
        /// 带参数可执行命令
        /// </summary>
        public ReactiveCommand<object> WithCanExecuteCommand
        {
            get;
        }

        public string WithCanExecuteParameter
        {
            get => _withCanExecuteParameter;
            set => this.RaiseAndSetIfChanged(ref _withCanExecuteParameter, value);
        }

        /// <summary>
        /// 带参数命令
        /// </summary>
        public ReactiveCommand<object> WithParameterCommand
        {
            get;
        }

        #endregion Properties

        #region Methods

        private void Parameterless(object message)
        {
            MessageBox.Show("You pressed the button!", ApplicationTitle, MessageBoxButtons.OK);
        }

        private void WithCanExecute(object message)
        {
            MessageBox.Show(message.ToString(), ApplicationTitle, MessageBoxButtons.OK);
        }

        private void WithParameter(object message)
        {
            MessageBox.Show(message.ToString(), ApplicationTitle, MessageBoxButtons.OK);
        }

        #endregion Methods
    }
}