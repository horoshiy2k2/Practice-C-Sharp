using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;database=itproger"); // password = root

        public void OpenConnection()
        {
            //если состояние объекта == закрыто
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open(); // подключение к БД
            }
        }

        public void CloseConnection()
        {
            //если состояние объекта == закрыто
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close(); // подключение к БД
            }
        }


        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
