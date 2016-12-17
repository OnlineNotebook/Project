using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM_PROJECT.DB;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using Newtonsoft.Json;
using TEAM_PROJECT.Models;
namespace TEAM_PROJECT.Controllers
{
    public class PersonalTableController : Controller
    {
        public static int Row;
        public static int Column;
        public ActionResult Index()
        {
            Repository repo = new Repository();
            ViewBag.CellList = repo.Get();
            ViewBag.RowsCount = repo.GetRowsAmount();

            return View("~/Views/PersonalTable/Index.cshtml");
        }
        public ActionResult Method(string value)
        {
            PersonalTable pt = new PersonalTable(value);
            Repository repo = new Repository();
            repo.AddItem(pt);

            ViewBag.CellList = repo.Get();
            ViewBag.RowsCount = repo.GetRowsAmount();
            return View("~/Views/PersonalTable/Index.cshtml");
        }
        public ActionResult ViewPage(int row, int column)
        {
            Repository repo = new Repository();
            Row = row;
            Column = column;
            return View("~/Views/PersonalTable/View.cshtml");
        }
        public ActionResult Upgrade(string value)
        {
            Repository repo = new Repository();
            repo.ChangeItemEnd(value, Row, Column);
            ViewBag.CellList = repo.Get();
            ViewBag.RowsCount = repo.GetRowsAmount();
            return View("~/Views/PersonalTable/Index.cshtml");

        }
        public ActionResult Delete()
        {
            Repository repo = new Repository();
            repo.DeleteItemEnd(Row, Column);
            ViewBag.CellList = repo.Get();
            ViewBag.RowsCount = repo.GetRowsAmount();
            return View("~/Views/PersonalTable/Index.cshtml");
        }
        public ActionResult ClearTable()
        {
            Repository repo = new Repository();
            repo.ClearData();
            ViewBag.CellList = repo.Get();
            ViewBag.RowsCount = repo.GetRowsAmount();
            return View("~/Views/PersonalTable/Index.cshtml");

        }
    }
}