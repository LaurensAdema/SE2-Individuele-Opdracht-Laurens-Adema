// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OS.cs" company="">
//   
// </copyright>
// <summary>
//   The os.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tweakers
{
    /// <summary>
    /// The os.
    /// </summary>
    public class OS
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OS"/> class.
        /// </summary>
        /// <param name="osid">
        /// The osid.
        /// </param>
        /// <param name="osString">
        /// The os string.
        /// </param>
        public OS(int osid, string osString)
        {
            this.OSID = osid;
            this.OSString = osString;
        }

        /// <summary>
        /// Gets or sets the osid.
        /// </summary>
        public int OSID { get; set; }

        /// <summary>
        /// Gets or sets the os string.
        /// </summary>
        public string OSString { get; set; }
    }
}