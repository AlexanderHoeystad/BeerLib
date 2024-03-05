using BeerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLib
{
    public class BeerRepository
    {
        private int nextId = 6;
        private List<Beer> _beers = new()
        {
           new Beer { Id = 1, Name = "Corona", AlcoholByVolume = 4.5 },
           new Beer { Id = 2, Name = "Blanc", AlcoholByVolume = 5 },
           new Beer { Id = 3, Name = "Grøn Tuborg", AlcoholByVolume = 4.6 },
           new Beer { Id = 4, Name = "Snake Venom", AlcoholByVolume = 67 },
           new Beer { Id = 5, Name = "Budweiser", AlcoholByVolume = 5 }
        };
        

        public List<Beer> GetBeer(string? nameStart = null, string? sortby = null)
        {
            List<Beer> result = new List<Beer>(_beers);

            if (nameStart != null)
            {
                result = result.FindAll(b => b.Name.Contains(nameStart));
            }

            if (sortby != null)

                switch (sortby)
                {
                    case "Name":
                        result.Sort((b1, b2) => b1.Name.CompareTo(b2.Name));
                        break;
                    case "Name_desc":
                        result.Sort((b1, b2) => b2.Name.CompareTo(b1.Name));
                        break;
                        case "AlcoholByVolume":
                        result.Sort((b1, b2) => b1.AlcoholByVolume.CompareTo(b2.AlcoholByVolume));
                        break;
                        case "AlcoholByVolume_desc":
                        result.Sort((b1, b2) => b2.AlcoholByVolume.CompareTo(b1.AlcoholByVolume));
                        break;
                    
                }
            return result;
        }

        public Beer AddBeer(Beer beer)
        {
            beer.Id = nextId++;
            _beers.Add(beer);
            return beer;
        }

        public Beer? GetBeerById(int id)
        {
            return _beers.Find(b => b.Id == id);
        }

        public Beer? DeleteBeer(int id)
        {
            Beer? beer = _beers.Find(b => b.Id == id);
            if (beer != null)
            {
                _beers.Remove(beer);
            }
            return beer;
        }

        public Beer UpdateBeer(int id, Beer data)
        {
            Beer? BeerToUpdate = _beers.Find(b => b.Id == id);
            if (BeerToUpdate != null)
            {
                BeerToUpdate.Name = data.Name;
                BeerToUpdate.AlcoholByVolume = data.AlcoholByVolume;
            }
            return BeerToUpdate;
        }

        public override string ToString()
        {
            return string.Join("\n", _beers);
        }

    }
}
