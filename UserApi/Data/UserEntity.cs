using System;
using System.Collections.Generic;

namespace UserApi.Data
{
    public partial class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
