using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamp.Core.Entities;
using NycCodeCamp.MetroApp.Entities;

namespace NycCodeCamp.MetroApp
{
    public static class GroupCollectionSourceExtensions
    {
        public static IEnumerable<SessionGroup> AsGroups(this IList<Session> sessions)
        {
            return from s in sessions
                   group s by s.Starts into times
                   let first = times.First()
                   orderby first.Starts
                   select new SessionGroup(first.Starts.ToString("t") + " - " + first.Ends.ToString("t"), times);
        }
    }
}
