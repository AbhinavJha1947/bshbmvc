using Microsoft.Data.SqlClient;
using System.Data;
//using System.Data.SqlClient;

namespace BiharStateHousingBoard.Models
{

    public class AlbumModelService
    {
        SqlConnection scon = new SqlConnection("Server=VINIT\\SQLEXPRESS;Database=BSHB_DBFinal;Trusted_Connection=True;User Id=sa;Password=abc1234;");

        public int UploadAlbums(AlbumMaster objAlbumMaster)
        {
            using (SqlCommand scmd = new SqlCommand())
            {
                scmd.Connection = scon;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = "INSERT INTO tblGallery(ImagePath) VALUES(@ImagePath)";
                scmd.Parameters.AddWithValue("@ImagePath", objAlbumMaster.ImagePath);
                //scmd.Parameters.AddWithValue("@Photo", objAlbumMaster.Image);
                scon.Open();
                int status = scmd.ExecuteNonQuery();
                scon.Close();
                return status;
            }
        }
        public IList<AlbumMaster> GetAlbums()
        {
            List<AlbumMaster> objAlbumList = new List<AlbumMaster>();
            using (SqlCommand scmd = new SqlCommand())
            {
                scmd.Connection = scon;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = "SELECT * FROM PhotoAlbumMaster";
                scon.Open();
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    AlbumMaster objAlbumMaster = new AlbumMaster();
                    objAlbumMaster.ImageId = Convert.ToInt32(sdr["ImageId"]);
                    objAlbumMaster.ImagePath = sdr["ImagePath"].ToString();
                    //objAlbumMaster.Image = (byte[])sdr["Photo"];
                    objAlbumList.Add(objAlbumMaster);
                }

                if (sdr != null)
                {
                    sdr.Dispose();
                    sdr.Close();
                }
                scon.Close();
                return objAlbumList.ToList(); ;
            }
        }
    }
}
