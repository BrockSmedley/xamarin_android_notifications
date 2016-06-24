using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace Notifications {
	[Activity(Label = "Notifications", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity {

		protected override void OnCreate(Bundle bundle) {
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.MyButton);

			button.Click += delegate { 
				// notify user
				notifyMe();				
			};
		}

		private void notifyMe() {
			//create intent to allow notification to bring user to app
			Intent intent = new Intent(this, typeof(MainActivity));

			//create PendingIntent because that's what notifications need
			const int pendingIntentId = 0;
			PendingIntent pendingIntent = PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);//OneShot: only run once


			//create the notification object
			Notification.Builder builder = new Notification.Builder(this);

			//set vibrate pattern
			long[] vibratePattern = { 30, 100, 30, 100 };

			//set the notification info
			builder
				.SetContentTitle("Notification")
				.SetContentText("Here's your notification!")
				.SetSmallIcon(Resource.Drawable.Icon)
				.SetVibrate(vibratePattern)
				.SetStyle(new Notification.BigTextStyle())
				.SetCategory(Notification.CategoryReminder)
				.SetPriority((int)NotificationPriority.High)
				.SetContentIntent(pendingIntent)
				.SetAutoCancel(true);



			//get notification manager
			NotificationManager manager = GetSystemService(Context.NotificationService) as NotificationManager;

			//build notification
			Notification notification = builder.Build();


			//notify user
			const int notificationId = 0;
			manager.Notify(notificationId, notification);
		}
	}
}

