using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class AdminController : Controller
    {
        InstanceClassDataContext d1 = new InstanceClassDataContext();
        MedicineInstanceDataContext med = new MedicineInstanceDataContext();
        CompanyInstanceDataContext cmp = new CompanyInstanceDataContext();

        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AddPharmacist()
        {
            return View(d1.Details.ToList());

        }

        public ActionResult AddPharm()
        {
            string name = Request["name"];
            string gender = Request["gender"];
            var phone = Request["phone"];
            var cnic = Request["cnic"];

            var p1 = phone.AsInt();
            var p2 = cnic.AsFloat();
            Detail d = new Detail();
            d.U_Name = name;
            d.Gender = gender;
            d.Phone_No = p1;
            d.CNIC = p2;

            d1.Details.InsertOnSubmit(d);
            d1.SubmitChanges();

            return RedirectToAction("AddPharmacist");
        }
        public ActionResult EditPharm(int id)
        {
            var e1 = d1.Details.First(e => e.Registration_No == id);
            e1.U_Name = Request["name"];
            e1.Gender = Request["gender"];
            e1.Phone_No = Request["phone"].AsInt();
            e1.CNIC = Request["cnic"].AsFloat();
            d1.SubmitChanges();
            return RedirectToAction("AddPharmacist");

        }
        public ActionResult EditPharmacist(int id)
        {
            return View(d1.Details.First(e => e.Registration_No == id));
        }
        public ActionResult DeletePharm(int id)
        {
            var d2 = d1.Details.First(d => d.Registration_No == id);
            d1.Details.DeleteOnSubmit(d2);
            d1.SubmitChanges();
            return RedirectToAction("AddPharmacist");
        }
        public ActionResult AddMedicine()
        {

            return View(med.Medicines.ToList());
        }

        public ActionResult AddMed()
        {
            string Mname = Request["Mname"];
            var Mprice = Request["Mprice"];
            var Mqty = Request["Mqty"];
            string Mtype = Request["Mtype"];
            string cmp = Request["cmp"];
            Medicine m = new Medicine();

            m.M_Name = Mname;
            m.M_Price = Mprice;
            m.M_Qty = Mqty;
            m.Medicine_Type = Mtype;
            m.Company = cmp;

            med.Medicines.InsertOnSubmit(m);
            med.SubmitChanges();
            return RedirectToAction("AddMedicine");

        }
        public ActionResult EditMedicine(int id)
        {
            return View(med.Medicines.First(x => x.Id == id));
        }
        public ActionResult EditMed(int id)
        {
            var med1 = med.Medicines.First(e => e.Id == id);
            med1.M_Name = Request["Mname"];
            med1.M_Price = Request["Mprice"];
            med1.M_Qty = Request["Mqty"];
            med1.Medicine_Type = Request["Mtype"];
            med1.Company = Request["cmp"];
            med.SubmitChanges();
            return RedirectToAction("AddMedicine");

        }
        public ActionResult DeleteMed(int id)
        {
            var dM = med.Medicines.First(d => d.Id == id);
            med.Medicines.DeleteOnSubmit(dM);
            med.SubmitChanges();
            return RedirectToAction("AddMedicine");
        }
        public ActionResult AddCmp()
        {
            string Cname = Request["Cname"];
            string CAddress = Request["CAddress "];
            var phn = Request["phn"];

            var Phone = phn.AsFloat();
            Company c = new Company();

            c.Company_Name = Cname;
            c.Company_Address = CAddress;
            c.Phone_No = Phone;

            cmp.Companies.InsertOnSubmit(c);
            cmp.SubmitChanges();
            return RedirectToAction("AddCompany");
        }
        public ActionResult AddCompany()
        {

            return View(cmp.Companies.ToList());
        }
        
         public ActionResult EditCompany(int id)
        {
            return View(cmp.Companies.First(x => x.Company_Id == id));
        }
        public ActionResult EditCmp(int id)
        {
            var cm1 = cmp.Companies.First(e => e.Company_Id == id);
            cm1.Company_Name = Request["Cname"];
            cm1.Company_Address = Request["CAddress"];
            cm1.Phone_No = Request["phn"].AsFloat();
               cmp.SubmitChanges();
            return RedirectToAction("AddCompany");

        }
        public ActionResult DeleteCmp(int id)
        {
            var DC = cmp.Companies.First(d => d.Company_Id == id);
          cmp.Companies.DeleteOnSubmit(DC);
            cmp.SubmitChanges();
            return RedirectToAction("AddCompany");
        }
    }
}