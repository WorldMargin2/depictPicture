using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using KeysBinding;

namespace depictPicture {
    public partial class Form2 : Form {
        Form1 main_form;
        public Form2(Form1 main_form) {
            InitializeComponent();
            keyGridBinding = new KeyGridBinding(keyBindingGrid);
            this.main_form = main_form;
            this.FormClosed += (s, e) => {
                main_form.Close();
                keyGridBinding.stopListen();
            };
            keyGridBinding.startListen();
            bindKey();
            setToolTip();
        }


        // 双击图片框选择图片
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e) {
            openFileDialog1.Title = "选择图片文件";
            openFileDialog1.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif|所有文件|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                try {
                    Image img = Image.FromFile(openFileDialog1.FileName);
                    this.pictureBox1.Image = img;
                    main_form.setPicture(img);
                } catch (Exception ex) {
                    MessageBox.Show("无法打开文件: " + ex.Message);
                }
            }
        }
        //设置提示
        private void setToolTip() {
            toolTip1.SetToolTip(this.sizemode_, "选择图片显示模式");
            toolTip1.SetToolTip(this.drag_window, "设置是否可拖动窗口 (Alt+G)");
            toolTip1.SetToolTip(this.topest, "设置窗口置顶 (Alt+F)");
            toolTip1.SetToolTip(this.show_window, "显示/隐藏图片窗口 (Alt+C)");
            toolTip1.SetToolTip(this.mouse_penetrate, "设置鼠标穿透 (Alt+D)");

            toolTip1.SetToolTip(this.opacity_num, "设置窗口透明度 (Ctrl+Up/Down)");

        }

        //====================================
        void e_change_mouse_penetrate() {
            mouse_penetrate.Checked = !mouse_penetrate.Checked;
        }

        void e_change_topest() {
            topest.Checked = !topest.Checked;
        }

        void e_drag_window() {
            drag_window.Checked = !drag_window.Checked;
        }

        void e_config_window_show() {
            if (this.WindowState != FormWindowState.Minimized) {
                this.WindowState = FormWindowState.Minimized;
            } else {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        void e_main_window_show() {
            show_window.Checked = !show_window.Checked;
        }



        //透明度
        void e_opacity_down() {
            if (opacity_num.Value - 10 < 0) {
                opacity_num.Value = 0;
                return;
            }
            opacity_num.Value -= 10;
        }

        void e_opacity_up() {
            if (opacity_num.Value + 10 > 100) {
                opacity_num.Value = 100;
                return;
            }
            opacity_num.Value += 10;
        }

        void e_change_show_mode() {
            if (sizemode_.SelectedItem == null) {
                sizemode_.SelectedItem = "正常";
            }
            string mode = sizemode_.SelectedItem.ToString();
            switch (mode) {
                case "正常":
                    sizemode_.SelectedItem = "拉伸";
                    main_form.setSizeMode(PictureBoxSizeMode.StretchImage);
                    break;
                case "拉伸":
                    sizemode_.SelectedItem = "居中";
                    main_form.setSizeMode(PictureBoxSizeMode.CenterImage);
                    break;
                case "居中":
                    sizemode_.SelectedItem = "自动缩放";
                    main_form.setSizeMode(PictureBoxSizeMode.Zoom);
                    break;
                case "自动缩放":
                    sizemode_.SelectedItem = "平铺";
                    main_form.setSizeMode(PictureBoxSizeMode.AutoSize);
                    break;
                case "平铺":
                    sizemode_.SelectedItem = "正常";
                    main_form.setSizeMode(PictureBoxSizeMode.Normal);
                    break;
                default:
                    break;
            }
        }


        //====================================

        //绑定键组

        private KeyGridBinding keyGridBinding;
        private void bindKey() {
            keyGridBinding.bind("鼠标穿透", e_change_mouse_penetrate, Keys.Alt, Keys.M);
            keyGridBinding.bind("置顶", e_change_topest, Keys.Alt, Keys.T);
            keyGridBinding.bind("拖动窗口", e_drag_window, Keys.Alt, Keys.D);
            keyGridBinding.bind("显示/隐藏窗口", e_main_window_show, Keys.Alt, Keys.S);
            keyGridBinding.bind("降低透明度", e_opacity_down, Keys.Alt, Keys.Down);
            keyGridBinding.bind("提高透明度", e_opacity_up, Keys.Alt, Keys.Up);
            keyGridBinding.bind("切换显示模式", e_change_show_mode, Keys.Alt, Keys.N);
            keyGridBinding.bind("显示配置窗口", e_config_window_show, Keys.Control, Keys.B);
            keyGridBinding.initGridData();
        }





        //============================主窗口接口调用==================================================




        // 选择图片显示模式
        private void sizemode__SelectedValueChanged(object sender, EventArgs e) {
            if (sizemode_.SelectedItem == null) return;
            string mode = sizemode_.SelectedItem.ToString();
            switch (mode) {
                case "正常":
                    main_form.setSizeMode(PictureBoxSizeMode.Normal);
                    break;
                case "拉伸":
                    main_form.setSizeMode(PictureBoxSizeMode.StretchImage);
                    break;
                case "居中":
                    main_form.setSizeMode(PictureBoxSizeMode.CenterImage);
                    break;
                case "自动缩放":
                    main_form.setSizeMode(PictureBoxSizeMode.Zoom);
                    break;
                case "平铺":
                    main_form.setSizeMode(PictureBoxSizeMode.AutoSize);
                    break;
                default:
                    break;
            }
        }

        // 设置是否可拖动窗口
        private void drag_window_CheckedChanged(object sender, EventArgs e) {
            this.main_form.setDragWindow(this.drag_window.Checked);
            if (this.drag_window.Checked) {
                this.mouse_penetrate.Checked = false;
            }
        }

        // 设置窗口置顶
        private void topest_CheckedChanged(object sender, EventArgs e) {
            this.main_form.setTopest(this.topest.Checked);
        }

        // 设置鼠标穿透
        private void mouse_penetrate_CheckedChanged(object sender, EventArgs e) {
            this.main_form.setMousePenetrate(this.mouse_penetrate.Checked);
            if (this.mouse_penetrate.Checked) {
                this.drag_window.Checked = false;
            }
        }

        // 设置透明度
        private void opacity_num_ValueChanged(object sender, EventArgs e) {
            this.main_form.setOpacity((double)(this.opacity_num.Value) / 100.0);
        }

        private void show_window_CheckedChanged(object sender, EventArgs e) {
            if (this.show_window.Checked) {
                this.main_form.WindowState = FormWindowState.Normal;
                topest.Checked = true;
            } else {
                this.main_form.WindowState = FormWindowState.Minimized;
            }
        }



        //===========================表格绑定========================================================



        private void button1_Click(object sender, EventArgs e) {
            new Form3().ShowDialog();
            System.GC.Collect();
        }
    }
}