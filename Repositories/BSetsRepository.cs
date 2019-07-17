
using System;
using System.Collections.Generic;
using System.Data;
using Bricks.Models;
using Dapper;

namespace Bricks.Repositories
{
  public class BSetsRepository
  {
    private readonly IDbConnection _db;

    public BSetsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<BSet> GetAll()
    {
      return _db.Query<BSet>("SELECT * FROM bsets");

    }

    public BSet GetById(int id)
    {
      string query = "SELECT * FROM bsets WHERE id = @id";
      BSet bset = _db.QueryFirstOrDefault<BSet>(query, new { id });
      if (bset is null) throw new Exception("Invalid Id");
      return bset;


    }

    public BSet Create(BSet value)
    {
      string query = @"
     INSERT INTO bsets (title, descr)
          VALUES(@Title, @Description)";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public BSet Update(BSet value)
    {
      string query = @"
      UPDATE bset
      SET   
         title = @Title
      WHERE id = @Id;

      SELECT * FROM bsets WHERE id = @Id";
      return _db.QueryFirstOrDefault<BSet>(query, value);

    }

    public string Delete(int id)
    {
      string query = "DELETE FROM bsets WHERE id = @Id";
      int changedRows = _db.Execute(query, new { id });
      if (changedRows != 1) throw new Exception("Invalid Id ");
      return "Successfully deleted the set";

    }
  }





}