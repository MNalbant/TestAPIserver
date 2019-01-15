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
    public class SurveysController : ControllerBase
    {
        private readonly DBContext _context;

        public SurveysController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Surveys
        [HttpGet]
        public IEnumerable<Survey> GetSurveys()
        {
            return _context.Surveys;
        }

        // GET: api/Surveys
        [HttpGet("{sortedOn}")]
        public IEnumerable<Survey> GetSurveysSorted([FromRoute] int sortedOn)
        {
            switch (sortedOn)
            {
                case 1:  //Oldest
                    return _context.Surveys.OrderByDescending(x => x.StartDate); 
                case 2:  //highest income
                    return _context.Surveys.OrderByDescending(x => x.Reward);
                case 3:  //Lowest income
                    return _context.Surveys.OrderBy(x => x.Reward);
                case 4:  //First expiring 
                    return _context.Surveys.OrderBy(x => x.EndDate);
                case 5:  //Last expiring
                    return _context.Surveys.OrderByDescending(x => x.EndDate);
                default:  //Default newest
                    return _context.Surveys.OrderBy(x => x.StartDate);  
            }
        }

        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurvey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var survey = await _context.Surveys.FindAsync(id);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }

        // PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey([FromRoute] int id, [FromBody] Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != survey.Id)
            {
                return BadRequest();
            }

            _context.Entry(survey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveyExists(id))
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

        // POST: api/Surveys
        [HttpPost]
        public async Task<IActionResult> PostSurvey([FromBody] Survey survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Surveys.Add(survey);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                string l = "lol";
            }

            return CreatedAtAction("GetSurvey", new { id = survey.Id }, survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var survey = await _context.Surveys.FindAsync(id);
            if (survey == null)
            {
                return NotFound();
            }

            _context.Surveys.Remove(survey);
            await _context.SaveChangesAsync();

            return Ok(survey);
        }

        private bool SurveyExists(int id)
        {
            return _context.Surveys.Any(e => e.Id == id);
        }
    }
}