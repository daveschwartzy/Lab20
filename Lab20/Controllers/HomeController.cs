using Lab20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            List<Item> ItemList = ORM.Items.ToList();

            ViewBag.ItemList = ItemList;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult ProcessSignup(User NewUserRecord)
        {
            if (ModelState.IsValid)
            {

                //2. Initalize DB
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

                //3. Add the new record to the ORM
                ORM.Users.Add(NewUserRecord);
                ORM.SaveChanges();

                //4. Show the list of all customers
                return View();

            }
            else
            {
                //if validation fails
                //go back to the form and show the list of errors

                return View("Signup");
            }
        }
        public ActionResult ListUsers()
        {

            //Make Link in Layout First!

            //1. Creating an object for the ORM

            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            //2. Load the data from the DbSet into a data structure (list, array, etc.)

            List<User> UserList = ORM.Users.ToList();

            //3. Filter the data (optional)

            ViewBag.UserList = UserList;

            //ViewBag.CountryList = ORM.Users.Select(x => x.First_Name).Distinct().ToList();

            return View("ProcessSignup");

            //Go to view and write Foreach loop!
        }
        public ActionResult ItemAdmin()
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            List<Item> ItemList = ORM.Items.ToList();

            ViewBag.ItemList = ItemList;

            return View("ItemAdmin");

        }

        public ActionResult NewItemForm()
        {
            return View();   
        }

        public ActionResult SaveItem(Item NewItemRecord)
        {
            //1. Validation (if model state is valid or not)

            if (ModelState.IsValid)
            {

                //2. Initalize DB
                CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

                //3. Add the new record to the ORM
                ORM.Items.Add(NewItemRecord);
                ORM.SaveChanges();

                //4. Show the list of all customers
                return RedirectToAction("ItemAdmin");

            }
            else
            {
                //if validation fails
                //go back to the form and show the list of errors

                return View("NewCustomerForm");

            }
        }

        public ActionResult DeleteItem(string Item_Name)
        {   //ToDo: Add exception handling for db exceptions
            //1. Initalize the database
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            //2.Find the record - Use find (which looks for a record based on the primary key)
            Item RecordToBeDeleted = ORM.Items.Find(Item_Name);

            //3. Delete the record using the ORM
            if (RecordToBeDeleted != null)
            {
                ORM.Items.Remove(RecordToBeDeleted);
                ORM.SaveChanges();
            }

            //4. Reload the list
            //this will actually reload the list
            return RedirectToAction("ItemAdmin");

        }
        
        public ActionResult UpdateItem(string Item_Name)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();

            Item RecordToBeUpdated = ORM.Items.Find(Item_Name);

            if (RecordToBeUpdated != null)
            {
                ViewBag.RecordToBeUpdated = RecordToBeUpdated;
                //3. Go to the view that has the update form
                return View("UpdateItemForm");

            }
            else
            {//ToDo: Create an error message
                return RedirectToAction("ItemAdmin");

            }

        }

        public ActionResult SaveUpdatedItem(Item RecordToBeUpdated)
        {
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            Item temp = ORM.Items.Find(RecordToBeUpdated.Item_Name);

            temp.Item_Description = RecordToBeUpdated.Item_Description;
            temp.Item_Price = RecordToBeUpdated.Item_Price;
            temp.Item_Quantity = RecordToBeUpdated.Item_Quantity;


            ORM.Entry(temp).State = System.Data.Entity.EntityState.Modified;

            ORM.SaveChanges();

            return RedirectToAction("ItemAdmin");

        }
    }
}
