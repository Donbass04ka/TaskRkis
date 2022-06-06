using System;
using System.Collections.Generic;

namespace sisTask
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Writing { get; set; } = null!;
        public DateTime Data { get; set; }
        public int? IdWorker { get; set; }
        public int IdAuthor { get; set; }
        public int IdStatus { get; set; }

        public virtual User IdAuthorNavigation { get; set; } = null!;
        public virtual StatusTask IdStatusNavigation { get; set; } = null!;
        public virtual User? IdWorkerNavigation { get; set; }
    }
}
