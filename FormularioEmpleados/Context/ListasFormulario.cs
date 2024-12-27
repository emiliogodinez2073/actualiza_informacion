using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using FormularioEmpleados.Models;

namespace FormularioEmpleados.Context
{
    public class ListasFormulario :DBContext
    {
        public List<Bancos> Muestra_Bancos()
        {
            List<Bancos> list = new List<Bancos>();
            string connectionString = $"server ={GetRDSConections().Reader}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                // Comandos
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MUESTRA_BANCO_SP";
                conexion.Open();
                var leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    list.Add(new Bancos()//llena la lista de datos
                    {
                        BancoID = leer.GetInt32("ban_id"),
                        Descripcion = leer["ban_descripcion"].ToString(),
                    });
                }
                conexion.Close();//cierra conexion
                leer.Close();//cierra lista
                return list;//regresa la lista con datos
            }
        }

        public List<Area> Muestra_Areas()
        {
            List<Area> list = new List<Area>();
            string connectionString = $"server ={GetRDSConections().Reader}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                // Comandos
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MUESTRA_AREA_SP";
                conexion.Open();
                var leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    list.Add(new Area()//llena la lista de datos
                    {
                        AreaID = leer.GetInt32("are_id"),
                        Descripcion = leer["are_descripcion"].ToString(),
                    });
                }
                conexion.Close();//cierra conexion
                leer.Close();//cierra lista
                return list;//regresa la lista con datos
            }
        }

        public List<Puestos> Muestra_Puestos()
        {
            List<Puestos> list = new List<Puestos>();
            string connectionString = $"server ={GetRDSConections().Reader}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                // Comandos
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MUESTRA_PUESTO_SP";
                conexion.Open();
                var leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    list.Add(new Puestos()//llena la lista de datos
                    {
                        PuestoID = leer.GetInt32("pue_id"),
                        Descripcion = leer["pue_descripcion"].ToString(),
                    });
                }
                conexion.Close();//cierra conexion
                leer.Close();//cierra lista
                return list;//regresa la lista con datos
            }
        }

        public List<GradoEstudiosModel> Muestra_Grado_Estudios()
        {
            List<GradoEstudiosModel> list = new List<GradoEstudiosModel>();
            string connectionString = $"server ={GetRDSConections().Reader}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                // Comandos
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MUESTRA_GRADO_ESTUDIOS_SP";
                conexion.Open();
                var leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    list.Add(new GradoEstudiosModel()//llena la lista de datos
                    {
                        Id = leer.GetInt32("ges_id"),
                        Description = leer["ges_descripcion"].ToString(),
                    });
                }
                conexion.Close();//cierra conexion
                leer.Close();//cierra lista
                return list;//regresa la lista con datos
            }
        }


        public List<TipoCreditoModel> Muestra_TipoCredito()
        {
            List<TipoCreditoModel> list = new List<TipoCreditoModel>();
            string connectionString = $"server ={GetRDSConections().Reader}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                // Comandos
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MUESTRA_TIPO_CREDITO_SP";
                conexion.Open();
                var leer = cmd.ExecuteReader();
                while (leer.Read())
                {
                    list.Add(new TipoCreditoModel()//llena la lista de datos
                    {
                        Id = leer.GetInt32("tcr_id"),
                        Description = leer["tcr_descripcion"].ToString(),
                    });
                }
                conexion.Close();//cierra conexion
                leer.Close();//cierra lista
                return list;//regresa la lista con datos
            }
        }

    }
}