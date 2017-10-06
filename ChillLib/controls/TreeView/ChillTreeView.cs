using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Reflection;

namespace ChillLib.Controls
{
    
    /// <summary>
    /// This is the basic of all treeviews in this library. This class serves as the base
    /// abstraction for different treeviews in this library.
    /// </summary>
    public class CLTreeView : System.Windows.Controls.TreeView
    {
        #region Private fields
        /// <summary>
        /// Internanl private helper property info used to suppress the selection 
        /// process in the treeview from continuing when handling multiselection.
        /// </summary>
        private PropertyInfo m_isSelectionChangeActiveProperty;
        #endregion
        //
        #region Dependency properties declaration
        /// <summary>
        /// Enables or disable multiselection in the CLTreeView Control. This is a dependencyproperty.
        /// </summary>
        public static readonly DependencyProperty EnableMultiSelectProperty;
        /// <summary>
        /// The list of items selected when the user interface is in multiselection state. This is a dependencyproperty.
        /// </summary>
        public static readonly DependencyProperty SelectedItemsProperty;
        internal static readonly DependencyPropertyKey SelectedItemsPropertyKey;
        /// <summary>
        /// Internal property used during multiselection scenario in the GUI. This is a depedencyproperty.
        /// </summary>
        internal static readonly DependencyProperty AnchorItemProperty;
        /// <summary>
        /// Propety for handling selection chaneged in the treeview item. Doing it this way enhanced the 
        /// possibility of applying animations and other stuff. This is a dependencyproperty.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty;
        /// <summary>
        /// Property to enable or disable full row selection in the tree view. This is a dependencyproperty.
        /// </summary>
        public static readonly DependencyProperty IsFullRowSelectionEnabledProperty;
        #endregion
        //
        #region Static constructor
        /// <summary>
        /// Static contstuctor initialization of the static members such as dependencyproperties.
        /// </summary>
        static CLTreeView()
        {
            /**/
            SelectedItemsPropertyKey = DependencyProperty.RegisterReadOnly("SelectedItems", typeof(IList), typeof(CLTreeView), new PropertyMetadata(null));
            SelectedItemsProperty = SelectedItemsPropertyKey.DependencyProperty;
            //            
            EnableMultiSelectProperty = DependencyProperty.Register("EnableMultiSelect", typeof(bool), typeof(CLTreeView), new PropertyMetadata(false, new PropertyChangedCallback(EnableMultiSelectPropertyChangedCallback)));
            //
            AnchorItemProperty = DependencyProperty.Register("AnchorItem", typeof(TreeViewItem),typeof(CLTreeView),new PropertyMetadata(null));
            //
            IsSelectedProperty = DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(CLTreeView), new PropertyMetadata(false));
            //
            IsFullRowSelectionEnabledProperty = DependencyProperty.RegisterAttached("IsFullRowSelectionEnabled", typeof(bool), typeof(CLTreeView), new PropertyMetadata(false));
        }
        #endregion
        //
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public CLTreeView()
        {
            ObservableCollection<TreeViewItem> selectedItems = new ObservableCollection<TreeViewItem>();
            selectedItems.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(selectedItems_CollectionChanged);
            SetValue(SelectedItemsPropertyKey, selectedItems);
            m_isSelectionChangeActiveProperty = typeof(TreeView).GetProperty("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        #endregion
        //
        #region DependencyPropety value changed event handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d">
        /// </param>
        /// <param name="e">
        /// </param>
        private static void EnableMultiSelectPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CLTreeView obj = d as CLTreeView;
            if (obj == null)
                return;
            obj.EnableMultiselectChanged((bool)e.NewValue, (bool)e.OldValue);
        }
        #endregion
        //
        #region Dependency property getters and setters
        /// <summary>
        /// Property gets or sets the IsFullRowSelectionEnabled value.
        /// </summary>
        [Bindable(true)]
        public bool IsFullRowSelectionEnabled
        {
            get 
            { 
                return (bool)GetValue(IsFullRowSelectionEnabledProperty); 
            }
            set 
            { 
                SetValue(IsFullRowSelectionEnabledProperty, value); 
            }
        }
        /// <summary>
        /// Property that sets or gets the anchoritem, when in a multiselection scenario.
        /// That means either the ctrl or the shift buttons are held during selection.
        /// </summary>
        [Bindable(true)]
        public TreeViewItem AnchorItem
        {
            get 
            { 
                return (TreeViewItem)GetValue(AnchorItemProperty); 
            }
            set 
            { 
                SetValue(AnchorItemProperty, value); 
            }
        }
        /// <summary>
        /// Property that gets access to the List of selected items.
        /// </summary>
        [Bindable(true)]
        public IList SelectedItems
        {
            get 
            { 
                return (IList)GetValue(SelectedItemsProperty); 
            }
        }
        /// <summary>
        /// Property that gets or sets the value if multiselection should be supported in this instance.
        /// </summary>
        [Bindable(true)]
        public bool EnableMultiSelect
        {
            get 
            { 
                return (bool)GetValue(EnableMultiSelectProperty); 
            }
            set 
            { 
                SetValue(EnableMultiSelectProperty, value); 
            }
        }
        #endregion
        //
        #region Private fields getters and setters.
        #endregion
        //
        #region Base overidden methods
        /// <summary>
        /// Return the proper type when in the styled scenario.
        /// The header template may be altered from without and to make sure
        /// it is done in the type we want it, we have this method overridden.
        /// </summary>
        /// <returns>
        /// A CLTreeViewItemInstance to wrap whatever new header template added.
        /// </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CLTreeViewItem();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">
        /// </param>
        /// <returns>
        /// </returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is CLTreeViewItem;
        }
        /// <summary>
        /// Utility method doing all the mouse leftbutton down handling 
        /// on individual TreeViewItems.
        /// </summary>
        /// <param name="sender">
        /// The source or origin of the event.
        /// </param>
        /// <param name="e">
        /// Additional event information following the item clicked event.
        /// </param>
        private void HandleItemClicked(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            if (item == null)
                return;
            TreeView tree = (TreeView)sender;

            var mouseButton = e.ChangedButton;
            if (mouseButton != MouseButton.Left)
            {
                if ((mouseButton == MouseButton.Right) && ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) == ModifierKeys.None))
                {
                    if (item.IsSelected)
                    {
                        UpdateAnchorAndActionItem(item);
                        return;
                    }
                    MakeSingleSelection(this, item);
                }
                return;
            }
            if (mouseButton != MouseButton.Left)
            {
                if ((mouseButton == MouseButton.Right) && ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) == ModifierKeys.None))
                {
                    if (item.IsSelected)
                    {
                        UpdateAnchorAndActionItem(item);
                        return;
                    }
                    MakeSingleSelection(this, item);
                }
                return;
            }
            if ((Keyboard.Modifiers & (ModifierKeys.Shift | ModifierKeys.Control)) != (ModifierKeys.Shift | ModifierKeys.Control))
            {
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    MakeToggleSelection(item);
                    return;
                }
                if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                {
                    MakeAnchorSelection(item, true);
                    return;
                }
                MakeSingleSelection(this, item);
                return;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAccessKey(AccessKeyEventArgs e)
        {
            base.OnAccessKey(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e">
        /// </param>
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.A && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                SetSelectedItemChangedMode(true);
                foreach (TreeViewItem item in GetExpandedTreeViewItems(this))
                {
                    if (item != e.Source)
                        MakeToggleSelection(item);
                }
                e.Handled = true;
                SetSelectedItemChangedMode(false);
            }
            else if (e.Key == Key.Space && e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                TreeViewItem item = e.Source as TreeViewItem;
                if (item != null)
                {
                    MakeToggleSelection(item);
                }
            }
            base.OnPreviewKeyDown(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem tviNew = e.NewValue as TreeViewItem;
            TreeViewItem tviOld = e.OldValue as TreeViewItem;
            if ((tviNew != null) && (Mouse.LeftButton == MouseButtonState.Pressed))
            {
                if (!SelectedItems.Contains(tviNew))
                    tviNew.IsSelected = !tviNew.IsSelected;
                e.Handled = true;
            }
            base.OnSelectedItemChanged(e);
        }
        #endregion
        //
        #region Private helper and utility methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bSelectionState">
        /// </param>
        private void SetSelectedItemChangedMode(bool bSelectionState)
        {
            m_isSelectionChangeActiveProperty.SetValue((TreeView)this, bSelectionState, null);        
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void MakeToggleSelection(TreeViewItem item)
        {
            SelectItem(item, !item.IsSelected);
            UpdateAnchorAndActionItem(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        private void EnableMultiselectChanged(bool newValue, bool oldValue)
        {
            if (oldValue)
            {
                RemoveHandler(TreeViewItem.MouseDownEvent, new MouseButtonEventHandler(ItemClicked));

            }
            if (newValue)
            {
                AddHandler(TreeViewItem.MouseDownEvent, new MouseButtonEventHandler(ItemClicked), true);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private TreeViewItem FindTreeViewItem(object obj)
        {
            DependencyObject dpObj = obj as DependencyObject;
            if (dpObj == null)
                return null;
            if (dpObj is TreeViewItem)
                return (TreeViewItem)dpObj;
            return FindTreeViewItem(VisualTreeHelper.GetParent(dpObj));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <returns></returns>
        private IEnumerable<TreeViewItem> GetExpandedTreeViewItems(ItemsControl tree)
        {
            for (int i = 0; i < tree.Items.Count; i++)
            {
                var item = (TreeViewItem)tree.ItemContainerGenerator.ContainerFromIndex(i);
                // If no item then continue down the hierarchy
                if (item == null)
                    continue;
                // Return the first found.
                yield return item;
                // Find the expanded children of this yelded item.
                if (item.IsExpanded)
                    foreach (var subItem in GetExpandedTreeViewItems(item))
                        yield return subItem;
            }
        }
        /// <summary>
        /// Private utility method aiding the process of selection the anchor item during 
        /// multiselection.
        /// </summary>
        /// <param name="actionItem">
        /// The TreeViewItem in action being considdered and anchoritem.
        /// </param>
        /// <param name="clearCurrent">
        /// Boolean parameter making sure we have all the right items selected.
        /// </param>
        private void MakeAnchorSelection(TreeViewItem actionItem, bool clearCurrent)
        {
            if (AnchorItem == null)
            {
                List<TreeViewItem> selectedItems = GetSelectedTreeViewItems();
                if (selectedItems.Count > 0)
                {
                    AnchorItem = selectedItems[selectedItems.Count - 1];
                }
                else
                {
                    AnchorItem = GetExpandedTreeViewItems(this).Skip(3).FirstOrDefault();
                }
                if (AnchorItem == null)
                {
                    return;
                }
            }
            var anchor = AnchorItem;
            IEnumerable<TreeViewItem> items = GetExpandedTreeViewItems(this);
            bool betweenBoundary = false;
            foreach (TreeViewItem item in items)
            {
                bool isBoundary = item == anchor || item == actionItem;
                if (isBoundary)
                {
                    betweenBoundary = !betweenBoundary;
                }
                if (betweenBoundary || isBoundary)
                {
                    SelectItem(item, true);
                }
                else
                {
                    if (clearCurrent)
                        SelectItem(item, false);
                    else
                        break;
                }
            }
        }
        /// <summary>
        /// Utillity method setting the selected value of the current treeViewItem and
        /// adding and remove it from the selected items collection respectively.
        /// </summary>
        /// <param name="item">
        /// The item whoes IsSelected property value defines what is about to happen
        /// to the the current item.
        /// </param>
        /// <param name="itemState">
        /// The value to set to the IsSelected property of the current treeviewitem.
        /// </param>
        private void SelectItem(TreeViewItem item, bool itemState)
        {
            if (item == null)
                return;

            if (SelectedItems != null)
            {
                if (itemState == true)
                {
                    item.IsSelected = itemState;
                    if( !SelectedItems.Contains(item))
                        SelectedItems.Add(item);
                }
                else
                {
                    item.IsSelected = itemState;
                    SelectedItems.Remove(item);
                }
            }
        }
        /// <summary>
        /// Selection Helper and utillity method aiding the process of retrieving the 
        /// TreeViewItems whoes IsSelected property is set to true.
        /// </summary>
        /// <returns>
        /// A list of the TreeViewItems appearing selected in the current treeview instanse.
        /// </returns>
        private List<TreeViewItem> GetSelectedTreeViewItems()
        {
            return GetExpandedTreeViewItems(this).Where(i => i.IsSelected).ToList();
        }
        /// <summary>
        /// Helper and utility method aiding the process of amking sure the single selection 
        /// scenario is working properly, not allowing any other TreeViewItem appearing selected
        /// than the current one.
        /// </summary>
        /// <param name="tree">
        /// The parent control of the current treeviewitem.-
        /// </param>
        /// <param name="item">
        /// The treeViewItem whoes IsSelected Property is to be set to true.
        /// </param>
        private void MakeSingleSelection(System.Windows.Controls.TreeView tree, TreeViewItem item)
        {
            foreach (TreeViewItem selectedItem in GetExpandedTreeViewItems(tree))
            {
                if (selectedItem == null)
                    continue;
                if (selectedItem != item)
                {
                    SelectItem(selectedItem, false);
                }
                else
                {
                    SelectItem(selectedItem, true);
                }
            }
            UpdateAnchorAndActionItem(item);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void UpdateAnchorAndActionItem(TreeViewItem item)
        {
            AnchorItem = item;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void UpDateSelectedItems()
        {
            foreach(TreeViewItem item in SelectedItems)
            {
                item.IsSelected = true;
            }
        }
        #endregion
        //
        #region Private event handlers

        private void ItemClicked(object sender, MouseButtonEventArgs e)
        {
            SetSelectedItemChangedMode(true);
            HandleItemClicked(sender, e);
            SetSelectedItemChangedMode(false);
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
