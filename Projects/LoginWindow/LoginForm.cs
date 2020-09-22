using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            
            InitializeComponent();
            this.PassField.Size = new Size(this.PassField.Size.Width, this.LoginField.Size.Height);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.FromArgb(0, 88, 24, 69);
        }

        Point lastPosition;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPosition.X;
                this.Top += e.Y - lastPosition.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPosition = new Point(e.X, e.Y);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPosition.X;
                this.Top += e.Y - lastPosition.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPosition = new Point(e.X, e.Y);
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string loginUser = LoginField.Text;
            string passUser = PassField.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //команда, которая должна выполниться
            //параметр - команда sql, метод функции (для открытия)
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.GetConnection()); // заглушки @ для безопасности

            //меняем в команде заглушки на нужные значения
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command; // позволяет выбрать данные из БД
            adapter.Fill(table); // заполняем объект table данными по запросу command

            if(table.Rows.Count > 0) // елси количество рядов (записей) > 0 (если хоть что-то в таблице есть)
            {
                MessageBox.Show("Пользователь авторизован");
            }
            else
            {
                MessageBox.Show("Пользователь не авторизован");
            }
        }
    }
}
