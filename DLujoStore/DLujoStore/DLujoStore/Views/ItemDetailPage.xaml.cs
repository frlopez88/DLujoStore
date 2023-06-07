using DLujoStore.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DLujoStore.Views
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