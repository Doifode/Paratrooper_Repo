using Docx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Docx.Controllers
{
    public class MarginController : Controller
    {
        List<Margin> margins = new List<Margin>() { 
        
            new Margin{Id =1, MarginTop =10, MarginRight=10, MarginBottom=10, MarginLeft=10,},
            new Margin{Id =2, MarginTop =11, MarginRight =12, MarginBottom=12, MarginLeft =10,},
            new Margin{Id =3, MarginTop =15, MarginLeft=15 , MarginRight=12, MarginBottom =12,},
        
        
        };

        // GET: Margin
        [HttpGet]
        public ActionResult Index()
        {
            return View(margins);
        }

        [HttpGet]
        public ActionResult Edit(int id) {

            var margin = margins.FirstOrDefault(x => x.Id == id);

            if(margin == null)
            {
                return HttpNotFound();
            }

            return View("AddEdit", margin);
        
        }

        [HttpPost]
        public ActionResult Edit(Margin editMargin)
        {
        
            var marginedit = margins.FirstOrDefault(x=> x.Id == editMargin.Id);

            if(marginedit == null)
            {
                return HttpNotFound();
            }

            marginedit.Id = editMargin.Id;
            marginedit.MarginTop = editMargin.MarginTop;
            marginedit.MarginRight = editMargin.MarginRight;
            marginedit.MarginBottom= editMargin.MarginBottom;
            marginedit.MarginLeft = editMargin.MarginLeft;

            margins.Add(marginedit);
            

            return RedirectToAction("Index");

        }


    }
}