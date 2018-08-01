using System;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Excersize2.Views;

namespace Excersize2.ViewModels
{
    [Export(typeof(FirstWindowViewModel))]
    public class FirstWindowViewModel : BaseWindowViewModel, IHandle<Size>
    {
        private double _height;
        private double _width;
        private SecondWindowViewModel _secondWindow;

        public double Height
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

        public double Width
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

        public void WindowSizeChanged(SizeChangedEventArgs args)
        {
            _eventAggregator.PublishOnUIThread(args.NewSize);
        }

        public void Handle(Size newSize)
        { 
            Height = newSize.Height;
            Width = newSize.Width;
        }
    }
}