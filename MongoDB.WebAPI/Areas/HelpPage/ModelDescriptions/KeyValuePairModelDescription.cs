namespace MongoDB.WebAPI.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// KeyValuePairModelDescription
    /// </summary>
    public class KeyValuePairModelDescription : ModelDescription
    {
        /// <summary>
        /// KeyModelDescription
        /// </summary>
        public ModelDescription KeyModelDescription { get; set; }

        /// <summary>
        /// ValueModelDescription
        /// </summary>
        public ModelDescription ValueModelDescription { get; set; }
    }
}