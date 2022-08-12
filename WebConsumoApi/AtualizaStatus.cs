using System.Data;
using System.Data.SqlClient;
using WebConsumoApi.DBContext;
using WebConsumoApi.Models;
using WebConsumoApi.Models.ViewModels;

namespace WebConsumoApi
{
    public class AtualizaStatus
    {
        
        private readonly ApplicationConn1 _Conn1;
        public virtual void Atualiza_Status(ProdutoDB product)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection("Server=sql10.freemysqlhosting.net; AllowLoadLocalInfile=true; DataBase=sql10511870; Uid=sql10511870;Pwd=1udxXsDDv6"))
            {
                SqlCommand command = new SqlCommand("SP_AtualizaStatus", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Psku", product.Sku);
                command.Parameters.AddWithValue("Pstatus", product.Status);
                command.Parameters.AddWithValue("Pmotivo", product.Motivo);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
            }
            return;
        }
        
    }
}
