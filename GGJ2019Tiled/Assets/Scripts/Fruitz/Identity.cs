using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Fruitz
{
    public class Identity
    {
        private Identity() { }

        public string Name { get; set; }
        public FruitType Type { get; set; }
        public int Score { get; set; }

        public static Identity GenerateNewIdentity()
        {
            var type = SelectRandomType();
            var name = GenerateRandomName(type);
            return new Identity() { Type = type, Name = name, Score = 0 };
        }

        private static FruitType SelectRandomType()
        {
            return FruitType.Orange;
        }

        private static List<string> RandomOrangeNames = new List<string>()
        {
            "Orangey Porangey",
        };

        private static string GenerateRandomName(FruitType type)
        {
            switch (type)
            {
                case FruitType.Orange:
                default:
                    return RandomOrangeNames[UnityEngine.Random.Range(0, RandomOrangeNames.Count - 1)];
            }
        }
    }
}
