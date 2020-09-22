namespace WindowsFormsApp1
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ButtonLogin = new System.Windows.Forms.Button();
            this.PassField = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LoginField = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(24)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.ButtonLogin);
            this.panel1.Controls.Add(this.PassField);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.LoginField);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 486);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // ButtonLogin
            // 
            this.ButtonLogin.BackColor = System.Drawing.Color.DarkOrange;
            this.ButtonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonLogin.FlatAppearance.BorderSize = 0;
            this.ButtonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(255)))), ((int)(((byte)(176)))));
            this.ButtonLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(12)))), ((int)(((byte)(63)))));
            this.ButtonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonLogin.Font = new System.Drawing.Font("Segoe UI Emoji", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLogin.ForeColor = System.Drawing.Color.Cornsilk;
            this.ButtonLogin.Location = new System.Drawing.Point(137, 365);
            this.ButtonLogin.Name = "ButtonLogin";
            this.ButtonLogin.Size = new System.Drawing.Size(210, 61);
            this.ButtonLogin.TabIndex = 6;
            this.ButtonLogin.Text = "Войти";
            this.ButtonLogin.UseVisualStyleBackColor = false;
            this.ButtonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // PassField
            // 
            this.PassField.Font = new System.Drawing.Font("Modern No. 20", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassField.Location = new System.Drawing.Point(112, 253);
            this.PassField.Name = "PassField";
            this.PassField.Size = new System.Drawing.Size(310, 54);
            this.PassField.TabIndex = 5;
            this.PassField.UseSystemPasswordChar = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.iconfinder_General_Office_40_3592828;
            this.pictureBox3.Location = new System.Drawing.Point(28, 253);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 64);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // LoginField
            // 
            this.LoginField.Font = new System.Drawing.Font("Modern No. 20", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginField.Location = new System.Drawing.Point(112, 158);
            this.LoginField.Multiline = true;
            this.LoginField.Name = "LoginField";
            this.LoginField.Size = new System.Drawing.Size(310, 64);
            this.LoginField.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsFormsApp1.Properties.Resources.user;
            this.pictureBox2.Location = new System.Drawing.Point(28, 158);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkOrange;
            this.panel2.Controls.Add(this.CloseButton);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 110);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // CloseButton
            // 
            this.CloseButton.AutoSize = true;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(24)))), ((int)(((byte)(69)))));
            this.CloseButton.Location = new System.Drawing.Point(429, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 36);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "x";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(24)))), ((int)(((byte)(69)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "Авторизация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(459, 486);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox LoginField;
        private System.Windows.Forms.Button ButtonLogin;
    }
}