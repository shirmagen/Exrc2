using System.Windows;
using Caliburn.Micro;

namespace Excersize2.ViewModels
{
    public abstract class BaseWindowViewModel : PropertyChangedBase
    {
        protected IWindowManager _windowManager;
        protected readonly IEventAggregator _eventAggregator;

        protected BaseWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
    }
}
