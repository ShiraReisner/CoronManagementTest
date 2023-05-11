using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public byte[] Picture1 { get; set; } = null!;
        public int PatientId { get; set; }

        public IFormFile File { get; set; }
    }
}
