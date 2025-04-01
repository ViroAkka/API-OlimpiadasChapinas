using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Newtonsoft.Json;
using static api_OlimpiadasChapinas.Models.Deporte.csDeporteEstructura;

namespace api_OlimpiadasChapinas.Models.Deporte
{
    public class csDeporte
    {
        public responseDeporte InsertarDeporte(string nombre, string categoria, string descripcion, int cantidadJugadores)
        {
            responseDeporte result = new responseDeporte();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "INSERT INTO Deporte(nombre, categoria, descripcion, cantidadJugadores) " +
                                    "VALUES (@nombre, @categoria, @descripcion, @cantidadJugadores)";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                        cmd.Parameters.Add("@categoria", SqlDbType.VarChar, 50).Value = categoria;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = descripcion;
                        cmd.Parameters.Add("@cantidadJugadores", SqlDbType.Int).Value = cantidadJugadores;

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

        public responseDeporte ActualizarDeporte(int idDeporte, string nombre, string categoria, string descripcion, int cantidadJugadores)
        {
            responseDeporte result = new responseDeporte();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "UPDATE Deporte SET nombre = @nombre, categoria = @categoria, descripcion = @descripcion, cantidadJugadores = @cantidadJugadores " +
                                    "WHERE idDeporte = @idDeporte";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idDeporte", SqlDbType.Int).Value = idDeporte;
                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                        cmd.Parameters.Add("@categoria", SqlDbType.VarChar, 50).Value = categoria;
                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = descripcion;
                        cmd.Parameters.Add("@cantidadJugadores", SqlDbType.Int).Value = cantidadJugadores;

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

        public responseDeporte EliminarDeporte(int idDeporte)
        {
            responseDeporte result = new responseDeporte();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE Deporte WHERE idDeporte = @idDeporte";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idDeporte", SqlDbType.Int).Value = idDeporte;

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

        public List<requestDeporte> ListarDeporte()
        {
            List<requestDeporte> deportes = new List<requestDeporte>();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Deporte;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                deportes.Add(new requestDeporte
                                {
                                    idDeporte = Convert.ToInt32(reader["idDeporte"]),
                                    nombre = reader["nombre"].ToString(),
                                    categoria = reader["categoria"].ToString(),
                                    descripcion = reader["descripcion"].ToString(),
                                    cantidadJugadores = Convert.ToInt32(reader["cantidadJugadores"])
                                });

                            }
                        }
                    }
                    return deportes;
                }
                catch 
                {
                    return deportes;
                }
            }
        }

        //public DataSet ListarDeporte()
        //{
        //    DataSet result = new DataSet();
        //    string conexion = "";

        //    conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

        //    using (SqlConnection con = new SqlConnection(conexion))
        //    {
        //        try
        //        {
        //            con.Open();

        //            string cadena = "SELECT * FROM Deporte;";

        //            using (SqlCommand cmd = new SqlCommand(cadena, con))
        //            {
        //                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //                {
        //                    adapter.Fill(result);

        //                    if (result.Tables.Count > 0)
        //                    {
        //                        result.Tables[0].TableName = "Lista Deporte por ID";
        //                    }
        //                }
        //            }
        //            return result;
        //        }
        //        catch (Exception ex)
        //        {
        //            return null;
        //        }
        //    }
        //}

        public DataSet ListarDeportePorID(string idDeporte)
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Deporte WHERE idDeporte = @idDeporte;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idDeporte", SqlDbType.Int).Value = idDeporte;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(result);

                            if (result.Tables.Count > 0)
                            {
                                result.Tables[0].TableName = "Lista Deporte por ID";
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