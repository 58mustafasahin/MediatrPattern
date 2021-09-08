using System;

namespace AppCore.Entity.Abstract
{
    public class Audit
    {
        public Audit()
        {
            CDate = DateTime.Now;
        }

        public int CUserId { get; set; }
        public DateTime CDate { get; set; }
        public int? MUserId { get; set; }
        public DateTime? MDate { get; set; }
    }
}
