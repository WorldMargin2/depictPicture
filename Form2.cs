using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace depictPicture {
    public partial class Form2 : Form {
        Form1 main_form;
        public Form2(Form1 main_form) {
            InitializeComponent();
            this.main_form = main_form;
            this.FormClosed += (s, e) => {
                main_form.Close();
                stopListen();
            };
            startListen();
            bindKey();
            initGridData();
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

        //=======================================================================================
        //设置钩子
        private KeyEventHandler keyEventHandler;
        private KeyboardHook hook = new KeyboardHook();
        private KeysBinding keyBinding;

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
            if (this.Visible) {
                this.Hide();
            } else {
                this.Show();
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
        private void bindKey() {
            keyBinding.registKeyFunction(Keys.Alt, Keys.M, e_change_mouse_penetrate);
            GridBinding.Add("鼠标穿透", e_change_mouse_penetrate);
            keyBinding.registKeyFunction(Keys.Alt, Keys.T, e_change_topest);
            GridBinding.Add("置顶", e_change_topest);
            keyBinding.registKeyFunction(Keys.Alt, Keys.D, e_drag_window);
            GridBinding.Add("拖动窗口", e_drag_window);
            keyBinding.registKeyFunction(Keys.Alt, Keys.S, e_main_window_show);
            GridBinding.Add("显示/隐藏窗口", e_main_window_show);
            keyBinding.registKeyFunction(Keys.Alt, Keys.Down, e_opacity_down);
            GridBinding.Add("降低透明度", e_opacity_down);
            keyBinding.registKeyFunction(Keys.Alt, Keys.Up, e_opacity_up);
            GridBinding.Add("提高透明度", e_opacity_up);
            keyBinding.registKeyFunction(Keys.Alt, Keys.B, e_change_show_mode);
            GridBinding.Add("切换显示模式", e_change_show_mode);
            keyBinding.registKeyFunction(Keys.Control, Keys.W, e_config_window_show);
            GridBinding.Add("显示配置窗口", e_config_window_show);
        }

        private void handleKey(object sender, KeyEventArgs e) {
            keyBinding.handleKeyFunction(Control.ModifierKeys, e.KeyCode);
        }


        private void startListen() {
            this.keyBinding = new KeysBinding();
            keyEventHandler = new KeyEventHandler(handleKey);
            hook.KeyDownEvent += keyEventHandler;
            hook.Start();
        }

        private void stopListen() {
            if (keyEventHandler != null) {
                hook.KeyDownEvent -= keyEventHandler;
                keyEventHandler = null;
                hook.Stop();
            }
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
                this.main_form.Show();
                topest.Checked = true;
            } else {
                this.main_form.Hide();
            }
        }



        //===========================表格绑定========================================================


        Dictionary<string, Action> GridBinding = new Dictionary<string, Action>();
        bool is_user_changed = false;


        void initGridData() {
            foreach (var e in GridBinding) {
                var tmp = keyBinding.getKey(e.Value);
                string modifier =
                    tmp.modifier == Keys.Shift ? "Shift" :
                    tmp.modifier == Keys.Control ? "Ctrl" :
                    tmp.modifier == Keys.Alt ? "Alt" : "None"
                ;
                string key = KeysBinding.reverseKeyNames[tmp.key];
                int index = keyBindingGrid.Rows.Add(e.Key, modifier, key);
            }
        }



        private void keyBindingGrid_KeyDown(object sender, KeyEventArgs e) {
            is_user_changed = false;
            e.Handled = true;//阻止事件传递
            if (keyBindingGrid.CurrentCell.ColumnIndex != 2) return;//判断是否为副键列
            if (Control.ModifierKeys == Keys.Alt || Control.ModifierKeys == Keys.Control || Control.ModifierKeys == Keys.Shift) {

                return;//这些应该在主键设置
            }

            string name = keyBindingGrid.CurrentRow.Cells[0].Value.ToString();//获取行头
            Action action = GridBinding[name];//通过行头获取绑定的事件函数
            var tmp = keyBinding.getKey(action);//获取原键组
            if (e.KeyCode == tmp.key) return;//判断是否和原键组相同

            string err = keyBinding.getError(keyBinding.registKeyFunction(tmp.modifier, e.KeyCode, action));//获取错误信息
            if (err != "") {
                MessageBox.Show(err);//显示错误信息
                return;
            }

            keyBindingGrid.CurrentCell.Value = KeysBinding.reverseKeyNames[e.KeyCode];//更新新键

            e.Handled = true;//阻止事件传递
        }

        private void keyBindingGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            //判断是否由程序更改
            if (!is_user_changed) return;
            is_user_changed = false;
            if (keyBindingGrid.CurrentCell.ColumnIndex != 1) return;
            String name = keyBindingGrid.CurrentRow.Cells[0].Value.ToString();
            Action action = GridBinding[name];
            var tmp = keyBinding.getKey(action);
            Keys m;
            switch (keyBindingGrid.CurrentCell.Value) {
                case "Shift":
                    m = Keys.Shift;
                    break;
                case "Ctrl":
                    m = Keys.Control;
                    break;
                case "Alt":
                    m = Keys.Alt;
                    break;
                default:
                    m = Keys.None;
                    break;
            }
            if (m == tmp.modifier) return;
            string err = keyBinding.getError(keyBinding.registKeyFunction(m, tmp.key, action));
        }

        private void keyBindingGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            is_user_changed = true;
        }

        private void keyBindingGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (!is_user_changed) return;
            if (keyBindingGrid.CurrentCell.ColumnIndex != 1) return;
            keyBindingGrid.EndEdit();
            is_user_changed = false;
        }

        private void button1_Click(object sender, EventArgs e) {
            new Form3().ShowDialog();
            System.GC.Collect();
        }
    }
}
