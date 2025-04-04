using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static api_OlimpiadasChapinas.Models.FormaPago.csEstructuraFormaPago;

namespace api_OlimpiadasChapinas.Models.FormaPago
{
    public class csFormaPago
    {
        public responseFormaPago InsertarFormaPago(string descripcion)
        {
            responseFormaPago result = new responseFormaPago();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO FormaPago(descripcion) " +
                                    "VALUES(@descripcion)";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
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

        public responseFormaPago ActualizarFormaPago(int idFormaPago, string descripcion)
        {
            responseFormaPago result = new responseFormaPago();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE FormaPago " +
                                    "SET descripcion = @descripcion " +
                                    "WHERE idFormaPago = @idFormaPago";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = descripcion;
                        cmd.Parameters.Add("@idFormaPago", SqlDbType.Int).Value = idFormaPago;

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

        public responseFormaPago EliminarFormaPago(int idFormaPago)
        {
            responseFormaPago result = new responseFormaPago();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE FormaPago " +
                                    "WHERE idFormaPago = @idFormaPago";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idFormaPago", SqlDbType.Int).Value = idFormaPago;

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
        
        public DataSet ListarFormaPago()
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM FormaPago";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista de Formas de Pago";
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

        public DataSet ListarFormaPagoPorID(int idFormaPago)
        {
            DataSet result = new DataSet();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM FormaPago WHERE idFormaPago = @idFormaPago";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idFormaPago", SqlDbType.Int).Value = idFormaPago;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista de Formas de Pago Por ID";
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