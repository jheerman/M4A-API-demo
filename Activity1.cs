using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;

namespace androidApiDemo
{
	[Activity (Label = "androidApiDemo", MainLauncher = true)]
	public class Activity1 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var viewContainer = new RelativeLayout(this);
			var layoutParams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.FillParent, RelativeLayout.LayoutParams.FillParent);
			AddContentView (viewContainer, layoutParams);

			var btn = new Button(this) { Text = "Centered" };
			btn.Click += (s, args) => {
				var builder = new AlertDialog.Builder(this); 
				builder.SetTitle ("Test");
				builder.SetIcon (Resource.Drawable.Icon);
				builder.SetMessage ("Click a button");
				builder.SetPositiveButton ("Yes", (sender, e) => { 
					Toast.MakeText (this, "You click positive button", ToastLength.Short).Show ();
				});
				builder.SetNegativeButton ("No", (sender, e) => { 
					Toast.MakeText (this, "You clicked negative button", ToastLength.Short).Show ();
				});
				builder.SetNeutralButton ("Maybe", (sender, e) => { 
					Toast.MakeText(this, "You clicked neutral button", ToastLength.Short).Show ();
				});
				var dialog = builder.Create ();
				dialog.Show ();
			};
			var btnParams = new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WrapContent, RelativeLayout.LayoutParams.WrapContent);
			btnParams.AddRule (LayoutRules.CenterInParent);
			viewContainer.AddView (btn, btnParams);

			var spinMeUp = FindViewById<Spinner>(Resource.Id.spinMeUp);
			var items = new string[] { "Up", "Down", "Left", "Right", "B", "A", "Select", "Start" };
			var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, items);
			spinMeUp.Adapter = adapter;
			spinMeUp.Focusable = true;
			spinMeUp.FocusableInTouchMode = true;
			spinMeUp.RequestFocus (FocusSearchDirection.Up);

			var editText = FindViewById<EditText>(Resource.Id.search);
			editText.EditorAction += (object sender, TextView.EditorActionEventArgs e) => {
				if (e.ActionId == ImeAction.Send) {
					Toast.MakeText (this, "You pressed Send", ToastLength.Short).Show();
				}
				return;
			};
		}
	}
}


