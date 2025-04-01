using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.PuestoPremiacion.csEstructuraPuestoPremiacion;

namespace api_OlimpiadasChapinas.Models.PuestoPremiacion
{
    public class csPuestoPremiacion
    {
        public responsePuestoPremiacion InsertarPuestoPremiacion(int idPuesto, string descripcion)
        {
            responsePuestoPremiacion result = new responsePuestoPremiacion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO PuestoPremiacion(idPuesto, descripcion) " +
                                    "VALUES(@idPuesto, @descripcion);";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPuesto", SqlDbType.Int).Value = idPuesto;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;

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

        public responsePuestoPremiacion ActualizarPuestoPremiacion(int idPuesto, string descripcion)
        {
            responsePuestoPremiacion result = new responsePuestoPremiacion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE PuestoPremiacion " +
                                    "SET descripcion = @descripcion " +
                                    "WHERE idPuesto = @idPuesto;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPuesto", SqlDbType.Int).Value = idPuesto;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;

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

        public responsePuestoPremiacion EliminarPuestoPremiacion(int idPuesto)
        {
            responsePuestoPremiacion result = new responsePuestoPremiacion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE PuestoPremiacion " +
                                    "WHERE idPuesto = @idPuesto;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPuesto", SqlDbType.Int).Value = idPuesto;

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

        public DataSet ListarPuestoPremiacion()
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM PuestoPremiacion";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if(result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista PuestoPremiacion";
                            }
                        }                        
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error en ListarPuestoPremiacion: ${ex.Message.ToString()}");
                    return null;
                }
            }

        }
    }
}