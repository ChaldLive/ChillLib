/*
 * Created by SharpDevelop.
 * User: Carsten
 * Date: 30-03-2010
 * Time: 07:17
 * 
 * This is the base class for many of the controls appearing in this little library.
 * The class will esentially act as a button, given the freedom to the user interface
 * programmer, that he/she can decide the behevo
 */
using System;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Collections.Generic;

namespace ChillLib.Controls
{
	/// <summary>
	/// Chill Lib Button chrome for decorating
	/// controls that should appear as a button to the 
	/// end user.
	/// </summary>
	public class CLButton : Button
	{
		#region Private fields
		#endregion
		//
		#region Dependency Properties
		/// <summary>
		/// This is a property aiding the process of how and when 
		/// to render the mouse over behaviour this is a dependency property. 
		/// </summary>
		public static readonly DependencyProperty RenderMouseOverProperty;
		/// <summary>
		/// Property aiding the behaviour of when and how to render the button chrome as pressed.
		/// This is a dependency property.
		/// </summary>
		public static readonly DependencyProperty RenderMouseLeftButtonDownProperty;
		/// <summary>
		/// Property aiding the process of keeping track of when and how
		/// to render the chrome in default mode. This is a depencyproperty.
		/// </summary>
		public static readonly DependencyProperty RenderDefaultProperty;
		/// <summary>
		/// Property providing the value of the innerborder color.
		/// </summary>
		public static readonly DependencyProperty InnerBorderBrushProperty;
		/// <summary>
		/// Property providing the value of the innerborder color.
		/// </summary>
		public static readonly DependencyProperty OuterBorderBrushProperty;
		/// <summary>
		/// The border corner radius property of this class.
		/// </summary>
		public static readonly DependencyProperty CornerRadiusProperty;
		/// <summary>
		/// The thickness structure of the outer border of the button chrome. This is a dependency property.
		/// </summary>
		public static readonly DependencyProperty OuterBorderThicknessProperty;
		/// <summary>
		/// The inner border thickness structure of the buttonchrome. This is a dependencyproperty.
		/// </summary>
		public static readonly DependencyProperty InnerBorderThicknessProperty;
        /// <summary>
        /// This is the background brush of the button chrome. This is a dependency property.
        /// </summary>
        public static readonly DependencyProperty BackgroundBrushProperty;
        /// <summary>
        /// This is the top sheen of the buttonchrome. This is a dependency property.
        /// </summary>
        public static readonly DependencyProperty TopSheenBrushProperty;
		
