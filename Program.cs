namespace BeerEncapsulator
{
    using System;

    class BeerEncapsulator
    {
        private decimal _availableBeerVolume; // Volume de bière disponible en centilitres
        private int _availableBottles; // Nombre de bouteilles disponibles
        private int _availableCapsules; // Nombre de capsules disponibles

        public decimal AvailableBeerVolume { get { return _availableBeerVolume; } }
        public int AvailableBottles { get { return _availableBottles; } }
        public int AvailableCapsules { get { return _availableCapsules; } }

        public BeerEncapsulator(decimal initialBeerVolume, int initialBottles, int initialCapsules)
        {
            _availableBeerVolume = initialBeerVolume;
            _availableBottles = initialBottles;
            _availableCapsules = initialCapsules;
        }

        public void AddBeer(decimal beerVolumeToAdd)
        {
            _availableBeerVolume += beerVolumeToAdd;
        }

        public int ProduceEncapsulatedBeerBottles(int numberOfBottlesToProduce)
        {
            if (_availableBeerVolume < numberOfBottlesToProduce * 33 || _availableBottles < numberOfBottlesToProduce || _availableCapsules < numberOfBottlesToProduce)
            {
                // Affiche un message spécifiant la quantité de composants nécessaire à la fabrication
                Console.WriteLine($"Insufficient components to produce {numberOfBottlesToProduce} bottles.");
                Console.WriteLine();
                Console.WriteLine($"You need at least: {numberOfBottlesToProduce * 33} cl of Beer, {numberOfBottlesToProduce} Bottles and {numberOfBottlesToProduce} Capsules to produce {numberOfBottlesToProduce} bottles");
                Console.WriteLine();
                return 0;
            }
            else
            {
                // Réalise la mise en bouteille
                _availableBeerVolume -= numberOfBottlesToProduce * 33;
                _availableBottles -= numberOfBottlesToProduce;
                _availableCapsules -= numberOfBottlesToProduce;
                Console.WriteLine($"Produced {numberOfBottlesToProduce} encapsulated beer bottles.");
                return numberOfBottlesToProduce;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BeerEncapsulator machine = new BeerEncapsulator(100, 50, 100); // Initialisation avec 100 cl de bière, 50 bouteilles et 100 capsules

            machine.ProduceEncapsulatedBeerBottles(5); // Essayons de produire 5 bouteilles
            machine.ProduceEncapsulatedBeerBottles(10); // Essayons de produire 10 bouteilles (devrait manquer de composants)

            Console.WriteLine($"Remaining beer volume: {machine.AvailableBeerVolume} cl");
            Console.WriteLine();
            Console.WriteLine($"Remaining bottles: {machine.AvailableBottles}");
            Console.WriteLine();
            Console.WriteLine($"Remaining capsules: {machine.AvailableCapsules}");

            Console.ReadLine();
        }
    }
}
