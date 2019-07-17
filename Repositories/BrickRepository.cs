
using System;
using System.Data;
using Bricks.Models;

namespace Bricks.Repositories
{
  public class BrickRepository
  {
    private readonly IDbConnection _db;

    public BrickRepository(IDbConnection db)
    {
      _db = db;
    }

    internal object GetAll()
    {
      throw new NotImplementedException();
    }

    internal object GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal object Create(Brick value)
    {
      throw new NotImplementedException();
    }

    internal object Update(Brick value)
    {
      throw new NotImplementedException();
    }

    internal object Delete(int id)
    {
      throw new NotImplementedException();
    }
  }

}