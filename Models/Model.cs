using System;
using System.Collections.Generic;

namespace Availibility.Models
{
    public partial class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}
