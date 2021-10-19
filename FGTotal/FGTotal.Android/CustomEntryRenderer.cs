using Android.App;
using Android.Content;
using FGTotal;
using FGTotal.Droid;
using Xamarin.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FGTotal.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}