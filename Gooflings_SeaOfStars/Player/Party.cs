using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class Party
    {
        const int PARTY_SIZE = 6;

        public List<Goofling> Members { get; private set; }
        public int Count => Members.Count;

        public Party()
        {
           Members = new(PARTY_SIZE);
        }

        ~Party()
        {
        }

    }
}
