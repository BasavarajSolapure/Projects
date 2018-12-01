using Medicalstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medicalstore.Models;

namespace Medicalstore.Controllers
{
    public class MedicleController : Controller
    {
        MedicalstoreEntities ent = new MedicalstoreEntities();
        // *********** Login  ***********
        [HttpGet]
        public ActionResult Index( )
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            ViewBag.Username = model.UserName;
            var user = ent.GetLoginInfo(model.UserName, model.Password);
            var founduser = user.FirstOrDefault();
            if (founduser == "success")
            {
                return View("Home");
            }
            else if (founduser == "User Does not Exists")
            {
                ViewBag.NotValidUser = founduser;
                return View("Index");
            }
            else
            {
                ViewBag.Failedcount = founduser;
                return View("Index");
            }
        }
        [HttpGet]
        public ActionResult HomeAction()
        {
            return View("HomeAction");
        }
        //************  Drug Detail Grid  ***************
        public ActionResult DrugDetails()
        {
            var model = ent.tblDrugs.ToList();
            return View(model);
        }
        //*************** Create Drug Page  ********************
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblDrug details)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ent.tblDrugs.Add(details);
                    ent.SaveChanges();
                    return RedirectToAction("HomeAction");
                }
            }
            catch(Exception ex)
            {

            }
            return View();
        } 
        //************* Edit ***************
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var drug = ent.tblDrugs.Where(s => s.drug_id == id).FirstOrDefault();
            return View(drug);
        }
        [HttpPost]
        public ActionResult Edit(tblDrug drugdetails)
        {
            try
            {
                if (drugdetails != null)
                {
                    ent.tblDrugs.Add(drugdetails);
                    ent.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Edit =>" + ex.Message);
            }

            return View("DrugDetails", "Medicle");
        }
        //************* Delete Drugs ******************
        public ActionResult Delete(int id)
        {
            var drug = ent.tblDrugs.Where(s => s.drug_id == id).FirstOrDefault();
            if (drug != null)
            {
                ent.tblDrugs.Remove(drug);
                ent.SaveChanges();
            }
            return View("DrugDetails","Medicle");
        }
        //************** Details*****************
        public ActionResult Details(int id)
        {
            var drug = ent.tblDrugs.Where(s => s.drug_id == id).FirstOrDefault();
            return View(drug);
        }
        //************* Sell Drugs Page  ******************
        public ActionResult Sell()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Sell(FormCollection formdata)
        {
            string name= Request.Form["txtCustomerName"];
            //tblDrugs
            //ent.tblCustomers
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Search(string prefix)
        {
            List<City> ObjList = new List<City>()
            {
                new City {Id=1,Cityname="Latur" },
                new City {Id=2,Cityname="Mumbai" },
                new City {Id=3,Cityname="Pune" },
                new City {Id=4,Cityname="Delhi" },
                new City {Id=5,Cityname="Dehradun" },
                new City {Id=6,Cityname="Noida" },
                new City {Id=7,Cityname="New Delhi" }
            };
            var citylst = (from N in ObjList where N.Cityname.StartsWith(prefix.ToUpper()) select new { N.Cityname });
            return Json(citylst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult GoogleMap()
        {
            return View();
        }
    }
}