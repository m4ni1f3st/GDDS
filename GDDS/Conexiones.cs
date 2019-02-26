using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace GDDS
{
    class Conexiones
    {

        //private List<string> obtener_mail()
        public List<string> obtener_mail()
        {
            int h = 1;
            List<string> list = new List<string>();


            var applicationSettings = ConfigurationManager.GetSection("connectionStrings")
               as NameValueCollection;

            if (applicationSettings.Count == 0)
            {
                Console.WriteLine("Application Settings are not defined");
            }
            else
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    string v = "Correo" + h;
                    if (v == key)
                    {
                        //Console.WriteLine(key + " = " + applicationSettings[key]);
                        list.Add(applicationSettings[key]);
                    }
                    h++;
                }
            }
            return list;
        }

        public void obtener_bases()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["Conexion1"];
            SqlConnection sqlConnection = new SqlConnection(connectionStringSettings.ConnectionString);

            string consulta_ = string.Empty;
            consulta_ = "select convert(int, par_importe1) AS IDDIS from pnc_parametr where par_tipopara = 'iddis'";
            DataTable tabla = new DataTable();
            string kopr = string.Empty;

            try
            {
                sqlConnection.Open();
                SqlDataAdapter AdaptadorTabla = new SqlDataAdapter(consulta_, sqlConnection); // Usaremos un DataAdapter para leer los datos
                AdaptadorTabla.Fill(tabla);// Llenamos la tabla con los datos leídos
                kopr = tabla.Rows[0]["IDDIS"].ToString();//guardo informacion en variables
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                Console.WriteLine("El Codigo es: " + kopr);
            }
            catch (Exception error)
            {
                Console.WriteLine("Ocurrio un error: " + error.Message);
            }
        }
    }
}
