using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.Evento.csEstructuraEvento;
using static api_OlimpiadasChapinas.Models.Pais.csEstructuraPais;

namespace api_OlimpiadasChapinas.Models.Evento
{
    public class csEvento
    {
        public responseEvento InsertarEvento(int idDeporte, int idEventoPadre, string nombre, string fechaInicio, string fechaFin, int cantidadParticipantes, double montoInscripcion)
        {
            responseEvento result = new responseEvento();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            fecha Inicio = new fecha();
            Inicio = FormatearFecha(fechaInicio);

            fecha Fin = new fecha();
            Fin = FormatearFecha(fechaFin);

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO Evento(idDeporte, idEventoPadre, nombre, fechaInicio, fechaFin, cantidadParticipantes, montoInscripcion) " +
                                    "VALUES(@idDeporte, @idEventoPadre, @nombre, @fechaInicio, @fechaFin, @cantidadParticipantes, @montoInscripcion);";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idDeporte", SqlDbType.Int).Value = idDeporte;
                        cmd.Parameters.Add("@idEventoPadre", SqlDbType.Int).Value = idEventoPadre;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                        cmd.Parameters.Add(new SqlParameter{
                            ParameterName = "@fechaInicio",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Inicio.year, Inicio.month, Inicio.day)
                        });
                        cmd.Parameters.Add(new SqlParameter{
                            ParameterName = "@fechaFin",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Fin.year, Fin.month, Fin.day)
                        });
                        cmd.Parameters.Add("@cantidadParticipantes", SqlDbType.Int).Value = cantidadParticipantes;
                        cmd.Parameters.Add(new SqlParameter{
                            ParameterName = "@montoInscripcion",
                            SqlDbType = SqlDbType.Decimal, 
                            Precision = 6, 
                            Scale = 2,
                            Value = montoInscripcion
                         });

