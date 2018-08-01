using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Excersize2.Views;

namespace Excersize2.ViewModels
{
    [Export(typeof(FirstWindowViewModel))]
    public class FirstWindowViewModel : PropertyChangedBase, IHandle<Size>
    {
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator;
        private double _multiply;

        public double Multiply
    {
            get => _multiply;
            set
            {
                _multiply = value;
                NotifyOfPropertyChange(() => Multiply);
            }
        }

        [ImportingConstructor]
        public FirstWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void OpenSecondWindow()
        {
            _windowManager.ShowDialog(new SecondWindowViewModel(_windowManager));
        }

        public void WindowSizeChanged(SizeChangedEventArgs args)
        {
            _eventAggregator.PublishOnUIThread(args.NewSize);
        }

        public void Handle(Size newSize)
        {
            Multiply = newSize.Height * newSize.Width;
        }
}
}