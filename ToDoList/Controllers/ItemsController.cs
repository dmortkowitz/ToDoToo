using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }


    [HttpGet("/categories/{categoryid}/items/new")]
    public ActionResult CreateForm(int categoryId)
    {
      Dictionary <string,object> model = new Dictionary<string, object>{};
      Category category = Category.Find(categoryId);
      return View(category);
    }

      
    [HttpPost ("/items")]
    public ActionResult CreateItem (int categoryId, string itemDescription) 
    {
      Dictionary<string, object> model = new Dictionary<string, object> ();
      Category foundCategory = Category.Find(categoryId);
      Item newItem = new Item (itemDescription);
      newItem.Save();
      newItem.AddCategory(foundCategory);
      List<Item> categoryItems = foundCategory.GetItems();
      model.Add ("items", categoryItems);
      model.Add ("category", foundCategory);
      return View ("Details", model);
    }

    [HttpGet("/categories/{categoryId}/items/{Id}")]
    public ActionResult Details(int categoryId, int Id)
    {
      Item item = Item.Find(Id);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      model.Add("item", item);
      model.Add("category", category);
      return View("Details", model);
    }

    

    [HttpGet("/items/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Item thisItem = Item.Find(id);
      return View(thisItem);
    }

    [HttpPost("/items/{id}/update")]
    public ActionResult Update(int id, string newDescription)
    {
      Item thisItem = Item.Find(id);
      thisItem.UpdateDescription(newDescription);
      return RedirectToAction("Index");
    }

    [HttpGet("/items/{id}/delete")]

    public ActionResult DeleteItem(int id)
    {
      Item newItem = Item.Find(id);
      newItem.Delete();
      return RedirectToAction("index");
    }
  }
}
