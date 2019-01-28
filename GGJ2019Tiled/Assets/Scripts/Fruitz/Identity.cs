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

        private static int MaxNumber = 1;

        public int Number { get; set; }
        public string Name { get; set; }
        public FruitType Type { get; set; }
        public int Score { get; set; }

        public static Identity GenerateNewIdentity()
        {
            var number = MaxNumber++;
            var type = SelectRandomType();
            var name = GenerateRandomName(type);
            return new Identity() { Number = number, Type = type, Name = name, Score = 0 };
        }

        private static FruitType SelectRandomType()
        {
            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    return FruitType.Orange;
                case 1:
                    return FruitType.Lime;
                case 2:
                    return FruitType.Banana;
                default:
                    return FruitType.Orange;
            }
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
