using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MongoDB.WebAPI.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// EnumTypeModelDescription
    /// </summary>
    public class EnumTypeModelDescription : ModelDescription
    {
        /// <summary>
        /// EnumTypeModelDescription
        /// </summary>
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        /// <summary>
        /// Values
        /// </summary>
        public Collection<EnumValueDescription> Values { get; private set; }
    }
}