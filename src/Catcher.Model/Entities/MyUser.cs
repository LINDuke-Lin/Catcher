using System;
using System.Collections.Generic;

namespace Catcher.Model.Entities
{
    public partial class MyUser
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
