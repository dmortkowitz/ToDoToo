using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;

namespace ToDoList.Models 
{
  public class Item
  {
    private int _id;
    private string _description;
    public string GetDescription() 
    {
      return _description;
    }
    public int GetId()
    {
      return _id;
    }
    public Item (string Description, int Id = 0) 
    {
      _id = Id;
      _description = Description;
    }
    public override bool Equals(System.Object otherItem)
    {
      if (!(otherItem is Item))
      {
        return false;
      }
      else
      {
        Item newItem = (Item) otherItem;
        bool idEquality = (this.GetId() == newItem.GetId());
        bool descriptionEquality = (this.GetDescription() == newItem.GetDescription());
        return (idEquality && descriptionEquality);
      }
    }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO items (description) VALUES (@ItemDescription);";

      MySqlParameter description = new MySqlParameter();
      description.ParameterName = "@ItemDescription";
      description.Value = _description;
      cmd.Parameters.Add(description);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;  // Notice the slight update to this line of code!

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }   
    public static List<Item> GetAll() 
    {
      List<Item> allItems = new List<Item> { };
      MySqlConnection conn = DB.Connection ();
      conn.Open ();
      MySqlCommand cmd = conn.CreateCommand () as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader () as MySqlDataReader;
      
      while (rdr.Read ()) 
      {
        int itemId = rdr.GetInt32 (0);
        string itemDescription = rdr.GetString (1);
        Item newItem = new Item (itemDescription, itemId);
        allItems.Add (newItem);
      }
      conn.Close ();
      if (conn != null) 
      {
        conn.Dispose ();
      }
      return allItems;
    }
    public static void DeleteAll () 
    {
      MySqlConnection conn = DB.Connection ();
      conn.Open ();

      var cmd = conn.CreateCommand () as MySqlCommand;
      cmd.CommandText = @"DELETE FROM items;";

      cmd.ExecuteNonQuery ();

      conn.Close ();
      if (conn != null) 
      {
        conn.Dispose ();
      }
    }
    public static Item Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `items` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int itemId = 0;
      string itemDescription = "";

      while (rdr.Read())
      {
        itemId = rdr.GetInt32(0);
        itemDescription = rdr.GetString(1);
      }

       Item foundItem= new Item(itemDescription, itemId); 

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
      return foundItem;
    }
  }
}