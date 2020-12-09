using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageClassesApiApp.ViewModels
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public string NameOfCourses { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public int ListenerId { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public int CourseId { get; set; }
        public string NameOfListener { get; set; }
        public string NameOfCourse { get; set; }
    }
}
