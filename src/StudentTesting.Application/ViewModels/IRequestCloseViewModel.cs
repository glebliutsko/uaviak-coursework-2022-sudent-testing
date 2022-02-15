using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTesting.Application.ViewModels
{
    public interface IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;
    }
}
