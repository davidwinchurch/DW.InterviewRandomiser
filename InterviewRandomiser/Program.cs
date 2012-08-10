using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InterviewRandomiser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var interviewList = GenerateInterviewList(500, 5);

            File.WriteAllText("Interviews.csv", interviewList);

            Console.ReadLine();
        }

        private static string GenerateInterviewList(int interviewCount, int brandsPerInterview)
        {
            var sb = new StringBuilder();
            
            var random = new Random();
            
            var brandMentions = new int[BrandList.Length];

            var maxBrandMentions = (interviewCount*brandsPerInterview)/BrandList.Length;

            var stringBuilders = new StringBuilder[brandsPerInterview + 2];
            for (var i = 0; i < stringBuilders.Count(); i++)
            {
                stringBuilders[i] = new StringBuilder();
            }

            for (var i = 0; i < interviewCount; i++)
            {
                stringBuilders[0].Append((i+1) + ",");
                stringBuilders[1].Append("McDonalds,");
                var brands = String.Empty;
                for (var j = 0; j < brandsPerInterview; j++)
                {
                    var brandIndex = random.Next(BrandList.Length);
                    var brand = BrandList[brandIndex];
                    while (brandMentions[brandIndex] >= maxBrandMentions || brands.Contains(brand))
                    {
                        brandIndex = random.Next(BrandList.Length);
                        brand = BrandList[brandIndex];
                    }
                    stringBuilders[2 + j].Append(brand + ",");
                    brandMentions[brandIndex]++;
                }
            }

            //Write out interviews
            foreach (var stringBuilder in stringBuilders)
            {
                sb.AppendLine(stringBuilder.ToString());
            }
            sb.AppendLine();

            //Write out counts
            for (var i = 0; i < BrandList.Length; i++)
            {
                sb.AppendLine(BrandList[i] + "," + brandMentions[i]);
            }

            return sb.ToString();
        }

        private static readonly string[] BrandList = new[]
                                                        {
                                                            "Coca Cola",
                                                            "Acer",
                                                            "Atos",
                                                            "Dow",
                                                            "GE",
                                                            "Omega",
                                                            "Panasonic",
                                                            "P&G",
                                                            "Samsung",
                                                            "Visa",
                                                            "Powerade",
                                                            "Pepsi",
                                                            "Vodafone",
                                                            "Nike",
                                                            "Subway",
                                                            "KFC",
                                                            "Sbarro",
                                                            "Burger King",
                                                            "Adidas",
                                                            "BMW",
                                                            "British Airways",
                                                            "BT",
                                                            "EDF",
                                                            "Lloyds TSB",
                                                            "BP"
                                                        };
    }
}
