using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using ValueChangedEventArgs = SegmentedControl.FormsPlugin.Abstractions.ValueChangedEventArgs;

namespace Quadrobit.Views
{
    public partial class InternalPage : ContentPage
    {
        public InternalPage()
        {
            InitializeComponent();
        }

        private async void addEntryBtn_OnClicked(object sender, EventArgs e)
        {
            await Task.Delay(100);

            IList list = DataEntriesList.ItemsSource as IList;

            if (list == null)
            {
                return;
            }

            DataEntriesList.ScrollTo(list[list.Count - 1], ScrollToPosition.MakeVisible, true);
        }

        private async void removeEntryBtn_OnClicked(object sender, EventArgs e)
        {
            await Task.Delay(100);

            IList list = DataEntriesList.ItemsSource as IList;

            if (list == null || list.Count == 0)
            {
                return;
            }

            DataEntriesList.ScrollTo(list[0], ScrollToPosition.MakeVisible, true);
        }
    }
}
