using System.Runtime.InteropServices;

namespace Iris
{
    public static class ScreenReader
    {
        private delegate bool SayStringHandler(string stringToSay, bool isInterrupt);
        private static SayStringHandler sayStringWorker = new SayStringHandler(sayString);

        [DllImport("Lib\\ScreenReaderApi.dll")]
        public static extern bool sayString([MarshalAs(UnmanagedType.LPStr)]string stringToSay, bool interrupt);

        public static void SayStringAsync(string stringToSay, bool isInterrupt)
        {
            sayStringWorker.BeginInvoke(stringToSay, isInterrupt, ar => sayStringWorker.EndInvoke(ar), null);
        }

    }
}