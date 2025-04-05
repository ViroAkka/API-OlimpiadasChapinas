using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.Participante.csEstructuraParticipante;

namespace api_OlimpiadasChapinas.Models.Participante
{
    public class csParticipante
    {
        public responseParticipante InsertarParticipante(string idPais, int idUsuario, string fechaNacimiento, double altura, double peso, string genero)
        {
            responseParticipante result = new responseParticipante();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO Participante(idPais, idUsuario, fechaNacimiento, altura, peso, genero)" +
                                    "VALUES(@idPais, @idUsuario, @fechaNacimiento, @altura, @peso, @genero);";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPais", SqlDbType.Char, 3).Value = idPais;
                        cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        cmd.Parameters.Add("@fechaNacimiento", SqlDbType.Date).Value = fechaNacimiento;
                        cmd.Parameters.Add(new SqlParameter{
                            ParameterName = "@altura",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 5,
                            Scale = 2,
                            Value = altura
                        });
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@peso",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 5,
                            Scale = 2,
                            Value = peso
                        });
                        cmd.Parameters.Add("@genero", SqlDbType.Char, 5).Value = genero;

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

        public responseParticipante ActualizarParticipante(int idParticipante, string idPais, int idUsuario, string fechaNacimiento, double altura, double peso, string genero)
        {
            responseParticipante result = new responseParticipante();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE Participante " +
                                    "SET idPais = @idPais, idUsuario = @idUsuario, fechaNacimiento = @fechaNacimiento, altura = @altura, peso = @peso, genero = @genero " +
                                    "WHERE idParticipante = @idParticipante;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPais", SqlDbType.Char, 3).Value = idPais;
                        cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                        cmd.Parameters.Add("@fechaNacimiento", SqlDbType.Date).Value = fechaNacimiento;
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@altura",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 5,
                            Scale = 2,
                            Value = altura
                        });
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@peso",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 5,
                            Scale = 2,
                            Value = peso
                        });
                        cmd.Parameters.Add("@genero", SqlDbType.Char, 5).Value = genero;

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

        public responseParticipante EliminarParticipante(int idParticipante)
        {
            responseParticipante result = new responseParticipante();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE Participante " +
                                    "WHERE idParticipante = @idParticipante;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
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

        public DataSet ListarParticipante()
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Participante";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Participante";
                            }
                        }
                    }
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }

        public DataSet ListarParticipantePorID(int idParticipante)
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Participante WHERE idParticipante = @idParticipante";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idParticipante", SqlDbType.Int).Value = idParticipante;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Participante";
                            }
                        }
                    }
                    return result;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}