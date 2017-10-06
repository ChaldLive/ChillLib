using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace ChillLib.Converters
{
    
    /// <summary>
    /// 
    /// </summary>
    public class LevelToIndentConverter : IValueConverter  
    {
        #region Private fields
        private const double c_IndentSize = 19.0;
        #endregion
        //
        #region Dependency properties declaration

        #endregion
        //
        #region Static constructor
        /// <summary>
        /// 
        /// </summary>
        static LevelToIndentConverter()
        {
        }
        #endregion
        //
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public LevelToIndentConverter()
        {
        }
        #endregion
        //
        #region DependencyPropety value changed event handlers
        #endregion
        //
        #region Dependency property getters and setters
        #endregion
        //
        #region Private fields getters and setters.
        #endregion
        //
        #region Base overidden methods
        #endregion
        //
        #region Private helper and utility methods
        #endregion
        //
        #region Private event handlers
        #endregion
        //
        #region Abstract interface of this class.
        #endregion
        //
        #region Public methods interface of this class.
        #endregion
        //
        #region IValueConverter  implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Thickness((int)value * c_IndentSize, 0, 0, 0);
        }
        /// <summary>
        /// Throws as not implemented. This method should never be called.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
