﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<int, HashSet<int>>> houseOfCards = new Dictionary<string, Dictionary<int, HashSet<int>>>();
            string input = Console.ReadLine();

            while (input != "JOKER")
            {
                string[] handInfo = input.Split(new char[] { ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = handInfo[0];

                if (!houseOfCards.ContainsKey(name))
                {
                    houseOfCards.Add(name, new Dictionary<int, HashSet<int>>());

                    for (int i = 1; i <= 4; i++)
                    {
                        houseOfCards[name].Add(i, new HashSet<int>());
                    }
                }

                for (int i = 1; i < handInfo.Length; i++)
                {
                    string currentCard = handInfo[i].Trim();
                    int face = 0;
                    int suite = 0;

                    if (currentCard.Length > 2)
                    {
                        face = GetFace(currentCard.Substring(0, 2));
                        suite = GetSuite(currentCard.Substring(2));
                    }
                    else
                    {
                        face = GetFace(currentCard[0].ToString());
                        suite = GetSuite(currentCard[1].ToString());
                    }

                    if (!houseOfCards[name][suite].Contains(face))
                    {
                        houseOfCards[name][suite].Add(face);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var outerPair in houseOfCards)
            {
                int sum = 0;
                foreach (var inner in outerPair.Value)
                {
                    sum += inner.Key * inner.Value.Sum();
                }
                Console.WriteLine("{0}: {1}", outerPair.Key, sum);
            }
        }

        private static int GetSuite(string suite)
        {
            switch (suite)
            {
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
                case "C":
                    return 1;
                default:
                    return 0;
            }
        }

        private static int GetFace(string face)
        {
            switch (face)
            {
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;

                default:
                    return int.Parse(face);
            }
        }
    }
}