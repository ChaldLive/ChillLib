using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
//
using ChillLib.Definitions;
using System.ComponentModel;
//
namespace ChillLib.Controls
{
    
    /// <summary>
    /// The abstract base class for the new fullrow selction treeviewitem.
    /// </summary>
    public class CLTreeViewItem : TreeViewItem
    {
        #region Private fields
        /// <summary>
        /// Private field holding the calculated value of the amount of indention given a certain level.
        /// This will of cource work in conjunction with the Converter.
        /// </summary>
        private int m_indentLevel;
        private Border m_backgroundMouseOverStuff;
        #endregion
        //
        #region Dependency properties declaration

        /// <summary>
        /// Property reflecting the mouse hover state. This is  a dependencyProperty.
        /// </summary>
        public static readonly DependencyProperty MouseHoverStateProperty;
        internal static readonly DependencyPropertyKey MouseHoverStatePropertyKey;
        #endregion
        //
        #region Static constructor
        /// <summary>
        /// 
        /// </summary>
        static CLTreeViewItem()
        {
            /* Readonly registration */
            MouseHoverStatePropertyKey = DependencyProperty.RegisterReadOnly("MouseHoverState", typeof(MouseHoverStates), typeof(CLTreeViewItem), new PropertyMetadata(MouseHoverStates.MouseOut));
            MouseHoverStateProperty = MouseHoverStatePropertyKey.DependencyProperty;
        }
        #endregion
        //
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public CLTreeViewItem()
        {
            DefaultStyleKey = typeof(CLTreeViewItem);
        }
        #endregion
        //
        #region DependencyPropety value changed event handlers
        #endregion
        //
        #region Dependency property getters and setters
        /// <summary>
        /// Property describing the mouse hover state.
        /// </summary>
        [Bindable(true)]
        public MouseHoverStates MouseHoverState
        {
            get
            {
               return (MouseHoverStates)GetValue(MouseHoverStateProperty);
            }
        }
        #endregion
        //
        #region Private fields getters and setters.
        /// <summary>
        /// Property retrieving the indention level of the current treeviewitem at any level.
        /// </summary>
        public int IndentLevel
        {
            get
            {
                if (m_indentLevel == -1)
                {
                    CLTreeViewItem parent = ItemsControl.ItemsControlFromItemContainer(this) as CLTreeViewItem;
                    m_indentLevel = (parent != null) ? parent.IndentLevel + 1 : 0;
                }
                return m_indentLevel;
            }
        }

        #endregion
        //
        #region Base overidden methods
        /// <summary>
        /// Template initialisation goes here.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            m_backgroundMouseOverStuff = GetTemplateChild("PART_Background") as Border;
            if (m_backgroundMouseOverStuff != null)
            {
                TearDownMouseStatesProperty();
                WireUpMouseStatesProperty();
            }
            else
            {
                TearDownMouseStatesProperty();
            }
        }
        /// <summary>
        /// Standard overrides for type conformance when templating the header via the header template.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CLTreeViewItem();
        }
        /// <summary>
        /// Standard overrides for type conformance when templating the header via the header template.
        /// </summary>
        /// <param name="item">
        /// </param>
        /// <returns>
        /// True if this treeviewitem is of type CLTreeViewItem else false.
        /// </returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is CLTreeViewItem;
        }

        
        #endregion
        //
        #region Private helper and utility methods
        /// <summary>
        /// 
        /// </summary>
        private void WireUpMouseStatesProperty()
        {
            if (m_backgroundMouseOverStuff != null)
            {
                m_backgroundMouseOverStuff.MouseEnter += new System.Windows.Input.MouseEventHandler(BackgroundMouseOverStuffMouseEnterEvent);
                m_backgroundMouseOverStuff.MouseLeave += new System.Windows.Input.MouseEventHandler(BackgroundMouseOverStuffMouseLeaveEvent);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void TearDownMouseStatesProperty()
        {
            if (m_backgroundMouseOverStuff != null)
            {
                m_backgroundMouseOverStuff.MouseEnter -= new System.Windows.Input.MouseEventHandler(BackgroundMouseOverStuffMouseEnterEvent);
                m_backgroundMouseOverStuff.MouseLeave -= new System.Windows.Input.MouseEventHandler(BackgroundMouseOverStuffMouseLeaveEvent);
            }
        }
        #endregion
        //
        #region Private event handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundMouseOverStuffMouseLeaveEvent(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SetValue(MouseHoverStatePropertyKey,MouseHoverStates.MouseOut);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackgroundMouseOverStuffMouseEnterEvent(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SetValue(MouseHoverStatePropertyKey, MouseHoverStates.MouserOver);
        }
        #endregion
        //
        #region Abstract interface of this class.
        #endregion
        //
        #region Public methods interface of this class.
        #endregion
    }
      
                
}
