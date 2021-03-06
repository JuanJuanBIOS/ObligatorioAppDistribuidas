﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaTerminales : IPersistenciaTerminales
    {
        //Singleton
        private static PersistenciaTerminales _instancia = null;

        private PersistenciaTerminales() { }

        public static PersistenciaTerminales GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new PersistenciaTerminales();
            }

            return _instancia;
        }


        //Operaciones
        public Terminales Buscar_Terminal(string pCodTerminal)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Buscar_Terminal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pCodTerminal);

            Terminales unaTer = null;

            try
            {
                oConexion.Open();

                SqlDataReader _Reader = oComando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    _Reader.Read();

                    string _codigo = (string)_Reader["codigo"];
                    string _ciudad = (string)_Reader["ciudad"];
                    string _pais = (string)_Reader["pais"];
                    List<string> _facilidades = new List<string>();
                    _facilidades = PersistenciaFacilidades.CargoFacilidades(pCodTerminal);

                    unaTer = new Terminales(_codigo, _ciudad, _pais, _facilidades);

                    _Reader.Close();
                }
            }

            catch (SqlException)
            {
                throw new Exception("La base de datos no se encuentra disponible. Contacte al administrador.");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                oConexion.Close();
            }

            return unaTer;
        }

        internal Terminales BuscarTodos_Terminal(string pCodTerminal)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Buscar_Terminal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", pCodTerminal);

            Terminales unaTer = null;

            try
            {
                oConexion.Open();

                SqlDataReader _Reader = oComando.ExecuteReader();

                if (_Reader.HasRows)
                {
                    _Reader.Read();

                    string _codigo = (string)_Reader["codigo"];
                    string _ciudad = (string)_Reader["ciudad"];
                    string _pais = (string)_Reader["pais"];
                    List<string> _facilidades = new List<string>();
                    _facilidades = PersistenciaFacilidades.CargoFacilidades(pCodTerminal);

                    unaTer = new Terminales(_codigo, _ciudad, _pais, _facilidades);

                    _Reader.Close();
                }
            }

            catch (SqlException)
            {
                throw new Exception("La base de datos no se encuentra disponible. Contacte al administrador.");
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                oConexion.Close();
            }

            return unaTer;
        }


        public void Alta_Terminal(Terminales unaTer)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Alta_Terminal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", unaTer.Codigo);
            oComando.Parameters.AddWithValue("@ciudad", unaTer.Ciudad);
            oComando.Parameters.AddWithValue("@pais", unaTer.Pais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            SqlTransaction _transaccion = null;

            try
            {
                oConexion.Open();

                _transaccion = oConexion.BeginTransaction();

                oComando.Transaction = _transaccion;

                oComando.ExecuteNonQuery();

                if (Convert.ToInt32(oRetorno.Value) == -1)
                {
                    throw new Exception("La terminal ingresada ya existe en la base de datos");
                }
                if (Convert.ToInt32(oRetorno.Value) == -2)
                {
                    throw new Exception("Error al crear la terminal en la base de datos");
                }

                foreach (string unaFac in unaTer.ListaFacilidades)
                {
                    PersistenciaFacilidades.Alta_Facilidad(unaFac, unaTer, _transaccion);
                }

                _transaccion.Commit();
            }

            catch (SqlException)
            {
                throw new Exception("La base de datos no se encuentra disponible. Contacte al administrador.");
            }

            catch (Exception ex)
            {
                _transaccion.Rollback();
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }

            finally
            {
                oConexion.Close();
            }
        }

        public void Eliminar_Terminal(Terminales unaTer)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Eliminar_Terminal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", unaTer.Codigo);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            int oAfectados = -1;

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                oAfectados = (int)oComando.Parameters["@Retorno"].Value;

                if (oAfectados == -1)
                {
                    throw new Exception("La terminal ingresada no existe en la base de datos");
                }
                if (oAfectados == -2)
                {
                    throw new Exception("Error al eliminar la terminal en la base de datos");
                }
            }

            catch (SqlException)
            {
                throw new Exception("La base de datos no se encuentra disponible. Contacte al administrador.");
            }

            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }

            finally
            {
                oConexion.Close();
            }
        }

        public void Modificar_Terminal(Terminales unaTer)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Modificar_Terminal", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codigo", unaTer.Codigo);
            oComando.Parameters.AddWithValue("@ciudad", unaTer.Ciudad);
            oComando.Parameters.AddWithValue("@pais", unaTer.Pais);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);

            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            SqlTransaction _transaccion = null;

            try
            {
                oConexion.Open();

                _transaccion = oConexion.BeginTransaction();

                oComando.Transaction = _transaccion;

                oComando.ExecuteNonQuery();

                if (Convert.ToInt32(oRetorno.Value) == -1)
                {
                    throw new Exception("La terminal ingresada no existe en la base de datos");
                }
                if (Convert.ToInt32(oRetorno.Value) == -2)
                {
                    throw new Exception("Error al eliminar la terminal en la base de datos");
                }


                PersistenciaFacilidades.Eliminar_Facilidades(unaTer, _transaccion);

                foreach (string unaFac in unaTer.ListaFacilidades)
                {
                    PersistenciaFacilidades.Alta_Facilidad(unaFac, unaTer, _transaccion);
                }

                _transaccion.Commit();
            }


            catch (SqlException)
            {
                throw new Exception("La base de datos no se encuentra disponible. Contacte al administrador.");
            }

            catch (Exception ex)
            {
                _transaccion.Rollback();
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }

            finally
            {
                oConexion.Close();
            }
        }

        public List<Terminales> Listar_Terminales()
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("Listar_Terminales", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            List<Terminales> ListaTerminales = new List<Terminales>();

            try
            {
                oConexion.Open();
                SqlDataReader oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Terminales Ter = Buscar_Terminal(oReader["codigo"].ToString());
                        ListaTerminales.Add(Ter);
                    }
                }

                oReader.Close();
            }

            catch (SqlException)
            {
                throw new Exception("La base de datos no se encuentra disponible. Contacte al administrador.");
            }

            catch (Exception ex)
            {
                throw new Exception("Problemas con la base de datos: " + ex.Message);
            }

            finally
            {
                oConexion.Close();
            }

            return ListaTerminales;
        }
    }
}
