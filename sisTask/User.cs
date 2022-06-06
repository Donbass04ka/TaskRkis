using System;
using System.Collections.Generic;

namespace sisTask
{
    public partial class User
    {
        public User()
        {
            TaskIdAuthorNavigations = new HashSet<Task>();
            TaskIdWorkerNavigations = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string SecondName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Patric { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string NumberPhone { get; set; } = null!;

        public virtual ICollection<Task> TaskIdAuthorNavigations { get; set; }
        public virtual ICollection<Task> TaskIdWorkerNavigations { get; set; }
    }
}
