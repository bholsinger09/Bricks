
using System.Data;

namespace Bricks.Repositories
{
  public class BSetsRepository
  {
    private readonly IDbConnection _db;

    public BSetsRepository(IDbConnection db)
    {
      _db = db;
    }



  }





}