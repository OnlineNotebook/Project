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
    }
}