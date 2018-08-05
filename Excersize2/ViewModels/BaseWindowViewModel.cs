using System.Windows;
using Caliburn.Micro;

namespace Excersize2.ViewModels
{
    public abstract class BaseWindowViewModel : PropertyChangedBase, IHandle<Size>
    {
        protected IWindowManager _windowManager;
        protected readonly IEventAggregator _eventAggregator;
        protected double _height;
        protected double _width;
        private double _multiply;


        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                NotifyOfPropertyChange(() => Height);
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }

        public double Multiply
        {
            get => _multiply;
            set
            {
                _multiply = value;
                NotifyOfPropertyChange(() => Multiply);
            }
        }

        protected BaseWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void WindowSizeChanged(SizeChangedEventArgs args)
        {
            _eventAggregator.PublishOnUIThread(args.NewSize);
        }

        public void Handle(Size newSize)
        {
            Height = newSize.Height;
            Width = newSize.Width;
            Multiply = Height * Width;
        }

    }
}
