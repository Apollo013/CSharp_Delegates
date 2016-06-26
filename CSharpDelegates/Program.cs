using CSharpDelegates.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiCastDelegateExample.Run();
            GenericDelegateExample.Run();
            MethodGroupConversionExample.Run();
            ActionAndFuncDelegatesExample.Run();
        }
    }
}
