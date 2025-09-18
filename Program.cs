using System;
using System.Windows.Forms;

namespace depictPicture {
    internal static class Program {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 main_form = new Form1();
            Form2 config_form = new Form2(main_form);
            main_form.bindForm2(config_form);
            config_form.Show();
            Application.Run(main_form);
        }


    }
}
