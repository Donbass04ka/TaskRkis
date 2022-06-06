using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sisTask
{
    public class Helper
    {
        public static sisTaskContext db = new sisTaskContext();
        public static User userSession;
        public static Task task;
    }
}
