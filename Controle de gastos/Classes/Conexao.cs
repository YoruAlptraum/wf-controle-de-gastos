using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Controle_de_gastos.Classes
{
    public class Conexao
    {
        MySqlConnection con = new MySqlConnection();
        public Conexao()
        {
            con.ConnectionString = ("Server = localhost; Database = controledegastos; Uid = admcontroledegastos; Pwd = adm123");
        }
        //Método Conectar
        public MySqlConnection Conectar()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        //Método Desconectar
        public void Desconectar()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
