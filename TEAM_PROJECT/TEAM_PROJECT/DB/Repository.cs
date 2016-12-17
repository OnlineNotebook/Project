using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAM_PROJECT.DB
{
    public class Repository
    {
        const string login = "vygnich1";
        const string pass = "v8jz8qP76R";
        public RootObject _Dataset { get; set; }
        public IEnumerable<Cell> Get()
        {
            return _Dataset.cell.AsEnumerable();
        }
        public int GetRowsAmount()
        {

            int counter = 0;
            for (int i = 0; i < _Dataset.cell.Count; i++)
            {
                if (_Dataset.cell[i].id_row > counter)
                {
                    counter = _Dataset.cell[i].id_row;
                }
            }
            return counter + 1;
        }
        public void ChangeItemEnd(string value, int row, int column)
        {
            _Dataset.cell.Find(x => x.id_column == column && x.id_row == row).value = value;
            if (!_Dataset.cell.Exists(x => x.id_column == column + 1 && x.id_row == row))
            {
                var obj = new Cell(row, column + 1, "+");
                _Dataset.cell.Add(obj);
            }
            if (!_Dataset.cell.Exists(x => x.id_column == 0 && x.id_row == row + 1))
            {
                var obj = new Cell(row + 1, 0, "+");
                _Dataset.cell.Add(obj);
            }

            var json = JsonConvert.SerializeObject(_Dataset);

            UploadFile("ftp://vygnich.ru/public_html/teamproject/", json, login, pass, "");
        }
        public void DeleteItemEnd(int row, int column)
        {
            _Dataset.cell.Find(x => x.id_column == column && x.id_row == row).value = "+";
            var json = JsonConvert.SerializeObject(_Dataset);
            UploadFile("ftp://vygnich.ru/public_html/teamproject/", json, login, pass, "");
        }


        public void AddItem(PersonalTable pt) //
        {
            _Dataset.cell.Add(new Cell(pt.Id_Column, pt.Id_Row, pt.Value));
            var json = JsonConvert.SerializeObject(_Dataset);
            UploadFile("ftp://vygnich.ru/public_html/teamproject/", json, login, pass, "");
        }
        public static string UploadFile(string FtpUrl, string fileName, string userName, string password, string
            UploadDirectory = "")
        {
            String uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, "data.json");
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
            req.Proxy = null;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential(userName, password);
            req.UseBinary = true;
            req.UsePassive = true;
            byte[] data = Encoding.ASCII.GetBytes(fileName);
            req.ContentLength = data.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            FtpWebResponse res = (FtpWebResponse)req.GetResponse();
            return res.StatusDescription;
        }
        public void ClearData()
        {
            _Dataset.cell.Clear();
            _Dataset.cell.Add(new Cell(0, 0, "+"));
            var json = JsonConvert.SerializeObject(_Dataset);
            UploadFile("ftp://vygnich.ru/public_html/teamproject/", json, login, pass, "");
        }

        public Repository()
        {
            using (WebClient wc = new WebClient())
            {
                _Dataset = JsonConvert.DeserializeObject<RootObject>(wc.DownloadString("http://vygnich.ru/teamproject/data.json"));
            }
        }
    }
}