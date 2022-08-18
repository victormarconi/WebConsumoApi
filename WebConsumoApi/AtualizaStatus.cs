using System.Data;
using System.Data.SqlClient;
using WebConsumoApi.DBContext;
using WebConsumoApi.Models;
using WebConsumoApi.Models.ViewModels;

namespace WebConsumoApi
{
    public class AtualizaStatus
    {
        public virtual void Atualiza_Status(ProdutoDB product)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection("Server=sql10.freemysqlhosting.net; AllowLoadLocalInfile=true; DataBase=sql10513204; Uid=sql10513204;Pwd=alm9y89Tmw"))
            {
                SqlCommand command = new SqlCommand("SP_AtualizaStatus", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var psku = product.Sku;
                var pstatus = product.Status;
                var pmotivo = product.Motivo;
                command.Parameters.AddWithValue("Psku", psku);
                command.Parameters.AddWithValue("Pstatus", pstatus);
                command.Parameters.AddWithValue("Pmotivo", pmotivo);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
            }
            return;
        }
        
    }
}
