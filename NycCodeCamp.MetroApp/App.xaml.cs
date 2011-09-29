using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using CodeCamp.Core.DataAccess;
using CodeCamp.Core.Messaging;
using CodeCamp.Core.Messaging.Messages;

namespace NycCodeCamp.MetroApp
{
    partial class App
    {
        private static CodeCampService _service;
        private static bool _serviceInitialized;
        public static CodeCampService CodeCampService
        {
            get
            {
                if (_service == null)
                {
                    _service = new CodeCampService("http://codecamps.gregshackles.com/v1", "nyccodecamp6");
                    _serviceInitialized = true;
                }

                return _service;
            }
        }

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            ShowGroupedCollection();
            Window.Current.Activate();
        }

        public static void ShowGroupedCollection()
        {
            var page = new GroupedCollectionPage();
            if (!_serviceInitialized)
            {
                page.IsLoading = true;
                MessageHub.Instance.Subscribe<FinishedLoadingScheduleFromStorageMessage>(msg =>
                {
                    page.Groups = CodeCampService.Repository.GetSessions().AsGroups();
                    page.IsLoading = false;
                });
                MessageHub.Instance.Subscribe<FinishedUpdatingScheduleMessage>(msg =>
                {
                    page.Groups = CodeCampService.Repository.GetSessions().AsGroups();
                    page.IsLoading = false;
                });
            }
            page.Groups = CodeCampService.Repository.GetSessions().AsGroups();
            Window.Current.Content = page;
        }

        public static void ShowDetail(object item)
        {
            var groups = CodeCampService.Repository.GetSessions().AsGroups();

            var page = new DetailPage();
            page.Items = groups.FirstOrDefault(g => g.Contains(item));
            page.Item = item;
            Window.Current.Content = page;
        }
    }
}
