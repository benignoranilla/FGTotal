using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using FGTotal.Style;
using FGTotal.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PickerRenderer = Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace FGTotal.Droid
{
    class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Android.Graphics.Color.Transparent);
                Control.SetBackground(gd);
                //Control.SetTextColor(Android.Graphics.Color.White);
            }
        }
    }
}