using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models.Data;

namespace WebApplication.ViewModel.Base
{
    public class ViewModelBase
    {
        private readonly WebAppContextDB _context;
        public ViewModelBase(WebAppContextDB context)
        {
            this._context = context;
        }
    }
}
