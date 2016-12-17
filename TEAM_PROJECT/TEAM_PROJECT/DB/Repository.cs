using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAM_PROJECT.DB
{
    public class Repository
    {
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
    }
}