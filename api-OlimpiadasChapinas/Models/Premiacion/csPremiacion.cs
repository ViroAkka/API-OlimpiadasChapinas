using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.Premiacion.csEstructuraPremiacion;

namespace api_OlimpiadasChapinas.Models.Premiacion
{
    public class csPremiacion
    {
        public responsePremiacion InsertarPremiacion(int idEvento, int idPuesto, int idParticipante)
        {
            responsePremiacion result = new responsePremiacion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO Premiacion(idEvento, idPuesto, idParticipante) " +
                                    "VALUES(@idEvento, @idPuesto, @idParticipante);";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        cmd.Parameters.Add("@idPuesto", SqlDbType.Int).Value = idPuesto;
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;

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

        public responsePremiacion ActualizarPremiacion(int idPremiacion, int idEvento, int idPuesto, int idParticipante)
        {
            responsePremiacion result = new responsePremiacion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE Premiacion " +
                                    "SET idEvento = @idEvento, idPuesto = @idPuesto, idParticipante = @idParticipante " +
                                    "WHERE idPremiacion = @idPremiacion;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPremiacion", SqlDbType.Int).Value = idPremiacion;
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        cmd.Parameters.Add("@idPuesto", SqlDbType.Int).Value = idPuesto;
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;

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

        public responsePremiacion EliminarPremiacion(int idPremiacion)
        {
            responsePremiacion result = new responsePremiacion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE Premiacion " +
                                    "WHERE idPremiacion = @idPremiacion;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPremiacion", SqlDbType.Int).Value = idPremiacion;

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

        public DataSet ListarPremiacion()
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Premiacion;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if(result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Premiacion";
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error en ListarPremiacion: {ex.Message.ToString()}");
                    return null;
                }
            }
        }

        public DataSet ListarPremiacionPorID(int idPremiacion)
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Premiacion WHERE idPremiacion = @idPremiacion;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPremiacion", SqlDbType.Int).Value = idPremiacion;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Premiacion";
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocurrió un error en ListarPremiacion: {ex.Message.ToString()}");
                    return null;
                }
            }
        }
    }
}