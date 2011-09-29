using System.Collections.Generic;
using CodeCamp.Core.Entities;
using Windows.UI.Xaml.Data;

namespace NycCodeCamp.MetroApp.Entities
{
    public class SessionGroup : List<Session>, IGroupInfo
    {
        public SessionGroup(object key, IEnumerable<Session> sessions) 
            : base(sessions)
        {
            Key = key;
        }

        public object Key { get; set; }

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
