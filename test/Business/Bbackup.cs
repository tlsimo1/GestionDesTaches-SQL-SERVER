using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Data;

namespace test.Business
{
    public class Bbackup
    {
        Gbackup gbackup = new Gbackup();
        public DataTable GetNameDatabase()
        {
            return gbackup.GetNameDatabase();
        }
        public void VerifyExisting()
        {
             gbackup.VerifyExisting();
        }
    }
}
