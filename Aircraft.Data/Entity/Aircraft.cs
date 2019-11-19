using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aircraft.Data.Entity
{
    public class Aircraft
    {
        /// <summary>
        /// The primary key for each aircraft. In a real world setting, we would have something like an Oracle Sequence tied to this,
        /// so that each key is unique. In this simple case, the abstract factory will be responsible for enforcing uniqueness.
        /// Also, we had entity framework setup a unique constraint.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The model of the aircraft. For this example, we limit the length to 256 characters to preserve space on the DB and to keep queries short.
        /// You can always go longer, but you can't go shorter.
        /// </summary>
        [MaxLength(256)]
        public string Model { get; set; }

        /// <summary>
        /// Serial number. According to Dassault, they want it limited to 3 numbers and is padded with leading zeros. We chose a string datatype in this case
        /// as it formats better the way they want it.
        /// </summary>
        [MaxLength(3)]
        public string SerialNumber { get; set; }
    }
}
