using System;
using System.Reflection;

namespace MongoDB.WebAPI.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// IModelDocumentationProvider
    /// </summary>
    public interface IModelDocumentationProvider
    {
        /// <summary>
        /// GetDocumentation
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        string GetDocumentation(MemberInfo member);

        /// <summary>
        /// GetDocumentation
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        string GetDocumentation(Type type);
    }
}