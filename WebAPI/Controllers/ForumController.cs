

using Assigntment1.models;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
//The [Route] specifies how to access this specific controller with a REST request.
[ApiController]
[Route("[Controller]")]
//We inherit from ControllerBase to get access to convenient methods.
public class ForumController: ControllerBase
{
    
    private ISubForum subForum;

    public ForumController(ISubForum subForum)
    {
        this.subForum = subForum;
    }
    
    //We mark the method with [HtppG
    //et] to indicate that if a GET request is made to /todos
    //it must hit this endpoint.
    
    //The return type is ActionResult, which returns an http response with an ICollection<Todo>.
    [HttpGet]
    public async Task<ActionResult<SubForum>> GetAll()
    {
        try
        {
            List<SubForum>? subForums = await subForum.GetAllTitlesAsync();
            return Ok(subForums);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<ActionResult<SubForum>> GetById([FromRoute] Guid id)
    {
       // Guid guid = Guid.Parse(id);
        try
        {
            SubForum subForums = await subForum.GetPostById(id);
            return Ok(subForums);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        
    }
    
    
  
    
     
    [HttpPost]
    public async Task<ActionResult<SubForum>> AddTodo([FromBody] SubForum todo)
    {
        try
        {
            
         SubForum added =  await subForum.CreateAPost(todo);
            
            return Created($"/{added.Guid}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    
}