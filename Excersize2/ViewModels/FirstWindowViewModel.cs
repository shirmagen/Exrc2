using System.ComponentModel.Composition;
using System.Dynamic;
using Caliburn.Micro;

namespace Excersize2.ViewModels
{
    [Export(typeof(FirstWindowViewModel))]
    public class FirstWindowViewModel : BaseWindowViewModel
    {
        private SecondWindowViewModel _secondWindow;

        [ImportingConstructor]
        public FirstWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator) : base(windowManager, eventAggregator)
        {
            Height = 800;
            Width = 800;
        }

        public void OpenSecondWindow()
        {
            _secondWindow = new SecondWindowViewModel(_windowManager, _eventAggregator, Height, Width);
            _windowManager.ShowDialog(_secondWindow);
        }
    }
}