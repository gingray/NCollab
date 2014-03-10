using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Metrics;

namespace NCollabSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var customRecommendation = new CustomRecommendation(new Euclidian(),
                new CustomPreferenceEqualityComparer(), new CustomKeyEqualityComparer());
            var users = customRecommendation.LoadData();
            var result = customRecommendation.GetRecomendations(users.First(), users.Skip(1).ToList());
            foreach (var preferencese in result)
            {
                Console.WriteLine(preferencese);
            }
        }
    }
}
