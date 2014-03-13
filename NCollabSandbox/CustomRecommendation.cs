using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;
using NCollab.Interfaces;

namespace NCollabSandbox
{
    public class CustomRecommendation : Recommendation<User, Preference>
    {
        public CustomRecommendation(IMetric<Preference> metric)
            : base(metric)
        {
        }

        public override List<User> LoadData()
        {
            var result = new List<User>();
            var user = new User
            {
                Name = "Lisa Rose",
                Preferenceses = new List<Preference>
                {
                    new Preference {FilmName = "Lady in the Water", Rating = 2.5D},
                    new Preference {FilmName = "Snakes on a Plane", Rating = 3.5D},
                    new Preference {FilmName = "Just My Luck", Rating = 3.0D},
                    new Preference {FilmName = "Superman Returns", Rating = 3.5D},
                    new Preference {FilmName = "You, Me and Dupree", Rating = 2.5D},
                    new Preference {FilmName = "The Night Listener", Rating = 3.0D},
                }
            };
            result.Add(user);

            user = new User
            {
                Name = "Gene Seymour",
                Preferenceses = new List<Preference>
                {
                    new Preference {FilmName = "Lady in the Water", Rating = 3.0D},
                    new Preference {FilmName = "Snakes on a Plane", Rating = 3.5D},
                    new Preference {FilmName = "Just My Luck", Rating = 1.5D},
                    new Preference {FilmName = "Superman Returns", Rating = 5.0D},
                    new Preference {FilmName = "You, Me and Dupree", Rating = 3.5D},
                    new Preference {FilmName = "The Night Listener", Rating = 3.0D},
                }
            };
            result.Add(user);

            user = new User
            {
                Name = "Michael Phillips",
                Preferenceses = new List<Preference>
                {
                    new Preference {FilmName = "Lady in the Water", Rating = 2.5D},
                    new Preference {FilmName = "Snakes on a Plane", Rating = 3.0D},
                    new Preference {FilmName = "Superman Returns", Rating = 3.5D},
                    new Preference {FilmName = "The Night Listener", Rating = 4.0D},
                }
            };
            result.Add(user);

            user = new User
            {
                Name = "Claudia Puig",
                Preferenceses = new List<Preference>
                {
                    new Preference {FilmName = "Snakes on a Plane", Rating = 3.5D},
                    new Preference {FilmName = "Just My Luck", Rating = 3.0D},
                    new Preference {FilmName = "The Night Listener", Rating = 4.5D},
                    new Preference {FilmName = "Superman Returns", Rating = 4.0D},
                    new Preference {FilmName = "You, Me and Dupree", Rating = 2.5D},
                }
            };
            result.Add(user);

            user = new User
            {
                Name = "Mick LaSalle",
                Preferenceses = new List<Preference>
                {
                    new Preference {FilmName = "Lady in the Water", Rating = 3.0D},
                    new Preference {FilmName = "Snakes on a Plane", Rating = 4.0D},
                    new Preference {FilmName = "Just My Luck", Rating = 2.0D},
                    new Preference {FilmName = "Superman Returns", Rating = 3.0D},
                    new Preference {FilmName = "The Night Listener", Rating = 3.0D},
                    new Preference {FilmName = "You, Me and Dupree", Rating = 2.0D},
                }
            };
            result.Add(user);

            user = new User
            {
                Name = "Jack Matthews",
                Preferenceses = new List<Preference>
                {
                    new Preference {FilmName = "Lady in the Water", Rating = 3.0D},
                    new Preference {FilmName = "Snakes on a Plane", Rating = 4.0D},
                    new Preference {FilmName = "Superman Returns", Rating = 5.0D},
                    new Preference {FilmName = "The Night Listener", Rating = 3.0D},
                    new Preference {FilmName = "You, Me and Dupree", Rating = 3.5D},
                }
            };
            result.Add(user);

            user = new User
            {
                Name = "Toby",
                Preferenceses = new List<Preference>
                {
                    new Preference {FilmName = "Snakes on a Plane", Rating = 4.5D},
                    new Preference {FilmName = "Superman Returns", Rating = 4.0D},
                    new Preference {FilmName = "You, Me and Dupree", Rating = 1.0D},
                }
            };
            result.Add(user);

            return result;
        }
    }
}
