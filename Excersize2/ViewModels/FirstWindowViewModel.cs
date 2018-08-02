using System.ComponentModel.Composition;
using System.Dynamic;
using Caliburn.Micro;

namespace Excersize2.ViewModels
{
    [Export(typeof(FirstWindowViewModel))]
    public class FirstWindowViewModel : BaseWindowViewModel
    {
        private SecondWindowViewModel _secondWindow;

        public override double Height
        {
            get => _height;
            set
            {
                _height = value;
                NotifyOfPropertyChange(() => Height);

                if (_secondWindow != null)
                {
                    NotifyOfPropertyChange(() => _secondWindow.Height);
                }
            }
        }

        public override double Width
        {
            get => _width;
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
                if (_secondWindow != null)
                {
                    NotifyOfPropertyChange(() => _secondWindow.Width);
                }
            }
        }

        [ImportingConstructor]
        public FirstWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator) : base(windowManager, eventAggregator)
        {
            Height = 800;
            Width = 800;
        }

        public void OpenSecondWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.Height = Height;
            settings.Width = Width;
            _secondWindow = new SecondWindowViewModel(_windowManager, _eventAggregator, Height, Width);
            _windowManager.ShowDialog(_secondWindow, null, settings);
        }
    }
}