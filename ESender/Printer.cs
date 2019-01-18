using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESender
{
    public static class Printer
    {
        private static int _counter = 0;

        public static void Print(IEnumerable<ValueOfList> lists)
        {
            foreach (var VARIABLE in lists)
            {
                Console.WriteLine(Environment.NewLine + " " + (++_counter) + ")" + "\n" + " Id: " + VARIABLE.Id + "\n" +
                                  " Name: " + VARIABLE.Name +
                                  "\n" + " FriendlyName: " + VARIABLE.FriendlyName + "\n" + " Language: " +
                                  VARIABLE.Language + "\n" + " OptIn: " +
                                  VARIABLE.OptInList);
            }
        }
    }
}