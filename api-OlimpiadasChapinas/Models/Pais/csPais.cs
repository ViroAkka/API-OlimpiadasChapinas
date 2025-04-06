using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.Pais.csEstructuraPais;

namespace api_OlimpiadasChapinas.Models.Pais
{
    public class csPais
    {
        public responsePais InsertarPais(string idPais, string nombre)
        {
            responsePais result = new responsePais();
            string conexion = "";
            
            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = $"INSERT INTO Pais(idPais, nombre) " +
                                    $"VALUES(@idPais, @nombre);";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPais", SqlDbType.Char, 3).Value = idPais;
                        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = nombre;

                        result.respuesta = cmd.ExecuteNonQuery();
                        result.descripcionRespuesta = "Operación realizada exitosamente.";
                    } 
                }
                catch (Exception ex)
                {
                    result.respuesta = 0;
                    result.descripcionRespuesta = $"Ocurrió un error al realizar la transacción: {ex.Message.ToString()}";
                }
            }

            return result;
        }

        public responsePais ActualizarPais(string idPais, string nombre)
        {
            responsePais result = new responsePais();
            string conexion = "";
            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {

                try
                {
                    con.Open();

                    string cadena = $"UPDATE Pais SET nombre = @nombre " +
                                    $"WHERE idPais = @idPais;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = nombre;
                        cmd.Parameters.Add("@idPais", SqlDbType.Char, 3).Value = idPais;

                        result.respuesta = cmd.ExecuteNonQuery();
                        result.descripcionRespuesta = "Operación realizada exitosamente.";
                    }
                }
                catch (Exception ex)
                {
                    result.respuesta = 0;
                    result.descripcionRespuesta = $"Ocurrió un error al realizar la transacción: {ex.Message.ToString()}";
                }
            }

            return result;
        }

        public responsePais EliminarPais(string idPais)
        {
            responsePais result = new responsePais();
            string conexion = "";
            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = $"DELETE Pais WHERE idPais = @idPais;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPais", SqlDbType.Char, 3).Value = idPais;

                        result.respuesta = cmd.ExecuteNonQuery();
                        result.descripcionRespuesta = "Operación realizada exitosamente.";
                    }
                }
                catch (Exception ex)
                {
                    result.respuesta = 0;
                    result.descripcionRespuesta = $"Ocurrió un error en la transacción: {ex.Message.ToString()}";
                }
            }

            return result;
        }

        public DataSet ListarPais()
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using(SqlConnection con = new SqlConnection(conexion))
            {
                try
                {                
                    con.Open();

                    string cadena = "SELECT * FROM Pais;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);
                            
                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista";
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en listarPais: {ex.Message.ToString()}");
                    return null;
                }
            }
        }

        public DataSet ListarPaisPorID(string idPais)
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Pais WHERE idPais = @idPais;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPais", SqlDbType.Char, 3).Value = idPais;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista";
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en listarPais: {ex.Message.ToString()}");
                    return null;
                }
            }
        }
    }
}