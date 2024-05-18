namespace Fingrid.Datasets
{
    /// <summary>
    /// Represents forecast data types.
    /// </summary>
    public enum Forecast
    {
        /// <summary>
        /// Represents consumption forecast data.
        /// </summary>
        Consumption = 166,

        /// <summary>
        /// Represents production forecast data.
        /// </summary>
        Production = 241,

        /// <summary>
        /// Represents hourly wind forecast data.
        /// </summary>
        WindHourly = 245,

        /// <summary>
        /// Represents daily wind forecast data.
        /// </summary>
        WindDaily = 246,
    }
}
