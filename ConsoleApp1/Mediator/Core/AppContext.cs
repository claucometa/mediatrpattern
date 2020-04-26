using System.Threading;

namespace ConsoleApp1
{
    partial class Program
    {
        public static class AppContext
        {
            public static bool pause = true;
            public static AutoResetEvent waitNext = new AutoResetEvent(false);
            public static AutoResetEvent waitExit = new AutoResetEvent(false);
            public static bool Processando;
            public const double AwaitingTimeInSeconds = 2;

        }
    }
}
