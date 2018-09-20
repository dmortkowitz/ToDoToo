using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {

        // [HttpGet("/items")]
        // public ActionResult Index()
        // {
        //     List<Item> allItems = Item.GetAll();
        //     return View(allItems);
        // }

          [HttpGet("/categories/{categoryId}/items")]
          public ActionResult Index(int categoryId)
          {
              Category category = Category.Find(categoryId);
              List<Item> categoryItems = category.GetItems();
              return View(categoryItems);
          }

          [HttpGet("/categories/{categoryid}/items/new")]
          public ActionResult CreateForm(int categoryId)
          {
              Category category = Category.Find(categoryId);
              return View(category);
          }

          [HttpGet("/categories/{categoryId}/items/{itemId}")]
          public ActionResult Details(int categoryId, int Id)
          {
              Dictionary<string, object> model = new Dictionary<string, object>();
              Category category = Category.Find(categoryId);
              Item item = Item.Find(Id);
              model.Add("item", item);
              model.Add("category", category);
              return View(model);
          }

          // [HttpPost("/items")]
          // public ActionResult Create(string description int id = 0)
          // {
          //     Dictionary<string, object> model = new Dictionary<string,object>();
          //     Category foundCategory = category.Find(categoryId);
          //     Item newItem = new Item(description, id);
          //     newItem.Save();
          //     //List<Item> allItems = Item.GetAll();
          //     return RedirectToAction("Index", new {categoryId = categoryId});
          // }

          [HttpPost ("/items")]
          public ActionResult CreateItem (int categoryId, string itemDescription)
          {
            Dictionary<string, object> model = new Dictionary<string, object> ();
            Category foundCategory = Category.Find(categoryId);
            Item newItem = new Item(itemDescription);
            foundCategory.AddItem(newItem);
            List<Item> categoryItems = foundCategory.GetItems ();
            // model.Add ("items", categoryItems);
            // model.Add ("category", foundCategory);
            return View ("Index", new {categoryId = categoryId});
          }

          [HttpGet("/items/{id}")]
          public ActionResult Details(int id)
          {
              Item item = Item.Find(id);
              return View(item);
          }

          [HttpGet("/items/{id}/update")]
          public ActionResult UpdateForm(int id)
          {
              Item thisItem = Item.Find(id);
              return View(thisItem);
          }

          // [HttpPost("/items/{id}/update")]
          // public ActionResult Update(int id, string newDescription)
          // {
          //     Item thisItem = Item.Find(id);
          //     thisItem.Edit(newDescription);
          //     return RedirectToAction("Index", new {categoryId = thisitem.GetCategoryId()});
          // }

          // [HttpPost("/items/{id}/delete")]
          // public ActionResult DeleteAll()
          // {
          //     Item.DeleteAll();
          //     return View("index", new {categoryId = thisitem.GetCategoryId()});
          // }
        // [HttpGet("/categories/{categoryId}/items/new")]
        // public ActionResult CreateForm(int categoryId)
        // {
        //   Dictionary<string, object> model = new Dictionary<string, object>();
        //   Category category = Category.Find(categoryId);
        //   return View(category);
        // }
        //
        // [HttpGet("/categories/{categoryId}/items/{itemId}")]
        // public ActionResult Details(int categoryId, int itemId)
        // {
        //   Item item = Item.Find(itemId);
        //   Dictionary<string, object> model = new Dictionary<string, object>();
        //   Category category = Category.Find(categoryId);
        //   model.Add("item", item);
        //   model.Add("category", category);
        //   return View(item);
        // }
    }
}
