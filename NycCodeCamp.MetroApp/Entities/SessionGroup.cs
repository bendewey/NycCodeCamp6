using System.Collections.Generic;
using System.Linq;
using CodeCamp.Core.Entities;
using Windows.UI.Xaml.Data;

namespace NycCodeCamp.MetroApp.Entities
{
    public class SessionGroup : List<Session>, IGroupInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public SessionGroup(IEnumerable<Session> sessions) 
            : base(sessions)
        {
            Title = "0:00 - 0:00";
            var first = sessions.FirstOrDefault();
            if (first != null)
            {
                Title = first.Starts.ToString("t") + " - " + first.Ends.ToString("t");
            }
        }

        public object Key { get { return this; } }

        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                if (this._title != value)
                {
                    this._title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}
