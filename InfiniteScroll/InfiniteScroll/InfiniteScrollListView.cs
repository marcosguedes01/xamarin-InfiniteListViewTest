using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfiniteScroll
{
    public class InfiniteScrollListView : ListView
    {
        public static readonly BindableProperty LoadCommandProperty =
            BindableProperty.Create<InfiniteScrollListView, ICommand>(bp => bp.LoadCommand, default(ICommand));

        public ICommand LoadCommand
        {
            get { return (ICommand)this.GetValue(LoadCommandProperty); }
            set { this.SetValue(LoadCommandProperty, value); }
        }

        public InfiniteScrollListView()
        {
            this.ItemAppearing += (object sender, ItemVisibilityEventArgs e) =>
            {
                var items = this.ItemsSource as IList;
                if (items != null && e.Item == items[items.Count - 1])
                {
                    if (LoadCommand != null && this.LoadCommand.CanExecute(null))
                    {
                        this.LoadCommand.Execute(null);
                    }
                }
            };
        }
    }
}
