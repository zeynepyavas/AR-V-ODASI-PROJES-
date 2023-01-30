using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ARŞİV_ODASI_PROJESİ
{
    internal class sql_baglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=305-01; Initial Catalog = Arşiv Odası; User ID = WebMobile_302; Password=zeynep.123");
            baglan.Open();  
            return baglan;
        }

    }
}
