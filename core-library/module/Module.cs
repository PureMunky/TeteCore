using System;

namespace Tete.Modules
{
    public class Module
    {
        #region "Public Properties"
        /// <summary>
        /// The Unique Name of the module.
        /// Used to identify the module for calls.
        /// </summary>
        /// <value></value>
        public string Name {get; set;}

        /// <summary>
        /// The url that all of the available services are appended to.
        /// </summary>
        /// <value></value>
        public string BaseUrl {get; set;}

        #endregion

        #region Constructors

        public Module()
        {
            this.Name = String.Empty;
            this.BaseUrl = String.Empty;
        }

        #endregion
    }
}
