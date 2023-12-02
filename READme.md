To get started, install Dapper & Microsoft.Data.SqlClient from Nuget.

In the connStr pass in your connection string.

Make sure you have a model setup, and the table in the database, make sure the model is mapped / named correctly to your table values.

In my example -:

Heroes model

      public class Heroes
      {
          public int Id { get; set; }
          public string? Name { get; set; }
          public string? FirstName { get; set; }
          public string? LastName { get; set; }
          public string? City { get; set; }
      }


  Main program

      QueryDB db = new QueryDB();
    
      List<Heroes> heroes = db.All("Heroes").Get<Heroes>().ToList();

Here I am querying the database by using the All() method to get all.

This will also work -:

      List<Heroes> heroes = db.Select("*").From("Heroes").Get<Heroes>().ToList();

If I have a stored procedure which gets me all the heroes, I can call it and get the same result

      List<Heroes> heroes = db.StoredProcedure("GetAllHeroes").Get<Heroes>(new {  }, true).ToList();

