using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bricks.Models;
using Bricks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bricks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BSetsController : ControllerBase
  {
    private readonly BSetsRepository _repo;

    public BSetsController(BSetsRepository repo)
    {
      _repo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<BSet>> Get()
    {
      try
      {
        return Ok(_repo.GetAll());
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<BSet> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);

      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<BSet> Post([FromBody] BSet value)
    {
      try
      {
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);

      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<BSet> Put(int id, [FromBody] BSet value)
    {

      try
      {
        value.Id = id;
        return Ok(_repo.Update(value));

      }
      catch (Exception e)
      {
        return BadRequest(e);

      }

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<BSet> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));

      }
      catch (Exception e)
      {
        return BadRequest(e);

      }
    }
  }
}
