using System.Data.SqlClient;
using System.Data;
using System;

namespace presentacion
{
    internal class conexion
    {

        static SqlConnection cnx;
        static string cadena = @"Server=LAPTOP-5H1JL3D4\SQLEXPRESS;Database=AltasBajasCambios;Trusted_Connection=True;";

        private static void conectar()
        {
            cnx=new SqlConnection(cadena);
            cnx.Open();
        }

        private static void Desconectar()
        {
            cnx.Close();
            cnx=null;
        }

        public static int EjecutaConsulta(string consulta)
        {
            int filasAfectadas = 0;
            conectar();
            SqlCommand cmd= new SqlCommand(consulta, cnx);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }

        public static DataTable EjecutaSeleccion(string consulta)
        {   
            DataTable dt = new DataTable();
            conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt;
        }

        public static Object EjecutaEscalar(string consulta)
        {
            DataTable dt = new DataTable();
            conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt.Rows[0].ItemArray[0];
        }
    }
}
