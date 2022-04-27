using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover.Repository
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        /// 
        public int Id { get; set; }
    }
}
