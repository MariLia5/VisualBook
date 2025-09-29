using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualBook
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var startForm = new StartForm();
            if (startForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new EnhancedMainForm());
            }
        }
    }
}