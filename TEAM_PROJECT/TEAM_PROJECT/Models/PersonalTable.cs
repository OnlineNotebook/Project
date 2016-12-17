using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEAM_PROJECT.DB;


namespace TEAM_PROJECT.Models
{
    public class PersonalTable
    {
        public int Id_Column { get; set; }
        public int Id_Row { get; set; }
        public string Value { get; set; }

        public PersonalTable(string value)
        {
            Repository repo = new Repository();

            Id_Column = 0;
            Id_Row = repo.GetRowsAmount() + 1;
            Value = value;
        }
        public PersonalTable()
        { }
    }
}