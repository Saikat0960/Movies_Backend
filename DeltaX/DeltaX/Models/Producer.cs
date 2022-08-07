using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX.Models
{
	public class Producer
	{
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public virtual IEnumerable<Movie> Movies { get; set; }
    }
}
