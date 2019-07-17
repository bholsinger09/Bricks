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
  public class BricksController : ControllerBase
  {
    private readonly BrickRepository _repo;

    public BricksController(BrickRepository repo)
    {
      _repo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Brick>> Get()
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
    public ActionResult<Brick> Get(int id)
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
    public ActionResult<Brick> Post([FromBody] Brick value)
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
    public ActionResult<Brick> Put(int id, [FromBody] Brick value)
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
    public ActionResult<Brick> Delete(int id)
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
