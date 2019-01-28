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
            "Orangey Porangey","us","sets","card","manufacturing","tail","imagine","activity","must","discovery","cow","chose","soil","follow","screen","series","met","sitting","funny","consider","gas","substance","slope","live","cave","properly","unit","stairs","yellow","theory","blow","mighty","town","drove","loss","sharp","game","shut","pile","current","clay","machinery","silver","nails","family","lower","journey","clean","neighborhood","order","island","load","since","label","jet","shells","felt","aid","courage","past","farther","run","port","canal","volume","crack","audience","underline","went","poem","anywhere","shelf","held","ate","lie","pink","library","double","piano","married","globe","bent","radio","driven","friendly","scene","arm","getting","recall","rubbed","continent","dirt","tiny","had","society","it","stone","throw","bicycle","if","bell","bound","effort","move","step","tea","ring","spider","death","direction","adult","nation","another","cold","street","nearest","time","spoken","snake","upward","using","picture","within","cell","useful","bee","expect","market","start","regular","every","been","afternoon","describe","division","special","boat","attached","birthday","cause","variety","taught","cell","plan","settle","wall","particular","nice","topic","whose","point","cause","anywhere","lead","peace","three","being","hot","taken","was","begun","stiff","as","one","charge","took","five","dear","obtain","fourth","pay","depth","repeat","difference","examine","crack","scale","lips","wall","stood","mine","nearer","feed","point","degree","vertical","cent","sort","environment","rose","age","cut","that","raise","bee","railroad","construction","table","two"
        };

        private static string GenerateRandomName(FruitType type)
        {
            switch (type)
            {
                case FruitType.Orange:
                default:
                    return RandomOrangeNames[UnityEngine.Random.Range(0, RandomOrangeNames.Count - 1)] + " " + RandomOrangeNames[UnityEngine.Random.Range(0, RandomOrangeNames.Count - 1)];
            }
        }
    }
}
