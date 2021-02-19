using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N01426963_passionproject.Models;
using System.Diagnostics;

namespace N01426963_passionproject.Controllers
{
    //this controller's purpose is to link our data to a dynamically rendered web page
    public class CompController : Controller
    {
        //representing the compcontroller outside of each method
        private CompDataController compdatacontroller = new CompDataController();

        //GET : Comp
        public ActionResult Index()
        {
            return View();
        }


        //Get: /Comp/List
        public ActionResult List()
        {
            try
            {
                //Attempting to get list of authors
                IEnumerable<Comp> Comps = compdatacontroller.ListComps();
                return View(Comps);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                //Debug.WriteLine(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        //GET: /Comp/Show/{id}
        public ActionResult Show(int id)
        {
            CompDataController controller = new CompDataController();
            Comp NewComp = controller.FindComp(id);
            


            return View(NewComp);
        }

        //GET: /Comp/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            CompDataController controller = new CompDataController();
            Comp NewComp = controller.FindComp(id);
            return View(NewComp);
        }

        //POST: /Comp/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            CompDataController controller = new CompDataController();
            controller.DeleteComp(id);
            return RedirectToAction("List");
        }

        //GET: /Comp/New
        public ActionResult New()
        {
            return View();
        }

        //POST: /Comp/Create
        [HttpPost]
        public ActionResult Create(string CompName, string CompClass1, string CompClass2, string CompClass3)
        {

           
            Comp NewComp = new Comp();
            NewComp.CompName = CompName;
            NewComp.CompClass1 = CompClass1;
            NewComp.CompClass2 = CompClass2;
            NewComp.CompClass3 = CompClass3;

            compdatacontroller.AddComp(NewComp);
            
            
            
            return RedirectToAction("List");
        }
    }

}