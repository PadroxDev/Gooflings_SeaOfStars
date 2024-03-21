using System;
using System.Collections.Generic;

namespace Gooflings
{
    public enum TrainerType
    {
        Unknown,
        Alice
    }

    public struct TrainerData
    {
        public TrainerType TrainerType;
        public string Name;
        public TrainerGoofling[] Party;

        public TrainerData()
        {
            TrainerType = TrainerType.Unknown;
            Name = "Unknown";
            Party = null;
        }
    }

    public class Trainer
    {
        public TrainerType TrainerType { get; private set; }
        public string Name { get; private set; }
        public Party Party { get; private set; }

        public Trainer(TrainerData data)
        {
            TrainerType = data.TrainerType;   
            Name = data.Name;
            Party = new Party()
        }

        ~Trainer()
        { }
    }
}
