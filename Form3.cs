using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace depictPicture {
    public partial class Form3 : Form {
        public Form3() {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e) {

        }

        private void github_link_click(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/WorldMargin2/depictPicture");
        }

        private void official_link_click(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://worldmargin.top");
        }


        private void bilibili_link_click(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://space.bilibili.com/3546734785464807");
        }

    }
}
