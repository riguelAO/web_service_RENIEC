using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;



namespace BDReniec
{
    /// <summary>
    /// Descripción breve de wsReniec
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsReniec : System.Web.Services.WebService
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static SqlConnection conexion = new SqlConnection(cadena);



        [WebMethod(Description ="consultar DNI cliente")]
        public DataSet BuscarDNI(string dni)
        {
            SqlCommand comando = new SqlCommand("spBuscarDNI", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@DNI", dni);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet data = new DataSet();
            adapter.Fill(data);

            return data;
        }

        [WebMethod(Description = "Listar DNI clientes")]
        public DataSet ListarDNI()
        {
            SqlCommand comando = new SqlCommand("spListarDNI", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet data = new DataSet();
            adapter.Fill(data);

            return data;
        }

        [WebMethod(Description = "Agregar DNI cliente")]
        public DataSet AgregarDNI(string Coddni, string Nombres, string ApellidoPaterno,
            string ApellidoMaterno, string Sexo, int año, int mes, int dia, string Nacionalidad, string Dirección)
        {
            SqlCommand comando = new SqlCommand("spAgregarDNI", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            DateTime FecNacimiento = new DateTime(año,mes,dia);

            comando.Parameters.AddWithValue("@Coddni", Coddni);
            comando.Parameters.AddWithValue("@Nombres", Nombres);
            comando.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comando.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
            comando.Parameters.AddWithValue("@Sexo", Sexo);
            comando.Parameters.AddWithValue("@FecNacimiento", FecNacimiento);
            comando.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
            comando.Parameters.AddWithValue("@Dirección", Dirección);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet data = new DataSet();
            adapter.Fill(data);

            return data;
        }
        [WebMethod(Description = "Actualizar DNI cliente")]
        public DataSet ActualizarDNI(string Coddni, string Nombres, string ApellidoPaterno,
            string ApellidoMaterno, string Sexo, int año, int mes, int dia, string Nacionalidad, string Dirección)
        {
            SqlCommand comando = new SqlCommand("spActualizarDNI", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            DateTime FecNacimiento = new DateTime(año, mes, dia);

            comando.Parameters.AddWithValue("@Coddni", Coddni);
            comando.Parameters.AddWithValue("@Nombres", Nombres);
            comando.Parameters.AddWithValue("@ApellidoPaterno", ApellidoPaterno);
            comando.Parameters.AddWithValue("@ApellidoMaterno", ApellidoMaterno);
            comando.Parameters.AddWithValue("@Sexo", Sexo);
            comando.Parameters.AddWithValue("@FecNacimiento", FecNacimiento);
            comando.Parameters.AddWithValue("@Nacionalidad", Nacionalidad);
            comando.Parameters.AddWithValue("@Dirección", Dirección);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet data = new DataSet();
            adapter.Fill(data);

            return data;
        }

        [WebMethod(Description = "Eliminar DNI cliente")]
        public DataSet EliminarDNI(string dni)
        {
            SqlCommand comando = new SqlCommand("spEliminarDNI", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Coddni", dni);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataSet data = new DataSet();
            adapter.Fill(data);

            return data;
        }
    }
}
