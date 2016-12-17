using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAM_PROJECT.DB
{
    public class Cell
    {
        public int id_column { get; set; }
        public int id_row { get; set; }
        public string value { get; set; }
        public Cell(int R, int C, string V)
        {
            id_row = R;
            id_column = C;
            value = V;
        }
    }
    public class RootObject
    {
        public List<Cell> cell { get; set; }
    }
}