using System;

namespace _001JIMCV.Models.Classes
{
    public class PackServices
    {
        public int Id { get; set; }
        public float total_price { get; set; }
        public Boolean all_inclusive { get; set; }

        public virtual Accommodation accommodation { get; set; }
        public virtual Flight flight { get; set; }
        public virtual Activity Activity { get; set; }

    }
}
