using Grido.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grido.OtherLogic
{
    class ApiController
    {
        private static ApiController inst;
        public static ApiController Inst { get => inst ?? new(); }

        QwertyContext _context;

        ApiController()
        {
            RefreshContext();
        }
        private void RefreshContext()
            => _context = new();
    }
}
