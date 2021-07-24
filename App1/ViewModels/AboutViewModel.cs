using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "主页";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.bilibili.com/h5/mall/home?navhide=1"));
            OpenAuthorCommand = new Command(async () => await Browser.OpenAsync("https://space.bilibili.com/4338056/dynamic"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenAuthorCommand { get; }
    }
}