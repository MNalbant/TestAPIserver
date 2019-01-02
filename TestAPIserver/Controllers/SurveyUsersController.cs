using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPIserver.Models;

namespace TestAPIserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyUsersController : ControllerBase
    {
        private readonly DBContext _context;

        public SurveyUsersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/SurveyUsers
        [HttpGet]
        public IEnumerable<SurveyUser> GetSurveyUser()
        {
            return _context.SurveyUsers;
        }

        // GET: api/SurveyUsers/5/3
        [HttpGet("{id}/{surveyId}")]
        public async Task<IActionResult> GetSurveyUser([FromRoute] int userId, [FromRoute] int surveyId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var surveyUser = await _context.SurveyUsers.FirstOrDefaultAsync(u => u.UserId == userId && u.SurveyId == surveyId);


            if (surveyUser == null)
            {
                return NotFound();
            }

            return Ok(surveyUser);
        }

        // PUT: api/SurveyUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurveyUser([FromRoute] int id, [FromBody] SurveyUser surveyUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surveyUser.SurveyId)
            {
                return BadRequest();
            }

            _context.Entry(surveyUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SurveyUsers
        [HttpPost]
        public async Task<IActionResult> PostSurveyUser([FromBody] SurveyUser surveyUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (FilledSurvey(surveyUser))
            {
                _context.SurveyUsers.Add(surveyUser);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (SurveyUserExists(surveyUser.SurveyId))
                    {
                        return new StatusCodeResult(StatusCodes.Status409Conflict);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else { return new StatusCodeResult(StatusCodes.Status400BadRequest); }


            return CreatedAtAction("GetSurveyUser", new { id = surveyUser.SurveyId }, surveyUser);
        }

        private bool FilledSurvey(SurveyUser surveyUser)
        {
            bool filled = false;

            foreach (Question q in surveyUser.Survey.Questions)
            {
                foreach(ClosedAnswer c in q.ClosedAnswers)
                {
                    if (c.Response)
                    {
                        filled = true; 
                    }
                    else { filled = false ;  }
                }

                if (!q.OpenAnswer.Response.Equals(""))
                {
                    filled = true;
                }
            }   

            return filled;
        }

        // DELETE: api/SurveyUsers/5/3
        [HttpDelete("{userId}/{surveyId}")]
        public async Task<IActionResult> DeleteSurveyUser([FromRoute] int userId, [FromRoute] int surveyId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var surveyUser = await _context.SurveyUsers.FirstOrDefaultAsync(u => u.UserId == userId && u.SurveyId == surveyId);
            if (surveyUser == null)
            {
                return NotFound();
            }

            _context.SurveyUsers.Remove(surveyUser);
            await _context.SaveChangesAsync();

            return Ok(surveyUser);
        }

        private bool SurveyUserExists(int id)
        {
            return _context.SurveyUsers.Any(e => e.SurveyId == id);
        }
    }
}