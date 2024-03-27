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

        public Party(GooflingData[] members)
        {
            Members = new(PARTY_SIZE);
            foreach (GooflingData member in members)
            {
                Goofling goofling = new(member);
                Members.Add(goofling);
            }
        }

        public Party(TrainerGoofling[] members)
        {
            Members = new(PARTY_SIZE);
            foreach(TrainerGoofling member in members)
            {
                GooflingData data = Resources.Instance.GetGooflingData(member.GooflingType);
                data.Level = member.Level;
                Goofling goofling = new(data);
                Members.Add(goofling);
            }
        }

        ~Party()
        {
        }

    }
}
