using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdeaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly DataContext dataContext;

        public IdeaController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dataContext.ideas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Idea>> Get(int id)
        {
            var idea = await dataContext.ideas.FindAsync(id);
            if (idea == null)
                return BadRequest("idea not found");
            return Ok(idea);
        }

        [HttpPost]
        public async Task<IActionResult> AddIdea([FromForm] Idea newIdea)
        {
            dataContext.ideas.Add(newIdea);
            await dataContext.SaveChangesAsync();

            return Ok(await dataContext.ideas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateIdea([FromForm] Idea updateIdea)
        {
            var idea = await dataContext.ideas.FindAsync(updateIdea.Id);
            if (idea == null)
                return BadRequest("idea not found");

            idea.IdeaText = updateIdea.IdeaText;
            idea.UpVote = updateIdea.UpVote;
            idea.downVote = updateIdea.downVote;

            await dataContext.SaveChangesAsync();

            return Ok(await dataContext.ideas.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Idea>> Delete(int id)
        {
            var idea = await dataContext.ideas.FindAsync(id);
            if (idea == null)
                return BadRequest("idea not found");

            dataContext.ideas.Remove(idea);
            await dataContext.SaveChangesAsync();

            return Ok(await dataContext.ideas.ToListAsync());
        }
    }
}

