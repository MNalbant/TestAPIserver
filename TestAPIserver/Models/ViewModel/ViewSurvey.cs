using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIserver.Models.ViewModel
{
    public class ViewSurvey
    {
        public int Id { get; set; }
        public List<ViewQuestion> ViewQuestions { get; set; }
    }
}
