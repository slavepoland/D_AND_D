using System;
using System.Windows;

namespace D_AND_D
{
    public static class ExtensionMethods
    {
        private static readonly Action EmptyDelegate = delegate () { };
        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(EmptyDelegate, System.Windows.Threading.DispatcherPriority.Background);
        }
    }
}
