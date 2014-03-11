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
            var customRecommendation = new CustomRecommendation(new Euclidian<Preference>(),
                new PreferenceEqualityComparer(), new UserEqualityComparer());
            var users = customRecommendation.LoadData();
            var result = customRecommendation.GetRecomendations(users.First(c => c.Name == "Toby"), users.ToList());

            foreach (var item in result.ToList().OrderByDescending(c => c.Value))
            {
                Console.WriteLine("{0} {1}",item.Key.FilmName, item.Value);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
