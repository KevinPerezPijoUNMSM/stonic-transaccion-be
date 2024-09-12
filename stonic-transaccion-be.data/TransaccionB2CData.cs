using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using stonic_transaccion_be.model;

namespace stonic_transaccion_be.data
{
    public class TransaccionB2CData
    {
        public ReturnValue Registrar(TransaccionB2C item)
        {
            string jsonData = JsonConvert.SerializeObject(item);
            ReturnValue oReturn = new ReturnValue();

            try
            {
                using (var cnn = new NpgsqlConnection(HelpData.ConnectionString()))
                {
                    using (var cmd = new NpgsqlCommand("pos_man_transaccionb2c_ins", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_datos", NpgsqlTypes.NpgsqlDbType.Jsonb, jsonData);

                        var pMessage = new NpgsqlParameter("p_message", NpgsqlTypes.NpgsqlDbType.Varchar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(pMessage);

                        var pCode = new NpgsqlParameter("p_code", NpgsqlTypes.NpgsqlDbType.Integer)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(pCode);

                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        // Obtener los valores de los parámetros de salida
                        oReturn.Message = pMessage.Value.ToString();
                        oReturn.Success = Convert.ToInt32(pCode.Value) == 1;

                        cnn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturn.Success = false;
                oReturn.Message = $"Error: {ex.Message}";
            }

            return oReturn;
        }
    }
}
