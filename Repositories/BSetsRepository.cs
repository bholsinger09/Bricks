
using System;
using System.Data;
using Bricks.Models;

namespace Bricks.Repositories
{
  public class BSetsRepository
  {
    private readonly IDbConnection _db;

    public BSetsRepository(IDbConnection db)
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

    internal object Create(BSet value)
    {
      throw new NotImplementedException();
    }

    internal object Update(BSet value)
    {
      throw new NotImplementedException();
    }

    internal object Delete(int id)
    {
      throw new NotImplementedException();
    }
  }





}