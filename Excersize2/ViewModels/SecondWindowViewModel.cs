using System;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace Excersize2.ViewModels
{
    public class SecondWindowViewModel : BaseWindowViewModel, IHandle<Size>
    {
        private double _height;
        private double _width;

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

        [ImportingConstructor]
        public SecondWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator, double newHeight, double newWidth) : base(windowManager, eventAggregator)
        {
            Height = newHeight;
            Width = newWidth;
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