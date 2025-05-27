using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using static api_OlimpiadasChapinas.Models.Usuario.csEstructuraUsuario;

namespace api_OlimpiadasChapinas.Models.Usuario
{
    public class csUsuario
    {
        public responseUsuario InsertarUsuario(string nombre, string apellido, string email, string contraseña_hash, string telefono, string DNI)
        {
            responseUsuario result = new responseUsuario();
            string conexion = "";
            string contraseñaHasheada = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    contraseñaHasheada = BCrypt.Net.BCrypt.HashPassword(contraseña_hash);

                    con.Open();

                    string cadena = $"INSERT INTO Usuario(nombre, apellido, email, contraseña_hash, telefono, DNI)" +
                                    $"VALUES(@nombre, @apellido, @email, @contraseñaHasheada, @telefono, @DNI)";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombre;
                        cmd.Parameters.Add("@apellido", SqlDbType.NVarChar, 100).Value = apellido;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;
                        cmd.Parameters.Add("@contraseñaHasheada", SqlDbType.NVarChar, 300).Value = contraseñaHasheada;
                        cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 30).Value = telefono;
                        cmd.Parameters.Add("@DNI", SqlDbType.VarChar, 100).Value = DNI;

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

        public responseUsuario ActualizarUsuario(string nombre, string apellido, string email, string contraseñaAlmacenada, string contraseñaActualizada, string telefono)
        {
            responseUsuario result = new responseUsuario();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    contraseñaActualizada = BCrypt.Net.BCrypt.HashPassword(contraseñaActualizada);

                    con.Open();
                    string cadena = $"UPDATE Usuario SET nombre = @nombre, apellido = @apellido, contraseña_hash = @contraseñaActualizada, telefono = @telefono " +
                                    $"WHERE email = @email;";

                    AuthenticationPassword verificacionContraseña = new AuthenticationPassword();
                    bool contraseñaVerificada = verificacionContraseña.VerificarContraseña(email, contraseñaAlmacenada);

                    if (contraseñaVerificada)
                    {
                        using (SqlCommand cmd = new SqlCommand(cadena, con))
                        {
                            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 100).Value = nombre;
                            cmd.Parameters.Add("@apellido", SqlDbType.NVarChar, 100).Value = apellido;
                            cmd.Parameters.Add("@contraseñaActualizada", SqlDbType.NVarChar, 300).Value = contraseñaActualizada;
                            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 30).Value = telefono;
                            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;

                            result.respuesta = cmd.ExecuteNonQuery();
                            result.descripcionRespuesta = "Operación realizada exitosamente";
                        }
                    }
                    else
                    {
                        result.respuesta = 0;
                        result.descripcionRespuesta = $"Contraseña ingresada es incorrecta: " + contraseñaVerificada;
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

        public responseUsuario EliminarUsuario(string email)
        {
            responseUsuario result = new responseUsuario();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "DELETE Usuario WHERE email = @email";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;

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

        public DataSet ListarUsuario()
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Usuario;";

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
                    Console.WriteLine($"Error en listarUsuario: {ex.Message.ToString()}");
                    return null;
                }
            }
        }

        public DataSet ListarUsuarioPorID(int idUsuario)
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Usuario WHERE idUsuario = @idUsuario;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
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
                    Console.WriteLine($"Error en listarUsuario: {ex.Message.ToString()}");
                    return null;
                }
            }
        }

        public DataSet ListarUsuarioPorEmail(string email)
        {
            DataSet result = new DataSet();
            string conexion = "";

            conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    string cadena = "SELECT * FROM Usuario WHERE email = @email;";

                    using (SqlCommand cmd = new SqlCommand(cadena, con))
                    {
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;
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
                    Console.WriteLine($"Error en listarUsuario: {ex.Message.ToString()}");
                    return null;
                }
            }
        }

        public class AuthenticationPassword
        {
            private string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            public bool VerificarContraseña(string email, string contraseñaIngresada)
            {
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    try
                    {
                        con.Open();

                        string cadena = "SELECT contraseña_hash FROM Usuario WHERE email = @email";

                        using (SqlCommand cmd = new SqlCommand(cadena, con))
                        {
                            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100).Value = email;

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                string contraseña_hash = result.ToString();
                                return BCrypt.Net.BCrypt.Verify(contraseñaIngresada, contraseña_hash);
                            }
                        }
                    }
                    catch
                    {
                        return false; // Esto debe cambiar para mostrarse en pantalla
                    }
                }
                return false;
            }
        }

        public requestUsuario loginUsuario(string email, string password)
        {
            requestUsuario usuario = new requestUsuario();
            string conexion = ConfigurationManager.ConnectionStrings["cnConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();

                    AuthenticationPassword verificacionContraseña = new AuthenticationPassword();
                    bool contraseñaVerificada = verificacionContraseña.VerificarContraseña(email, password);

                    if (contraseñaVerificada)
                    {
                        usuario.email = email;
                        usuario.contraseña_hash = password;
                    }
                    else
                    {
                        usuario.email = "";
                        usuario.contraseña_hash = "";
                    }

                }
                catch 
                {
                    usuario.email = "";
                    usuario.contraseña_hash = "";
                }
            }

            return usuario;
        }
    }
}