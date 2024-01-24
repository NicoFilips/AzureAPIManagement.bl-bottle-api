namespace FlaschenPostAPI.Util
{
    /// <summary>
    /// Interface defining utility methods for beer data handling.
    /// </summary>
    public interface IBeerUtil
    {
        /// <summary>
        /// Retrieves a list of Beer objects from a JSON source.
        /// </summary>
        /// <returns>A List of Beer objects.</returns>
        List<Beer> GetBeerData();

        /// <summary>
        /// Calculates the price per litre of beer from a given price per unit string.
        /// </summary>
        /// <param name="pricePerUnit">The price per unit string, typically in the format "(€X/Liter)".</param>
        /// <returns>The price per litre as a double.</returns>
        double BeerpricePerLitre(string pricePerUnit);

        /// <summary>
        /// Extracts the amount of bottles from a short description.
        /// </summary>
        /// <param name="shortDescription">The short description string, typically containing "Xx", where X is the number of bottles.</param>
        /// <returns>The number of bottles as a double.</returns>
        double GetAmountBottles(string shortDescription);
    }
}