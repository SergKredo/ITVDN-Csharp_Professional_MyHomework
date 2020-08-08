namespace Task_3_New_Reflector
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Browse = new System.Windows.Forms.Button();
            this.browser = new System.Windows.Forms.TextBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.button_Display = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 43);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(776, 395);
            this.textBox1.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // Browse
            // 
            this.Browse.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Browse.Location = new System.Drawing.Point(712, 12);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 23);
            this.Browse.TabIndex = 2;
            this.Browse.Text = "Save file...";
            this.Browse.UseVisualStyleBackColor = false;
            this.Browse.Click += new System.EventHandler(this.button1_Click);
            // 
            // browser
            // 
            this.browser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.browser.Location = new System.Drawing.Point(11, 12);
            this.browser.Multiline = true;
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(621, 23);
            this.browser.TabIndex = 3;
            // 
            // button_Search
            // 
            this.button_Search.Location = new System.Drawing.Point(638, 12);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(68, 23);
            this.button_Search.TabIndex = 4;
            this.button_Search.Text = "Open file...";
            this.button_Search.UseVisualStyleBackColor = true;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // checkedListBox
            // 
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.ColumnWidth = 180;
            this.checkedListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Abstract Class",
            "Interface",
            "Class",
            "Static Class",
            "Nested Class",
            "Struct",
            "Delegate",
            "Event",
            "Field",
            "Property",
            "Method",
            "Constructor",
            "Type attribute information",
            "Type member attribute information"});
            this.checkedListBox.Location = new System.Drawing.Point(11, 444);
            this.checkedListBox.MultiColumn = true;
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBox.Size = new System.Drawing.Size(621, 79);
            this.checkedListBox.TabIndex = 7;
            // 
            // button_Display
            // 
            this.button_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Display.Location = new System.Drawing.Point(638, 444);
            this.button_Display.Name = "button_Display";
            this.button_Display.Padding = new System.Windows.Forms.Padding(1);
            this.button_Display.Size = new System.Drawing.Size(149, 79);
            this.button_Display.TabIndex = 8;
            this.button_Display.Text = "Display";
            this.button_Display.UseVisualStyleBackColor = true;
            this.button_Display.Click += new System.EventHandler(this.button_Display_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.button_Display);
            this.Controls.Add(this.checkedListBox);
            this.Controls.Add(this.button_Search);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.textBox1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reflector by SergKredo";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.TextBox browser;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private System.Windows.Forms.Button button_Display;
    }
}

