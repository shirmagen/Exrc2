using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Excersize2.ViewModels
{
    public class SecondWindowViewModel : PropertyChangedBase
    {
        private IWindowManager _windowManager;

        [ImportingConstructor]
        public SecondWindowViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }
    }
}
