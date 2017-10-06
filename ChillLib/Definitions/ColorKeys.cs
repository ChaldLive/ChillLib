/*
 * Created by SharpDevelop.
 * User: Carsten
 * Date: 01-04-2010
 * Time: 13:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ChillLib.Definitions
{
	/// <summary>
	/// Description of ColorKeys.
	/// </summary>
	public static class ColorBrushKeys
	{
		#region ButtonChrome color keys
		/// <summary>
		/// The resource name of the border color for the button chrome.
		/// </summary>
        public static string ButtonChromeDefaultBorderBrush = "ButtonChromeDefaultBorderBrushKey";
		/// <summary>
		/// The resource name of the inner border of the button chrome. The mouse 
		/// over border color key.
		/// </summary>
        public static string ButtonChromeDefaultInnerBorderBrush = "ButtonChromeDefaultInnerBorderBrushhKey";
        /// <summary>
        /// This is the top sheen gradiant brush. Transparent so that the solid color brush
        /// from below can shine through.
        /// </summary>
        public static string ButtonChromeDefaultTopSheenBrush = "ButtonChromeTopSheenBrushKey";
        /// <summary>
        /// The solid background fill colorbrush of the buttonchrome control.
        /// </summary>
        public static string ButtonChromeDefaultFillColorBrush = "ButtonChromeDefaultFillColorBrushKey";
        /// <summary>
        /// The topsheen of the button chrome reflecting the mouse hover state.
        /// </summary>
        public static string ButtonChromeMouseHoverTopSheenBrush = "ButtonChromeMouseHoverTopSheenBrushKey";
        /// <summary>
        /// The name of the borderbrush key of the inner border brush reflecting the mouse hover state 
        /// </summary>
        public static string ButtonChromeMouseHoverInnerBorderBrush = "ButtonChromeMouseHoverInnerBorderBrushKey";
        /// <summary>
        /// This is the top resource key name of the brushe definng the top sheen when in mouse pressed state.
        /// </summary>
        public static string ButtonChromePressedStateTopSheenBrush = "ButtonChromePressedStateTopSheenBrushKey";
        /// <summary>
        /// The name of the forgroundbrush of the buttonchrome deffinition.
        /// </summary>
        public static string ButtonChromeForegroundBrush = "ButtonChromeForegroundBrushKey";
		
		#endregion
        //
        #region UIElement color and brush keys.
        /// <summary>
        /// The exterior border of any given UIElement having this coloscheme applied.
        /// </summary>
        public static string UIElementInnerBorderColorBrush = "UIElementInnerBorderColorBrushKey";
        /// <summary>
        /// The exterior border of any given UIElement having this coloscheme applied.
        /// </summary>
        public static string UIElementOuterBorderColorBrush = "UIElementOuterBorderColorBrushKey";
        /// <summary>
        /// The key name of the mouse hover background brush.
        /// Displayed when the ui element is flaged as selected.
        /// </summary>
        public static string UIElementSelectedBackgroundBrush = "UIElementSelectedBackgroundBrushKey";
        /// <summary>
        /// The key name of the mouse hover topsheen brush.
        /// Displayed when the ui element is selected.
        /// </summary>
        public static string UIElementSelectedTopSheenBrush = "UIElementSelectedTopSheenBrushKey";
        /// <summary>
        /// Display whene the mouse is hovering a selctable UIElement in the GUI.
        /// </summary>
        public static string UIElementMouseHoverBackgroundBrush = "UIElementMouseHoverBackgroundBrushKey";
        /// <summary>
        /// 
        /// </summary>
        public static string UIElementSelectedForegroundBrush = "UIElementSelectedForegroundBrushKey";
        #endregion
    }
}
