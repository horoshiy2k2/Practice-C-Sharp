namespace ConverterTohiWinForm
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
            this.TBNum1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Sys2RB1 = new System.Windows.Forms.RadioButton();
            this.num2Label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Sys10RB1 = new System.Windows.Forms.RadioButton();
            this.Sys8RB1 = new System.Windows.Forms.RadioButton();
            this.Sys16RB1 = new System.Windows.Forms.RadioButton();
            this.Sys16RB2 = new System.Windows.Forms.RadioButton();
            this.Sys10RB2 = new System.Windows.Forms.RadioButton();
            this.Sys8RB2 = new System.Windows.Forms.RadioButton();
            this.Sys2RB2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Sys777RB1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Sys777RB2 = new System.Windows.Forms.RadioButton();
            this.labelHelp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBNum1
            // 
            this.TBNum1.Location = new System.Drawing.Point(140, 227);
            this.TBNum1.Name = "TBNum1";
            this.TBNum1.Size = new System.Drawing.Size(225, 22);
            this.TBNum1.TabIndex = 0;
            this.TBNum1.TextChanged += new System.EventHandler(this.Num1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Система счисления числа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(480, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "В какую систему счисления перевести";
            // 
            // Sys2RB1
            // 
            this.Sys2RB1.AutoSize = true;
            this.Sys2RB1.BackColor = System.Drawing.SystemColors.Control;
            this.Sys2RB1.Location = new System.Drawing.Point(19, 21);
            this.Sys2RB1.Name = "Sys2RB1";
            this.Sys2RB1.Size = new System.Drawing.Size(113, 24);
            this.Sys2RB1.TabIndex = 4;
            this.Sys2RB1.Text = "Двоичная";
            this.Sys2RB1.UseVisualStyleBackColor = false;
            this.Sys2RB1.CheckedChanged += new System.EventHandler(this.Sys2RB1_CheckedChanged);
            // 
            // num2Label
            // 
            this.num2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.num2Label.Location = new System.Drawing.Point(522, 206);
            this.num2Label.Name = "num2Label";
            this.num2Label.Size = new System.Drawing.Size(366, 128);
            this.num2Label.TabIndex = 5;
            this.num2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(205, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Число";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(597, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Результат";
            // 
            // Sys10RB1
            // 
            this.Sys10RB1.AutoSize = true;
            this.Sys10RB1.Checked = true;
            this.Sys10RB1.Location = new System.Drawing.Point(19, 75);
            this.Sys10RB1.Name = "Sys10RB1";
            this.Sys10RB1.Size = new System.Drawing.Size(132, 24);
            this.Sys10RB1.TabIndex = 11;
            this.Sys10RB1.TabStop = true;
            this.Sys10RB1.Text = "Десятичная";
            this.Sys10RB1.UseVisualStyleBackColor = true;
            this.Sys10RB1.CheckedChanged += new System.EventHandler(this.Sys10RB1_CheckedChanged);
            // 
            // Sys8RB1
            // 
            this.Sys8RB1.AutoSize = true;
            this.Sys8RB1.Location = new System.Drawing.Point(19, 48);
            this.Sys8RB1.Name = "Sys8RB1";
            this.Sys8RB1.Size = new System.Drawing.Size(153, 24);
            this.Sys8RB1.TabIndex = 10;
            this.Sys8RB1.Text = "Восьмиричная";
            this.Sys8RB1.UseVisualStyleBackColor = true;
            this.Sys8RB1.CheckedChanged += new System.EventHandler(this.Sys8RB1_CheckedChanged);
            // 
            // Sys16RB1
            // 
            this.Sys16RB1.AutoSize = true;
            this.Sys16RB1.Location = new System.Drawing.Point(19, 102);
            this.Sys16RB1.Name = "Sys16RB1";
            this.Sys16RB1.Size = new System.Drawing.Size(205, 24);
            this.Sys16RB1.TabIndex = 17;
            this.Sys16RB1.Text = "Шестнадцатиричная";
            this.Sys16RB1.UseVisualStyleBackColor = true;
            this.Sys16RB1.CheckedChanged += new System.EventHandler(this.Sys16RB1_CheckedChanged);
            // 
            // Sys16RB2
            // 
            this.Sys16RB2.AutoSize = true;
            this.Sys16RB2.Location = new System.Drawing.Point(31, 102);
            this.Sys16RB2.Name = "Sys16RB2";
            this.Sys16RB2.Size = new System.Drawing.Size(205, 24);
            this.Sys16RB2.TabIndex = 22;
            this.Sys16RB2.Text = "Шестнадцатиричная";
            this.Sys16RB2.UseVisualStyleBackColor = true;
            this.Sys16RB2.CheckedChanged += new System.EventHandler(this.Sys16RB2_CheckedChanged);
            // 
            // Sys10RB2
            // 
            this.Sys10RB2.AutoSize = true;
            this.Sys10RB2.Location = new System.Drawing.Point(31, 75);
            this.Sys10RB2.Name = "Sys10RB2";
            this.Sys10RB2.Size = new System.Drawing.Size(132, 24);
            this.Sys10RB2.TabIndex = 21;
            this.Sys10RB2.Text = "Десятичная";
            this.Sys10RB2.UseVisualStyleBackColor = true;
            this.Sys10RB2.CheckedChanged += new System.EventHandler(this.Sys10RB2_CheckedChanged);
            // 
            // Sys8RB2
            // 
            this.Sys8RB2.AutoSize = true;
            this.Sys8RB2.Location = new System.Drawing.Point(31, 48);
            this.Sys8RB2.Name = "Sys8RB2";
            this.Sys8RB2.Size = new System.Drawing.Size(153, 24);
            this.Sys8RB2.TabIndex = 20;
            this.Sys8RB2.Text = "Восьмиричная";
            this.Sys8RB2.UseVisualStyleBackColor = true;
            this.Sys8RB2.CheckedChanged += new System.EventHandler(this.Sys8RB2_CheckedChanged);
            // 
            // Sys2RB2
            // 
            this.Sys2RB2.AutoSize = true;
            this.Sys2RB2.BackColor = System.Drawing.SystemColors.Control;
            this.Sys2RB2.Checked = true;
            this.Sys2RB2.Location = new System.Drawing.Point(31, 16);
            this.Sys2RB2.Name = "Sys2RB2";
            this.Sys2RB2.Size = new System.Drawing.Size(113, 24);
            this.Sys2RB2.TabIndex = 18;
            this.Sys2RB2.TabStop = true;
            this.Sys2RB2.Text = "Двоичная";
            this.Sys2RB2.UseVisualStyleBackColor = false;
            this.Sys2RB2.CheckedChanged += new System.EventHandler(this.Sys2RB2_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Sys777RB1);
            this.groupBox1.Controls.Add(this.Sys2RB1);
            this.groupBox1.Controls.Add(this.Sys16RB1);
            this.groupBox1.Controls.Add(this.Sys10RB1);
            this.groupBox1.Controls.Add(this.Sys8RB1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(140, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 159);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // Sys777RB1
            // 
            this.Sys777RB1.AutoSize = true;
            this.Sys777RB1.Location = new System.Drawing.Point(20, 129);
            this.Sys777RB1.Name = "Sys777RB1";
            this.Sys777RB1.Size = new System.Drawing.Size(101, 24);
            this.Sys777RB1.TabIndex = 18;
            this.Sys777RB1.Text = "Римская";
            this.Sys777RB1.UseVisualStyleBackColor = true;
            this.Sys777RB1.CheckedChanged += new System.EventHandler(this.Sys777RB1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Sys777RB2);
            this.groupBox2.Controls.Add(this.Sys2RB2);
            this.groupBox2.Controls.Add(this.Sys16RB2);
            this.groupBox2.Controls.Add(this.Sys8RB2);
            this.groupBox2.Controls.Add(this.Sys10RB2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(531, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 159);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            // 
            // Sys777RB2
            // 
            this.Sys777RB2.AutoSize = true;
            this.Sys777RB2.Location = new System.Drawing.Point(31, 129);
            this.Sys777RB2.Name = "Sys777RB2";
            this.Sys777RB2.Size = new System.Drawing.Size(101, 24);
            this.Sys777RB2.TabIndex = 23;
            this.Sys777RB2.Text = "Римская";
            this.Sys777RB2.UseVisualStyleBackColor = true;
            this.Sys777RB2.CheckedChanged += new System.EventHandler(this.Sys777RB2_CheckedChanged);
            // 
            // labelHelp
            // 
            this.labelHelp.Font = new System.Drawing.Font("MingLiU-ExtB", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp.Location = new System.Drawing.Point(109, 334);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(706, 120);
            this.labelHelp.TabIndex = 27;
            this.labelHelp.Text = "0 1 2 3 4 5 6 7 8 9";
            this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(286, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Допустимые цифры числа";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.num2Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBNum1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBNum1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Sys2RB1;
        private System.Windows.Forms.Label num2Label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Sys10RB1;
        private System.Windows.Forms.RadioButton Sys8RB1;
        private System.Windows.Forms.RadioButton Sys16RB1;
        private System.Windows.Forms.RadioButton Sys16RB2;
        private System.Windows.Forms.RadioButton Sys10RB2;
        private System.Windows.Forms.RadioButton Sys8RB2;
        private System.Windows.Forms.RadioButton Sys2RB2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton Sys777RB1;
        private System.Windows.Forms.RadioButton Sys777RB2;
    }
}