		#endregion
		//
		#region Static Constructor
		/// <summary>
		/// 
		/// </summary>
		static CLButton()
		{
			#region standard dependency property registration	
			//			
			RenderMouseOverProperty = DependencyProperty.Register("RenderMouseOver", typeof(bool),typeof(CLButton),new PropertyMetadata(false));
			//
			RenderMouseLeftButtonDownProperty = DependencyProperty.Register("RenderMouseLeftButtonDown", typeof(bool),typeof(CLButton),new PropertyMetadata(false));
			//
			RenderDefaultProperty = DependencyProperty.Register("RenderDefault", typeof(bool),typeof(CLButton),new PropertyMetadata(false));
			//
            BackgroundBrushProperty = DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(CLButton), new PropertyMetadata(null));
            //
            TopSheenBrushProperty = DependencyProperty.Register("TopSheenBrush", typeof(Brush), typeof(CLButton), new PropertyMetadata(null));
            //
            InnerBorderBrushProperty = DependencyProperty.Register("InnerBorderBrush", typeof(Brush),typeof(CLButton),new PropertyMetadata(null));
			//
			OuterBorderBrushProperty = DependencyProperty.Register("OuterBorderBrush", typeof(Brush),typeof(CLButton),new PropertyMetadata(null));
			//
			CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius),typeof(CLButton),new PropertyMetadata(new CornerRadius(0d)));
			//
			OuterBorderThicknessProperty = DependencyProperty.Register("OuterBorderThickness", typeof(Thickness),typeof(CLButton),new PropertyMetadata(new Thickness(1,1,1,1)));
			//
			InnerBorderThicknessProperty = DependencyProperty.Register("InnerBorderThickness", typeof(Thickness),typeof(CLButton),new PropertyMetadata(new Thickness(1,1,1,1)));
            //
        
			#endregion
			//
			#region Readonly dependency property regisration
			#endregion
		}
		#endregion
		//
		#region Public constructor
		/// <summary>
		/// 
		/// </summary>
		public CLButton()
		{
            DefaultStyleKey= typeof(CLButton);
        }
		#endregion
		//
		#region Dependency Property value changed even handlers.
		#endregion
		//
		#region Dependency Properties Getters and setters
        /// <summary>
        /// Property to get or set the transparent overlay of the Topsheen of 
        /// the buttonchrome.
        /// </summary>
        [Bindable(true)]
        public Brush TopSheenBrush
        {
            get
            {
                return (Brush)GetValue(TopSheenBrushProperty);
            }
            set
            {
                SetValue(TopSheenBrushProperty, value);
            }
        }
        /// <summary>
        /// Property to set or get the background brush of the buttonchrome.
        /// </summary>
        [Bindable(true)]
        public Brush BackgroundBrush
        {
            get
            {
                return (Brush)GetValue(BackgroundBrushProperty);
            }
            set
            {
                SetValue(BackgroundBrushProperty, value);
            }
        }

        /// <summary>
		/// The render default property of this class.
		/// This property is to control the default render state
		/// of the ButtonChrome.
		/// </summary>
		[Bindable(true)]
		public bool RenderDefault
		{
			get
			{
				return (bool)GetValue(RenderDefaultProperty);
			}
			set
			{
				SetValue(RenderDefaultProperty, value);
			}
		}
		/// <summary>
		/// The RenderMouseLeftButtonDown of this class.
		/// This property is here to keep track of the
		/// Pressed state of the ButtonChrome.
		/// </summary>
		[Bindable(true)]
		public bool RenderMouseLeftButtonDown
		{
			get
			{
				return (bool)GetValue(RenderMouseLeftButtonDownProperty);
			}
			set
			{
				SetValue(RenderMouseLeftButtonDownProperty, value);
			}
		}
		/// <summary>
		/// The RenderMouseOver of this class.
		/// This property is here to aid controling when
		/// the mouse is hovering the ButtoChrome.
		/// </summary>
		[Bindable(true)]
		public bool RenderMouseOver
		{
			get
			{
				return (bool)GetValue(RenderMouseOverProperty);
			}
			set
			{
				SetValue(RenderMouseOverProperty, value);
			}
		}
		/// <summary>
		/// The inner border brush of this class.
		/// This is the border brush, which changes its
		/// colour when the mouse is hovering the button chrome.
		/// </summary>
		[Bindable(true)]
		public Brush InnerBorderBrush
		{
			get
			{
				return (Brush)GetValue(InnerBorderBrushProperty);
			}
			set
			{
				SetValue(InnerBorderBrushProperty, value);
			}
		}
		/// <summary>
		/// The outer border brush of this class.
		/// This is the stable border brush totally 
		/// encapsulating the control.
		/// </summary>
		[Bindable(true)]
		public Brush OuterBorderBrush
		{
			get
			{
				return (Brush)GetValue(OuterBorderBrushProperty);
			}
			set
			{
				SetValue(OuterBorderBrushProperty, value);
			}
		}
		/// <summary>
		/// This is the cornor radius of this control.
		/// It applies to both the inner and the outer border.
		/// </summary>
		[Bindable(true)]
		public CornerRadius CornerRadius 
		{
			get
			{
				return (CornerRadius)GetValue(CornerRadiusProperty);
			}
			set
			{
				SetValue(CornerRadiusProperty, value);
			}
		}
		/// <summary>
		/// The with of the outer border.
		/// </summary>
		[Bindable(true)]
		public Thickness OuterBorderThickness
		{
			get
			{
				return (Thickness)GetValue(OuterBorderThicknessProperty);
			}
			set
			{
				SetValue(OuterBorderThicknessProperty, value);
			}
		}
		/// <summary>
		/// The with of the inner border.
		/// </summary>
		[Bindable(true)]
		public Thickness InnerBorderThickness
		{
			get
			{
				return (Thickness)GetValue(InnerBorderThicknessProperty);
			}
			set
			{
				SetValue(InnerBorderThicknessProperty, value);
			}
		}

		#endregion
		//
		#region Private fields getters and setters
		#endregion
		//
		#region Base overridden methods
        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
		#endregion
		//
		#region Public interface of this class
		#endregion
		//
		#region Private helpers and stuff
		#endregion
		//
		#region Private event handlers
		#endregion
	}
}
