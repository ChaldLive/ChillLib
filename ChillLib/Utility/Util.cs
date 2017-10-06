using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ChillLib
{
    public static class Util
    {
        public static class MouseInput
        {
            public static MouseButton MouseButton()
            {
                MouseButton result = System.Windows.Input.MouseButton.Left;
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                    result = System.Windows.Input.MouseButton.Left;
                else if( Mouse.MiddleButton == MouseButtonState.Pressed)
                    result = System.Windows.Input.MouseButton.Middle;
                else if( Mouse.RightButton == MouseButtonState.Pressed)
                    result = System.Windows.Input.MouseButton.Right;
                return result;
            }
        }
    }
}
