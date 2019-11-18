using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Nutrify.Droid;
using Nutrify.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(searchRenderer), typeof(searchRendererAndroid))]
namespace Nutrify.Droid
{
    public class searchRendererAndroid : EntryRenderer
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Android.Graphics.Color.White);
                gradientDrawable.SetStroke(0, Android.Graphics.Color.Transparent);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(Control.PaddingLeft, Control.PaddingTop, Control.PaddingRight, ControlUsedForAutomation.PaddingBottom);
            }
        }
    }
}