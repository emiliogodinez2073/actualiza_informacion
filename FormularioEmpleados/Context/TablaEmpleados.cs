using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using FormularioEmpleados.Models;
using MySql.Data.MySqlClient;

namespace FormularioEmpleados.Context
{
    public class TablaEmpleados : DBContext
    {
        DateTime Fecha = DateTime.Now;
        public void Alta_Empleados(EmpleadoModel EmpleadosModelo)
        {
            try
            {
                string connectionString = $"server ={GetRDSConections().Writer}; {Data_base}";
                using (MySqlConnection conexion = new MySqlConnection(connectionString))
                {
                    // Comandos
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ALTA_EMPLEADO_SP";
                    cmd.Parameters.AddWithValue("empid", EmpleadosModelo.EmpleadoID);
                    cmd.Parameters.AddWithValue("empnombre", EmpleadosModelo.Nombre);
                    cmd.Parameters.AddWithValue("empapellidopaterno", EmpleadosModelo.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("empapellidomaterno", EmpleadosModelo.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("empemail", EmpleadosModelo.Email);
                    cmd.Parameters.AddWithValue("emptelefono", Convert.ToDouble(EmpleadosModelo.Telefono));
                    cmd.Parameters.AddWithValue("empcelular", Convert.ToDouble(EmpleadosModelo.Celular));
                    cmd.Parameters.AddWithValue("empcurp", EmpleadosModelo.Curp);
                    cmd.Parameters.AddWithValue("emprfc", EmpleadosModelo.RFC);
                    cmd.Parameters.AddWithValue("empnss", EmpleadosModelo.NSS);
                    cmd.Parameters.AddWithValue("empfechanacimiento", EmpleadosModelo.FechaDeNacimiento);
                    cmd.Parameters.AddWithValue("empcalle", EmpleadosModelo.Calle);
                    cmd.Parameters.AddWithValue("empnumeroexterior", EmpleadosModelo.NumeroExterior);
                    cmd.Parameters.AddWithValue("empnumerointerior", EmpleadosModelo.NumeroInterior);
                    cmd.Parameters.AddWithValue("empcodigopostal", EmpleadosModelo.CodigoPostal);
                    cmd.Parameters.AddWithValue("empcolonia", EmpleadosModelo.Colonia);
                    cmd.Parameters.AddWithValue("empnombrereferenciauno", EmpleadosModelo.NombreReferenciaUno);
                    cmd.Parameters.AddWithValue("empapellidopaternoreferenciauno", EmpleadosModelo.ApellidoPaternoReferenciaUno);
                    cmd.Parameters.AddWithValue("empapellidomaternoreferenciauno", EmpleadosModelo.ApellidoMaternoReferenciaUno);
                    cmd.Parameters.AddWithValue("emptelefonoreferenciauno", EmpleadosModelo.TelefonoReferenciaUno);
                    cmd.Parameters.AddWithValue("empparentescoreferenciauno", EmpleadosModelo.ParentescoReferenciaUno);
                    cmd.Parameters.AddWithValue("empnombrereferenciados", EmpleadosModelo.NombreReferenciaDos);
                    cmd.Parameters.AddWithValue("empapellidopaternoreferenciados", EmpleadosModelo.ApellidoPaternoReferenciaDos);
                    cmd.Parameters.AddWithValue("empapellidomaternoreferenciados", EmpleadosModelo.ApellidoMaternoReferenciaDos);
                    cmd.Parameters.AddWithValue("emptelefonoreferenciados", EmpleadosModelo.TelefonoReferenciaDos);
                    cmd.Parameters.AddWithValue("empparentescoreferenciados", EmpleadosModelo.ParentescoReferenciaDos);
                    if (EmpleadosModelo.BancoID == 0)
                    {
                        cmd.Parameters.AddWithValue("banid", null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("banid", EmpleadosModelo.BancoID);
                    }

                    cmd.Parameters.AddWithValue("empclabeinterbancaria", EmpleadosModelo.ClaveInterbancaria);
                    cmd.Parameters.AddWithValue("empnumerocuenta", EmpleadosModelo.NumeroDeCuenta);
                    cmd.Parameters.AddWithValue("empfechaalta", Fecha);
                    cmd.Parameters.AddWithValue("empexpediente", EmpleadosModelo.Expediente);
                    cmd.Parameters.AddWithValue("areid", EmpleadosModelo.AreaID);
                    cmd.Parameters.AddWithValue("pueid", EmpleadosModelo.PuestoID);

                    cmd.Parameters.AddWithValue("empineurl", EmpleadosModelo.URL_INE);
                    cmd.Parameters.AddWithValue("empactanacimiento_url", EmpleadosModelo.URL_ACTA_NACIMIENTO);
                    cmd.Parameters.AddWithValue("emphijos", EmpleadosModelo.Numero_Hijos);
                    cmd.Parameters.AddWithValue("emprfcurl", EmpleadosModelo.URL_RFC);
                    cmd.Parameters.AddWithValue("empultimogradoestudiosurl", EmpleadosModelo.URL_Grado_Estudios);
                    cmd.Parameters.AddWithValue("empfotocredencialurl", EmpleadosModelo.URL_INE);
                    cmd.Parameters.AddWithValue("empcomprobantedomicilio_url", EmpleadosModelo.URL_Comprobante_Domicilio);
                    cmd.Parameters.AddWithValue("empcomprobantebancariourl", EmpleadosModelo.URL_Comprobante_Bancario);
                    cmd.Parameters.AddWithValue("empcredito", EmpleadosModelo.Credito_Bancario);
                    cmd.Parameters.AddWithValue("tcrid", EmpleadosModelo.Tipo_De_Credito);
                    cmd.Parameters.AddWithValue("emphojaretencioncreditos", false);
                    cmd.Parameters.AddWithValue("gesid", false);
                    // Cierre General
                    conexion.Open();
                    int res = cmd.ExecuteNonQuery();
                    conexion.Close();
                    cmd = null;
                }
            }
            catch (Exception e)
            {
                var pru = "";

            }

        }
      

        public EmpleadoModel Valida_Existencia_Empleado(string EmpCelular, string EmpNSS, string EmpRFC)
        {

            List<EmpleadoModel> list = new List<EmpleadoModel>();
            string connectionString = $"server ={GetRDSConections().Reader}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                // Comandos
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "VALIDA_EXISTENCIA_EMPLEADO_SP";
                cmd.Parameters.AddWithValue("empcelular", String.IsNullOrEmpty(EmpCelular) ? "0" : EmpCelular);
                cmd.Parameters.AddWithValue("emprfc", String.IsNullOrEmpty(EmpRFC) ? "0" : EmpRFC);
                cmd.Parameters.AddWithValue("empnss", String.IsNullOrEmpty(EmpNSS) ? "0" : EmpNSS);
                conexion.Open();
                var leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    EmpleadoModel oModel = new EmpleadoModel
                    {
                        EmpleadoID = leer.GetInt32("emp_id"),
                        Nombre = leer["emp_nombre"].ToString(),
                        ApellidoPaterno = leer["emp_apellido_paterno"].ToString(),
                        ApellidoMaterno = leer["emp_apellido_materno"].ToString(),
                        Email = leer["emp_email"].ToString(),
                        Telefono = leer["emp_telefono"].ToString(),
                        Celular = leer["emp_celular"].ToString(),
                        Curp = leer["emp_curp"].ToString(),
                        RFC = leer["emp_rfc"].ToString(),
                        NSS = leer["emp_nss"].ToString(),
                        FechaDeNacimiento = Convert.ToDateTime(leer["emp_fecha_nacimiento"]),
                        Calle = leer["emp_calle"].ToString(),
                        NumeroExterior = leer["emp_numero_exterior"].ToString(),
                        NumeroInterior = leer["emp_numero_interior"].ToString(),
                        CodigoPostal = leer["emp_codigo_postal"].ToString(),
                        Colonia = leer["emp_colonia"].ToString(),
                        NombreReferenciaUno = leer["emp_nombre_referencia_uno"].ToString(),
                        ApellidoPaternoReferenciaUno = leer["emp_apellido_paterno_referencia_uno"].ToString(),
                        ApellidoMaternoReferenciaUno = leer["emp_apellido_materno_referencia_uno"].ToString(),
                        TelefonoReferenciaUno = leer["emp_telefono_referencia_uno"].ToString(),
                        ParentescoReferenciaUno = leer["emp_parentesco_referencia_uno"].ToString(),
                        NombreReferenciaDos = leer["emp_nombre_referencia_dos"].ToString(),
                        ApellidoPaternoReferenciaDos = leer["emp_apellido_paterno_referencia_dos"].ToString(),
                        ApellidoMaternoReferenciaDos = leer["emp_apellido_materno_referencia_dos"].ToString(),
                        TelefonoReferenciaDos = leer["emp_telefono_referencia_dos"].ToString(),
                        ParentescoReferenciaDos = leer["emp_parentesco_referencia_dos"].ToString(),
                        BancoID = String.IsNullOrEmpty(leer["ban_id"].ToString()) ? 0 : leer.GetInt32("ban_id"),
                        BancoDescripcion = leer["ban_descripcion"].ToString(),
                        ClaveInterbancaria = leer["emp_clabe_interbancaria"].ToString(),
                        NumeroDeCuenta = leer["emp_numero_cuenta"].ToString(),
                        //FechaAlta = Convert.ToDateTime(leer["emp_fecha_alta"]),
                        //  Expediente = leer["emp_expediente"].ToString(),
                        AreaID = String.IsNullOrEmpty(leer["are_id"].ToString()) ? 0 : leer.GetInt32("are_id"),
                        AreaDescripcion = leer["are_descripcion"].ToString(),
                        PuestoID = String.IsNullOrEmpty(leer["pue_id"].ToString()) ? 0 : leer.GetInt32("pue_id"),
                        PuestoDescripcion = leer["pue_descripcion"].ToString()
                    };
                    list.Add(oModel);
                }
                conexion.Close();//cierra conexion
                leer.Close();//cierra lista
                return list.FirstOrDefault();
            }
        }


    }
}