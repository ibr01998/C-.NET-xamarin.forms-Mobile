using Idea.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Idea.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}