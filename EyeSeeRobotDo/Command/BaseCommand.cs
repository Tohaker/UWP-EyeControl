using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class BaseCommand
    {
        protected CommandType type;
        public abstract string StatusCheck();
        public abstract string MoveFingers(int[] fingers, bool hold);
        public bool ValidateResponse(string expected, string actual)
        {
            return (actual.Equals(expected));
        }
    }
}
