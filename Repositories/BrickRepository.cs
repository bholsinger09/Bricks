
using System;
using System.Collections.Generic;
using System.Data;
using Bricks.Models;
using Dapper;

namespace Bricks.Repositories
{
  public class BrickRepository
  {
    private readonly IDbConnection _db;

    public BrickRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Brick> GetAll()
    {
      return _db.Query<Brick>("SELECT * FROM bricks");
    }

    public Brick GetById(int id)
    {
      string query = ("SELECT * FROM bricks WHERE id = @id");
      Brick brick = _db.QueryFirstOrDefault<Brick>(query, new { id });
      if (brick == null) throw new Exception("Invadid Id");
      return brick;


    }

    public object Create(Brick value)
    {
      string query = @"
      INSERT INTO bricks(shape)
      VALUES (@Shape);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;


    }

    public object Update(Brick value)
    {
      string query = @"
      UPDATE bricks
      SET
         shape = @shape

      WHERE id = @Id;
      SELECT * FROM flowers WHERE id = @Id";
      return _db.QueryFirstOrDefault<Brick>(query, value);

    }

    public object Delete(int id)
    {
      string query = "DELETE FROM flowers WHERE id = @Id"
      int changedRows = _db.Execute(query, new { id });
      if (changedRows < 1) throw new Exception("Invalid Id");
      return "Successfully deleted brick";

    }
  }

}