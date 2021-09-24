using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApi.DTO.Request
{
    public class UserRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }  
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}