                        result.respuesta = cmd.ExecuteNonQuery();
                        result.descripcionRespuesta = "Operación realizada exitosamente";
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
        public responseEvento InsertarEvento(int idDeporte, string nombre, string fechaInicio, string fechaFin, int cantidadParticipantes, double montoInscripcion)
        {
            responseEvento result = new responseEvento();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            fecha Inicio = new fecha();
            Inicio = FormatearFecha(fechaInicio);

            fecha Fin = new fecha();
            Fin = FormatearFecha(fechaFin);

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO Evento(idDeporte, nombre, fechaInicio, fechaFin, cantidadParticipantes, montoInscripcion) " +
                                    "VALUES(@idDeporte, @nombre, @fechaInicio, @fechaFin, @cantidadParticipantes, @montoInscripcion);";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idDeporte", SqlDbType.Int).Value = idDeporte;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@fechaInicio",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Inicio.year, Inicio.month, Inicio.day)
                        });
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@fechaFin",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Fin.year, Fin.month, Fin.day)
                        });
                        cmd.Parameters.Add("@cantidadParticipantes", SqlDbType.Int).Value = cantidadParticipantes;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@montoInscripcion",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 6,
                            Scale = 2,
                            Value = montoInscripcion
                        });

                        result.respuesta = cmd.ExecuteNonQuery();
                        result.descripcionRespuesta = "Operación realizada exitosamente";
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
        public fecha FormatearFecha(string fechaIngresada)
        {
            fecha fechaFormateada = new fecha();

            if (fechaIngresada.Substring(1,1) == "/" || fechaIngresada.Substring(1, 1) == "-")
            {
                fechaIngresada = "0" + fechaIngresada;
            }

            if (fechaIngresada.Substring(2, 1) == "/" || fechaIngresada.Substring(2, 1) == "-")
            {
                fechaFormateada.day = int.Parse(fechaIngresada.Substring(0,2));
                fechaFormateada.month = int.Parse(fechaIngresada.Substring(3, 2));
                fechaFormateada.year = int.Parse(fechaIngresada.Substring(6, 4));
            } 
            else
            {
                fechaFormateada.day = int.Parse(fechaIngresada.Substring(8, 2));
                fechaFormateada.month = int.Parse(fechaIngresada.Substring(5, 2));
                fechaFormateada.year = int.Parse(fechaIngresada.Substring(0, 4));
            }       

            return fechaFormateada;
        }

        public responseEvento ActualizarEvento(int idEvento, int idDeporte, int idEventoPadre, string nombre, string fechaInicio, string fechaFin, int cantidadParticipantes, double montoInscripcion)
        {
            responseEvento result = new responseEvento();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            fecha Inicio = new fecha();
            Inicio = FormatearFecha(fechaInicio);

            fecha Fin = new fecha();
            Fin = FormatearFecha(fechaFin);

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE Evento " +
                                    "SET idDeporte = @idDeporte, idEventoPadre = @idEventoPadre, nombre = @nombre, fechaInicio = @fechaInicio, fechaFin = @fechaFin, cantidadParticipantes = @cantidadParticipantes, montoInscripcion = @montoInscripcion " +
                                    "WHERE idEvento = @idEvento;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idDeporte", SqlDbType.Int).Value = idDeporte;
                        cmd.Parameters.Add("@idEventoPadre", SqlDbType.Int).Value = idEventoPadre;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@fechaInicio",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Inicio.year, Inicio.month, Inicio.day)
                        });
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@fechaFin",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Fin.year, Fin.month, Fin.day)
                        });
                        cmd.Parameters.Add("@cantidadParticipantes", SqlDbType.Int).Value = cantidadParticipantes;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@montoInscripcion",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 6,
                            Scale = 2,
                            Value = montoInscripcion
                        });
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;

                        result.respuesta = cmd.ExecuteNonQuery();
                        result.descripcionRespuesta = "Operación realizada exitosamente";
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

        public responseEvento ActualizarEvento(int idEvento, int idDeporte, string nombre, string fechaInicio, string fechaFin, int cantidadParticipantes, double montoInscripcion)
        {
            responseEvento result = new responseEvento();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            fecha Inicio = new fecha();
            Inicio = FormatearFecha(fechaInicio);

            fecha Fin = new fecha();
            Fin = FormatearFecha(fechaFin);

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE Evento " +
                                    "SET idDeporte = @idDeporte, nombre = @nombre, fechaInicio = @fechaInicio, fechaFin = @fechaFin, cantidadParticipantes = @cantidadParticipantes, montoInscripcion = @montoInscripcion " +
                                    "WHERE idEvento = @idEvento;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        cmd.Parameters.Add("@idDeporte", SqlDbType.Int).Value = idDeporte;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@fechaInicio",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Inicio.year, Inicio.month, Inicio.day)
                        });
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@fechaFin",
                            SqlDbType = SqlDbType.Date,
                            Value = new DateTime(Fin.year, Fin.month, Fin.day)
                        });
                        cmd.Parameters.Add("@cantidadParticipantes", SqlDbType.Int).Value = cantidadParticipantes;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@montoInscripcion",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 6,
                            Scale = 2,
                            Value = Math.Round(montoInscripcion, 2)
                        });

                        result.respuesta = cmd.ExecuteNonQuery();
                        result.descripcionRespuesta = "Operación realizada exitosamente";
                    }
                }
                catch (Exception ex)
                {
                    result.respuesta = 0;
                    result.descripcionRespuesta = $"Ocurrió un error en la transacción: {ex.Message.ToString()}";
                    Debug.WriteLine(ex.ToString());
                }
            }

            return result;
        }

        public responsePais EliminarEvento(int idEvento)
        {
            responsePais result = new responsePais();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = $"DELETE Evento WHERE idEvento = @idEvento;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;

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

        public DataSet ListarEvento()
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Evento;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Evento";
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en ListarEvento: {ex.Message.ToString()}");
                    return null;
                }
            }
        }

        public DataSet ListarEventoPorID(int idEvento)
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Evento WHERE idEvento = @idEvento;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idEvento", SqlDbType.Int).Value = idEvento;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Evento Por ID";
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en ListarEvento: {ex.Message.ToString()}");
                    return null;
                }
            }
        }
    }
}