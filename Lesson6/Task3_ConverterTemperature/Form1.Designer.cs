namespace Task3_ConverterTemperature
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
            this.textBox_Celcia = new System.Windows.Forms.TextBox();
            this.textBox_Farinhate = new System.Windows.Forms.TextBox();
            this.textBox_Kelvine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Celcia
            // 
            this.textBox_Celcia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Celcia.Location = new System.Drawing.Point(15, 17);
            this.textBox_Celcia.Multiline = true;
            this.textBox_Celcia.Name = "textBox_Celcia";
            this.textBox_Celcia.Size = new System.Drawing.Size(161, 29);
            this.textBox_Celcia.TabIndex = 0;
            this.textBox_Celcia.Text = "0";
            this.textBox_Celcia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Celcia.TextChanged += new System.EventHandler(this.textBox_Celcia_TextChanged);
            // 
            // textBox_Farinhate
            // 
            this.textBox_Farinhate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Farinhate.Location = new System.Drawing.Point(15, 94);
            this.textBox_Farinhate.Multiline = true;
            this.textBox_Farinhate.Name = "textBox_Farinhate";
            this.textBox_Farinhate.Size = new System.Drawing.Size(161, 29);
            this.textBox_Farinhate.TabIndex = 1;
            this.textBox_Farinhate.Text = "0";
            this.textBox_Farinhate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Farinhate.TextChanged += new System.EventHandler(this.textBox_Farinhate_TextChanged);
            // 
            // textBox_Kelvine
            // 
            this.textBox_Kelvine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Kelvine.Location = new System.Drawing.Point(15, 55);
            this.textBox_Kelvine.Multiline = true;
            this.textBox_Kelvine.Name = "textBox_Kelvine";
            this.textBox_Kelvine.Size = new System.Drawing.Size(161, 29);
            this.textBox_Kelvine.TabIndex = 2;
            this.textBox_Kelvine.Text = "0";
            this.textBox_Kelvine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Kelvine.TextChanged += new System.EventHandler(this.textBox_Kelvine_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(187, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "degree Celsius (°C)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(189, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "degree Fahrenheit (°F)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(180, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "degree Kelvin (K)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 144);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Kelvine);
            this.Controls.Add(this.textBox_Farinhate);
            this.Controls.Add(this.textBox_Celcia);
            this.MaximumSize = new System.Drawing.Size(390, 183);
            this.MinimumSize = new System.Drawing.Size(390, 183);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Celcia;
        private System.Windows.Forms.TextBox textBox_Farinhate;
        private System.Windows.Forms.TextBox textBox_Kelvine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

