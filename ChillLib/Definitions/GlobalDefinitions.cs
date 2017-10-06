using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChillLib.Definitions
{
    /// <summary>
    /// General mouse hoveposititon stuff
    /// </summary>
    public enum MouseHoverStates : int
    {
        /// <summary>
        /// Value set to this one if the mouse is hovering the item
        /// </summary>
        MouserOver = 0,
        /// <summary>
        /// Enum value if the mouse leaves its hovering state.
        /// </summary>
        MouseOut = 1,
    }
}
