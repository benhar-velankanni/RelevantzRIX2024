using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTraining.Models
{
    
    public class Training
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

}