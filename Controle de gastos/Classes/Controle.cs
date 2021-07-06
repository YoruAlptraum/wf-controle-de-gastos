using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controle_de_gastos.Classes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
namespace Controle_de_gastos.Classes
{
    public class Controle
    {
        Conexao con = new Conexao();
        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;

        //Procurar todos os anos/tabelas
        public DataTable ControleAnos()
        {
            cmd = new MySqlCommand();
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable("cmbAnos");

            cmd.CommandText = @"show tables";
            try
            {
                cmd.Connection = con.Conectar();
                da.Fill(dt);
            } 
            catch (MySqlException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                con.Desconectar();
            }
            return dt;
        }

        //Sem filtro
        public DataTable dtLvwControle(string ano, int mes, bool anoInteiro)
        {
            cmd = new MySqlCommand();
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            if (anoInteiro)
            {
                cmd.CommandText = $@"select * from {ano}";
            }
            else
            {
                cmd.CommandText = $@"select * from {ano}
                                     where month(dataRegistro) = @mes";
                cmd.Parameters.AddWithValue("@mes", mes);
            }

            try
            {
                cmd.Connection = con.Conectar();
                da.Fill(dt);
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                con.Desconectar();
            }
            return dt;
        }
        //Com filtro
        public DataTable dtLvwControle(string ano,int mes,bool anoInteiro, bool receita)
        {
            cmd = new MySqlCommand();
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            if (anoInteiro)
            {
                if (receita)
                {
                    cmd.CommandText = $@"select *
                    from {ano}
                    where valor >= 0;";
                }
                else
                {
                    cmd.CommandText = $@"select *
                    from {ano}
                    where valor < 0;";
                }
            }
            else
            {
                if (receita)
                {
                    cmd.CommandText = $@"select *
                    from {ano}
                    where valor >= 0 and month(dataRegistro) = @mes;";
                    cmd.Parameters.AddWithValue("@mes",mes);
                }
                else
                {
                    cmd.CommandText = $@"select *
                    from {ano}
                    where valor < 0 and month(dataRegistro) = @mes;";
                    cmd.Parameters.AddWithValue("@mes", mes);
                }
            }

            try
            {
                cmd.Connection = con.Conectar();
                da.Fill(dt);
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                con.Desconectar();
            }
            return dt;
        }

        //Insert
        public void NovoRegistro(string ano,string descriçao,bool previsao, double valor,DateTime dataRegistro)
        {
            int prev;
            if (previsao) prev = 1;
            else prev = 0;
            cmd = new MySqlCommand();
            cmd.CommandText = $@"
                insert into {ano} (descriçao,previsao,valor,dataRegistro)
                values 
                (@descriçao, @prev, @valor,@dataRegistro);";
            cmd.Parameters.AddWithValue("@descriçao", descriçao);
            cmd.Parameters.AddWithValue("@prev", prev);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@dataRegistro", dataRegistro);
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                con.Desconectar();
            }
        }        
        //Update
        public void AlterarRegistro(string ano,string descriçao, bool previsao, double valor, DateTime dataRegistro,int id)
        {
            int prev;
            if (previsao) prev = 1;
            else prev = 0;
            cmd = new MySqlCommand();
            cmd.CommandText = $@"
                update {ano}
	            set descriçao = @descriçao,
		            valor = @valor,
                    previsao = @prev,
                    dataRegistro = @dataRegistro
	            where id = @id;";
            cmd.Parameters.AddWithValue("@descriçao", descriçao);
            cmd.Parameters.AddWithValue("@prev", prev);
            cmd.Parameters.AddWithValue("@valor", valor);
            cmd.Parameters.AddWithValue("@dataRegistro", dataRegistro);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                con.Desconectar();
            }
        }
        public void RemoverRegistro(string ano,int id)
        {
            cmd = new MySqlCommand();
            cmd.CommandText = $@"
                delete from {ano}
	            where id = @id;";
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("removido");
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                con.Desconectar();
            }
        }
        public string NovoAno(int ano)
        {
            string m = "";
            cmd = new MySqlCommand();
            cmd.CommandText = $@"create table controle{ano}(
                id bigint primary key auto_increment,
                descriçao varchar(255),
                previsao bit(1),
                valor double,
                dataRegistro date)";
            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                m = "Tabela criada";
                Debug.WriteLine(m);
            }
            catch (MySqlException e)
            {
                m = "Não foi possivel criar a tabela : "+ e.Message;
                Debug.WriteLine(m);
            }
            finally
            {
                con.Desconectar();
            }
            return m;
        }
    }
}
