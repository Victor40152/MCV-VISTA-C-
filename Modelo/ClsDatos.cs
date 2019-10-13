using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
   public class ClsDatos
    {
        #region Declaracion de variables 


        SqlConnection cnnConexion = null;
        SqlCommand cmdComando = null;
        SqlDataAdapter dataAdaptador = null;
        DataTable Dtt = null;
        string strCadenaConexion = string.Empty;
        #endregion

        #region conatructor
        public ClsDatos()
        {
            strCadenaConexion =  @"Data Source=SALA403-5\SQLEXPRESS;Initial Catalog=Contacto;Integrated Security=True";


        }

        #endregion

        #region Metodos a ejecutar

        public void EjecutarSP(SqlParameter[] parParametros, string pasSPName)   
  
        {
            try
            {
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cnnConexion.Open();
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = pasSPName;
                cmdComando.Parameters.AddRange(parParametros);
                cmdComando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
            }
        }

        public DataTable RetornaTabla(SqlParameter[] parParametros, string parTSQL)
        {
            Dtt = null;
            try
            {
                Dtt = new DataTable();
                cnnConexion = new SqlConnection(strCadenaConexion);
                cmdComando = new SqlCommand();
                cmdComando.Connection = cnnConexion;
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.CommandText = parTSQL;
                cmdComando.Parameters.AddRange(parParametros);

                dataAdaptador = new SqlDataAdapter(cmdComando);
                dataAdaptador.Fill(Dtt);

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cnnConexion.Dispose();
                cmdComando.Dispose();
                dataAdaptador.Dispose();
            }
            return Dtt;
        }

        #endregion
    }
}
