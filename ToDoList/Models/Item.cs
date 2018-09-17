using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    private int
    private string _description;

    public Item(string Description, int Id = 0)
    {
      _id = Id;
      _description = Description;
    }

    //GETTERS AND SETTERS GO HERE

    public static List<Item> GetAll()
    {
      List<Item> allItems = new List<Item> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        string itemDescription = rdr.GetString(1);
        Item newItem = new Item(itemDescription, itemId);
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return allItems;
    }

    public void Save () {
      _instances.Add (this);
    }

    public static void ClearAll ()
    {
    _instances.Clear ();
    public int GetId()
    {
      return _id;
    }

    public static List<Item> GetAll()
    {
      return _instances;
    }

    public void Save()
    {
      _instances.Add(this);
    }

    public static Item Find (int searchId)
    {
      return _instances[searchId - 1];
    }

    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
