using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SotringFriends_UI
{
    public static class CommonEventsWrapper
    {
        public static void ClearEvents(Control i_Control)
        {
            const string k_EventClick = "EventClick", k_Events = "Events";

            FieldInfo fieldInfo = typeof(Control).GetField(k_EventClick,
            BindingFlags.Static | BindingFlags.NonPublic);
            object obj = fieldInfo.GetValue(i_Control);
            PropertyInfo property = i_Control.GetType().GetProperty(k_Events,
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)property.GetValue(i_Control, null);
            list.RemoveHandler(obj, list[obj]);
        }
    }
}
