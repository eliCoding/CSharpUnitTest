using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    class Program
    {
        public static void Main()
        {
            var service = new VideoService();

            // DI via Method Parameters
            //var title = service.ReadVideoTitle(new FileReader());

            var title = service.ReadVideoTitle();

        }
    }
}
