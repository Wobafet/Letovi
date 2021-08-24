using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznisLogika.Exceptions
{
    public class DestinationException:Exception
    {
        public DestinationException(string message):base(message)
        {

        }
    }
}
