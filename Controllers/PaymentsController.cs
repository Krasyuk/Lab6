using LanguageClassesApiApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageClassesApiApp.ViewModels;

namespace LanguageClassesApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        Data.AppContext _context;
        public PaymentsController(Data.AppContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<PaymentViewModel> Get()
        {
            var payments = _context.Payments.Include(c => c.Course).Include(l => l.Listener).Select(s =>
            new PaymentViewModel
            {
                PaymentId = s.PaymentId,
                NameOfCourses = s.NameOfCourses,
                Date = s.Date,
                Sum = s.Sum,
                ListenerId = s.ListenerId,
                LastPaymentDate = s.LastPaymentDate,
                CourseId = s.CourseId,
                NameOfListener = s.Listener.NameOfListener,
                NameOfCourse = s.Course.NameOfCourse
            }).Take(20).ToList(); ;
            return payments;
        }
        [HttpGet("courses")]
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }
        [HttpGet("listeners")]
        public IEnumerable<Listener> GetListeners()
        {
            return _context.Listeners.ToList();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Payment payment = _context.Payments.FirstOrDefault(x => x.PaymentId == id);
            if (payment == null)
                return NotFound();
            return new ObjectResult(payment);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Payment payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }

            _context.Payments.Add(payment);
            _context.SaveChanges();
            return Ok(_context);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Payment payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }
            if (!_context.Payments.Any(x => x.PaymentId == payment.PaymentId))
            {
                return NotFound();
            }

            _context.Update(payment);
            _context.SaveChanges();
            return Ok(payment);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Payment payment = _context.Payments.FirstOrDefault(x => x.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }
            _context.Payments.RemoveRange(payment);
            _context.SaveChanges();
            return Ok(payment);
        }
    }
}
