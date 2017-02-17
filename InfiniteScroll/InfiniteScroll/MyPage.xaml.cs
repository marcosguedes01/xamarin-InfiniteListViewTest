using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace InfiniteScroll
{
    public partial class MyPage : ContentPage
    {
        private ViewModel _viewModel = new ViewModel();
        public MyPage()
        {
            InitializeComponent();
            this.BindingContext = this._viewModel;
        }
    }
}
