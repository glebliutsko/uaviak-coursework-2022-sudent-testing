using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTesting.Application.Services.FileDialog
{
    public interface IFileDialogService
    {
        public string Show(string fileFilter, bool multiselect = false);
    }
}
