using System.Windows.Forms;

namespace streamClient
{
    internal static class Program
    {
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}