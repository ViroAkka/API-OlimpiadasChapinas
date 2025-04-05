using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.Premiacion.csEstructuraPremiacion;
using static api_OlimpiadasChapinas.Models.Inscripcion.csEstructuraInscripcion;

namespace api_OlimpiadasChapinas.Models.Inscripcion
{
    public class csInscripcion
    {
        public responseInscripcion InsertarInscripcion(int idEvento, int idParticipante, int idPago, string fuentePublicidad)
        {
            responseInscripcion result = new responseInscripcion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO Inscripcion(idEvento, idParticipante, idPago, fuentePublicidad) " +
                                    "VALUES(@idEvento, @idParticipante, @idPago, @fuentePublicidad);";
                    
                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;
                        cmd.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;
                        cmd.Parameters.Add("@fuentePublicidad", SqlDbType.VarChar, 100).Value = fuentePublicidad;


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

        public responseInscripcion ActualizarInscripcion(int idEvento, int idParticipante, int idPago, string fuentePublicidad, int idEventoActualizado, int idParticipanteActualizado, int idPagoActualizado)
        {
            responseInscripcion result = new responseInscripcion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE Inscripcion " +
                                    "SET idEvento = @idEventoActualizado, idParticipante = @idParticipanteActualizado, idPago = @idPagoActualizado, fuentePublicidad = @fuentePublicidad " +
                                    "WHERE idEvento = @idEvento AND idPago = @idPago AND idParticipante = @idParticipante;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;
                        cmd.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;
                        cmd.Parameters.Add("@fuentePublicidad", SqlDbType.VarChar, 100).Value = fuentePublicidad;
                        cmd.Parameters.Add("@idEventoActualizado", SqlDbType.Int).Value = idEventoActualizado;
                        cmd.Parameters.Add("@idParticipanteActualizado", SqlDbType.Int).Value = idParticipanteActualizado;
                        cmd.Parameters.Add("@idPagoActualizado", SqlDbType.Int).Value = idPagoActualizado;


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

        public responseInscripcion EliminarInscripcion(int idEvento, int idParticipante, int idPago)
        {
            responseInscripcion result = new responseInscripcion();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE Inscripcion " +
                                    "WHERE idEvento = @idEvento AND idPago = @idPago AND idParticipante = @idParticipante;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;
                        cmd.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;

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

        public DataSet ListarInscripcion()
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Inscripcion;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Inscripcion";
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

        public DataSet ListarInscripcionPorID(int idEvento, int idParticipante, int idPago)
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Inscripcion " +
                                    "WHERE idEvento = @idEvento AND idPago = @idPago AND idParticipante = @idParticipante;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;
                        cmd.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Inscripcion por ID";
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