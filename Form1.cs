using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace depictPicture {
    public partial class Form1 : Form {
        int last_drag_x = -100;
        int last_drag_y = -100;
        bool control_left = false;
        bool control_right = false;
        bool control_top = false;
        bool control_bottom = false;
        bool drag_window = false;

        Form2 setting_form;
        public Form1() {
            InitializeComponent();
        }

        // 设置窗口穿透
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        // 获取窗口长属性
        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        // 定义常量
        const int GWL_EXSTYLE = -20;
        const uint WS_EX_TRANSPARENT = 0x20;
        const uint WS_EX_LAYERED = 0x80000;
        const uint WS_EX_TOOLWINDOW = 0x80;
        const uint WS_EX_APPWINDOW = 0x40000;
        // 绑定设置窗口

        public void bindForm2(Form2 form2) {
            if (this.setting_form != null) return;
            this.setting_form = form2;
        }

        //================== 对外接口 ==================
        public void setPicture(Image img) {
            this.transparent_picture.Image = img;
        }

        // 设置图片显示模式
        public void setSizeMode(PictureBoxSizeMode mode) {
            this.transparent_picture.SizeMode = mode;
        }

        // 设置是否可拖动窗口
        public void setDragWindow(bool drag) {
            this.drag_window = drag;
        }

        // 设置窗口置顶
        public void setTopest(bool top) {
            this.TopMost = top;
        }

        // 设置透明度 0~1
        public void setOpacity(double opacity) {
            if (opacity < 0) opacity = 0;
            if (opacity > 1) opacity = 1;
            this.Opacity = opacity;
        }
        // 设置鼠标穿透
        public void setMousePenetrate(bool penetrate) {
            IntPtr hwnd = this.Handle;
            uint exStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            if (penetrate) {
                exStyle |= WS_EX_TRANSPARENT;
                exStyle |= WS_EX_LAYERED;
                exStyle |= WS_EX_TOOLWINDOW;
                exStyle &= ~WS_EX_APPWINDOW;
            } else {
                exStyle &= ~WS_EX_TRANSPARENT;
                exStyle |= WS_EX_LAYERED;
                exStyle &= ~WS_EX_TOOLWINDOW;
                exStyle |= WS_EX_APPWINDOW;
            }
            SetWindowLong(hwnd, GWL_EXSTYLE, exStyle);
        }
        //===================================================================

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            int mouse_x = Control.MousePosition.X;
            int mouse_y = Control.MousePosition.Y;
            int _this_x = this.Location.X;
            int _this_y = this.Location.Y;
            int _this_w = this.Size.Width;
            int _this_h = this.Size.Height;
            // 左上角

            if (last_drag_x == -100 && last_drag_y == -100) {
                last_drag_x = mouse_x;
                last_drag_y = mouse_y;
            }

            if (_this_x - 10 <= mouse_x && mouse_x <= _this_x + 10) {
                control_left = true;
                control_right = false;
            } else if (_this_x + _this_w - 10 <= mouse_x && mouse_x <= _this_x + _this_w + 10) {
                control_right = true;
                control_left = false;
            }
            if (_this_y - 10 <= mouse_y && mouse_y <= _this_y + 10) {
                control_top = true;
                control_bottom = false;
            } else if (_this_y + _this_h - 10 <= mouse_y && mouse_y <= _this_y + _this_h + 10) {
                control_bottom = true;
                control_top = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                int mouse_x = Control.MousePosition.X;
                int mouse_y = Control.MousePosition.Y;
                if (last_drag_x == -100 && last_drag_y == -100) {
                    last_drag_x = mouse_x;
                    last_drag_y = mouse_y;
                    return;
                }
                int drag_x, drag_y;
                bool temp = false;// 是否有控制点被选中
                if (control_left) {
                    drag_x = mouse_x - last_drag_x;
                    this.Width -= drag_x;
                    this.Left += drag_x;
                    last_drag_x = mouse_x;
                } else if (control_right) {
                    drag_x = mouse_x - last_drag_x;
                    this.Width += drag_x;
                    last_drag_x = mouse_x;
                } else {

                }
                if (control_top && !drag_window) {
                    drag_y = mouse_y - last_drag_y;
                    this.Height -= drag_y;
                    this.Top += drag_y;
                    last_drag_y = mouse_y;
                } else if (control_bottom) {
                    drag_y = mouse_y - last_drag_y;
                    this.Height += drag_y;
                    last_drag_y = mouse_y;
                } else {
                    if (drag_window && !temp) {
                        drag_x = mouse_x - last_drag_x;
                        drag_y = mouse_y - last_drag_y;
                        this.Left += drag_x;
                        this.Top += drag_y;
                        last_drag_x = mouse_x;
                        last_drag_y = mouse_y;
                    }
                }



                panel1.Width = this.Width - 20;
                panel1.Height = this.Height - 20;

                this.transparent_picture.Width = this.Width - 20;
                this.transparent_picture.Height = this.Height - 20;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            this.control_left = false;
            this.control_right = false;
            this.control_top = false;
            this.control_bottom = false;
            this.last_drag_x = -100;
            this.last_drag_y = -100;
        }
    }
}
