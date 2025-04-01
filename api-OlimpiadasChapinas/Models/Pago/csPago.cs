using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.Pago.csEstructuraPago;

namespace api_OlimpiadasChapinas.Models.Pago
{
    public class csPago
    {
        public responsePago InsertarPago(int idFormaPago, double montoPago, string observaciones)
        {
            responsePago result = new responsePago();
            TimeSpan horaActual = DateTime.Now.TimeOfDay;
            DateTime fechaActual = DateTime.Now.Date;
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO Pago(idFormaPago, montoPago, fecha, hora, observaciones) " +
                                    "VALUES(@idFormaPago, @montoPago, @fecha, @hora, @observaciones);";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idFormaPago", SqlDbType.Int).Value = idFormaPago;
                        cmd.Parameters.Add(new SqlParameter{
                            ParameterName = "@montoPago",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 6,
                            Scale = 2,
                            Value = Math.Round(montoPago, 2)
                        });
                        cmd.Parameters.Add(new SqlParameter{
                            ParameterName = "@fecha", 
                            SqlDbType = SqlDbType.Date,
                            Value = fechaActual
                        });
                        cmd.Parameters.Add(new SqlParameter {
                            ParameterName = "@hora", 
                            SqlDbType = SqlDbType.Time, 
                            Scale = 2,
                            Value = horaActual
                        });
                        cmd.Parameters.Add("@observaciones", SqlDbType.VarChar, 200).Value = observaciones;

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

        public responsePago ActualizarPago(int idPago, int idFormaPago, double montoPago, string observaciones)
        {
            responsePago result = new responsePago();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE Pago SET idFormaPago = @idFormaPago, montoPago = @montoPago, observaciones = @observaciones " +
                                    "WHERE idPago = @idPago;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idFormaPago", SqlDbType.Int).Value = idFormaPago;
                        cmd.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@montoPago",
                            SqlDbType = SqlDbType.Decimal,
                            Precision = 6,
                            Scale = 2,
                            Value = Math.Round(montoPago, 2)
                        });
                        cmd.Parameters.Add("@observaciones", SqlDbType.VarChar, 200).Value = observaciones;
                        cmd.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;

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

        public responsePago EliminarPago(int idPago)
        {
            responsePago result = new responsePago();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE Pago " +
                                    "WHERE idPago = @idPago;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idPago", SqlDbType.Int).Value = idPago;

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

        public DataSet ListarPago()
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Pago";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Pago";
                            }
                        }
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}