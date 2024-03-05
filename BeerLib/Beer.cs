using System.Diagnostics;

namespace BeerLib
{
    public class Beer
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public double AlcoholByVolume { get; set; }

        public override string ToString() =>
            $"{Id} {Name} {AlcoholByVolume}";

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("Name is null");
            }
            if (Name.Length < 4)
            {
                throw new ArgumentException("Name must be atleast 3 character" + Name);
            }
        }

        public void ValidateAlcoholByVolume()
        {
          if (AlcoholByVolume <= 0)
            {
                throw new ArgumentException("AlcoholByVolume must be greater than 0" + AlcoholByVolume);
            }
            if (AlcoholByVolume >= 67)
            {
                throw new ArgumentException("AlcoholByVolume must be less than 67" + AlcoholByVolume);
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateAlcoholByVolume();
        }






    }
}
