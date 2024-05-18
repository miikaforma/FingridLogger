namespace Fingrid.Datasets
{
    /// <summary>
    /// Represents real-time data types.
    /// </summary>
    public enum RealTime
    {
        /// <summary>
        /// Represents wind data.
        /// </summary>
        Wind = 181,

        /// <summary>
        /// Represents nuclear data.
        /// </summary>
        Nuclear = 188,

        /// <summary>
        /// Represents water data.
        /// </summary>
        Water = 191,

        /// <summary>
        /// Represents all production data.
        /// </summary>
        AllProduction = 192,

        /// <summary>
        /// Represents all consumption data.
        /// </summary>
        AllConsumption = 193,

        /// <summary>
        /// Represents district heating data.
        /// </summary>
        DistrictHeating = 201,

        /// <summary>
        /// Represents industrial data.
        /// </summary>
        Industrial = 202,

        /// <summary>
        /// Represents other data (Varavoimalaitokset ja pientuotanto).
        /// </summary>
        Other = 205
    }
}