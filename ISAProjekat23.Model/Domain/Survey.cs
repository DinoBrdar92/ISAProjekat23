using ISAProjekat23.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAProjekat23.Model.Domain
{
    public class Survey
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public DateTime SurveyFilledOut { get; set; }

        Dictionary<int, bool?> Questions { get; set; } = null!;
    }
}
