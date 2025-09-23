namespace depictPicture {
    partial class Form2 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sizemode_ = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.show_window = new System.Windows.Forms.CheckBox();
            this.mouse_penetrate = new System.Windows.Forms.CheckBox();
            this.topest = new System.Windows.Forms.CheckBox();
            this.drag_window = new System.Windows.Forms.CheckBox();
            this.opacity_num = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.keyBindingGrid = new System.Windows.Forms.DataGridView();
            this.EventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyKey = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.keyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacity_num)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Ivory;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(182, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择图片";
            // 
            // sizemode_
            // 
            this.sizemode_.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sizemode_.FormattingEnabled = true;
            this.sizemode_.Items.AddRange(new object[] {
            "居中",
            "拉伸",
            "平铺",
            "正常",
            "自动缩放"});
            this.sizemode_.Location = new System.Drawing.Point(13, 117);
            this.sizemode_.Name = "sizemode_";
            this.sizemode_.Size = new System.Drawing.Size(162, 23);
            this.sizemode_.TabIndex = 2;
            this.sizemode_.Text = "正常";
            this.sizemode_.SelectedValueChanged += new System.EventHandler(this.sizemode__SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(182, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "显示方式";
            // 
            // show_window
            // 
            this.show_window.AutoSize = true;
            this.show_window.Checked = true;
            this.show_window.CheckState = System.Windows.Forms.CheckState.Checked;
            this.show_window.Location = new System.Drawing.Point(5, 31);
            this.show_window.Name = "show_window";
            this.show_window.Size = new System.Drawing.Size(93, 19);
            this.show_window.TabIndex = 3;
            this.show_window.Text = "显示窗口";
            this.show_window.UseVisualStyleBackColor = true;
            this.show_window.CheckedChanged += new System.EventHandler(this.show_window_CheckedChanged);
            // 
            // mouse_penetrate
            // 
            this.mouse_penetrate.AutoSize = true;
            this.mouse_penetrate.Location = new System.Drawing.Point(216, 6);
            this.mouse_penetrate.Name = "mouse_penetrate";
            this.mouse_penetrate.Size = new System.Drawing.Size(93, 19);
            this.mouse_penetrate.TabIndex = 2;
            this.mouse_penetrate.Text = "鼠标穿透";
            this.mouse_penetrate.UseVisualStyleBackColor = true;
            this.mouse_penetrate.CheckedChanged += new System.EventHandler(this.mouse_penetrate_CheckedChanged);
            // 
            // topest
            // 
            this.topest.AutoSize = true;
            this.topest.Location = new System.Drawing.Point(117, 6);
            this.topest.Name = "topest";
            this.topest.Size = new System.Drawing.Size(93, 19);
            this.topest.TabIndex = 1;
            this.topest.Text = "窗口置顶";
            this.topest.UseVisualStyleBackColor = true;
            this.topest.CheckedChanged += new System.EventHandler(this.topest_CheckedChanged);
            // 
            // drag_window
            // 
            this.drag_window.AutoSize = true;
            this.drag_window.Location = new System.Drawing.Point(6, 6);
            this.drag_window.Name = "drag_window";
            this.drag_window.Size = new System.Drawing.Size(93, 19);
            this.drag_window.TabIndex = 0;
            this.drag_window.Text = "拖动窗口";
            this.drag_window.UseVisualStyleBackColor = true;
            this.drag_window.CheckedChanged += new System.EventHandler(this.drag_window_CheckedChanged);
            // 
            // opacity_num
            // 
            this.opacity_num.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.opacity_num.Location = new System.Drawing.Point(13, 162);
            this.opacity_num.Name = "opacity_num";
            this.opacity_num.Size = new System.Drawing.Size(162, 24);
            this.opacity_num.TabIndex = 5;
            this.opacity_num.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.opacity_num.ValueChanged += new System.EventHandler(this.opacity_num_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(182, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "透明度";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(259, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(414, 253);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.show_window);
            this.tabPage1.Controls.Add(this.drag_window);
            this.tabPage1.Controls.Add(this.mouse_penetrate);
            this.tabPage1.Controls.Add(this.topest);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(406, 224);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "操作";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.keyBindingGrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(406, 224);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "热键";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // keyBindingGrid
            // 
            this.keyBindingGrid.AllowUserToAddRows = false;
            this.keyBindingGrid.AllowUserToDeleteRows = false;
            this.keyBindingGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.keyBindingGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventName,
            this.ModifyKey,
            this.keyColumn});
            this.keyBindingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyBindingGrid.Location = new System.Drawing.Point(3, 3);
            this.keyBindingGrid.Name = "keyBindingGrid";
            this.keyBindingGrid.RowHeadersVisible = false;
            this.keyBindingGrid.RowHeadersWidth = 51;
            this.keyBindingGrid.RowTemplate.Height = 27;
            this.keyBindingGrid.Size = new System.Drawing.Size(400, 218);
            this.keyBindingGrid.TabIndex = 0;
            this.keyBindingGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.keyBindingGrid_CellMouseClick);
            this.keyBindingGrid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.keyBindingGrid_CellMouseLeave);
            this.keyBindingGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.keyBindingGrid_CellValueChanged);
            this.keyBindingGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyBindingGrid_KeyDown);
            // 
            // EventName
            // 
            this.EventName.HeaderText = "事件";
            this.EventName.MinimumWidth = 6;
            this.EventName.Name = "EventName";
            this.EventName.ReadOnly = true;
            this.EventName.Width = 200;
            // 
            // ModifyKey
            // 
            this.ModifyKey.FillWeight = 80F;
            this.ModifyKey.HeaderText = "主控键";
            this.ModifyKey.Items.AddRange(new object[] {
            "Alt",
            "Ctrl",
            "None",
            "Shift"});
            this.ModifyKey.MinimumWidth = 6;
            this.ModifyKey.Name = "ModifyKey";
            this.ModifyKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ModifyKey.Width = 125;
            // 
            // keyColumn
            // 
            this.keyColumn.FillWeight = 80F;
            this.keyColumn.HeaderText = "副键";
            this.keyColumn.MinimumWidth = 6;
            this.keyColumn.Name = "keyColumn";
            this.keyColumn.ReadOnly = true;
            this.keyColumn.ToolTipText = "如:A,B,1等";
            this.keyColumn.Width = 125;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("幼圆", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(598, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "关于";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 306);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.opacity_num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizemode_);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "配置";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacity_num)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.keyBindingGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sizemode_;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox drag_window;
        private System.Windows.Forms.CheckBox mouse_penetrate;
        private System.Windows.Forms.NumericUpDown opacity_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox show_window;
        private System.Windows.Forms.CheckBox topest;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView keyBindingGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ModifyKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyColumn;
        private System.Windows.Forms.Button button1;
    }
}