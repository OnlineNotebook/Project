using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEAM_PROJECT.DB
{
    public class Repository
    {
        public RootObject _Dataset { get; set; }
        public IEnumerable<Cell> Get() // Check
        {
            return _Dataset.cell.AsEnumerable();
        }
    }
}