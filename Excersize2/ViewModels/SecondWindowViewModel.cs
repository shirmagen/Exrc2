using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Excersize2.ViewModels
{
    public class SecondWindowViewModel : BaseWindowViewModel
    {
        [ImportingConstructor]
        public SecondWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator, double newHeight, double newWidth) : base(windowManager, eventAggregator)
        {
            Height = newHeight;
            Width = newWidth;
        }
    }
}