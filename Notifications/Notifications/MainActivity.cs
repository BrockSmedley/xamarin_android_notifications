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
				//notifyMe();

				//create the notification object
				Notification.Builder builder = new Notification.Builder(this);

				//set vibrate pattern
				long[] vibratePattern = { 30,100,30,100 };

				//set the notification info
				builder
					.SetContentTitle("Notification")
					.SetContentText("Here's your notification!")
					.SetSmallIcon(Resource.Drawable.Icon)
					.SetVibrate(vibratePattern);
				

				//get notification manager
				NotificationManager manager = GetSystemService(Context.NotificationService) as NotificationManager;
				
				//build notification
				Notification notification = builder.Build();

				//notify user
				const int notificationId = 0;
				manager.Notify(notificationId, notification);
			};
		}

		private void notifyMe() {
			//create the notification object
			Notification.Builder builder = new Notification.Builder(this);

			//set the notification info
			builder.SetContentTitle("Notification");
			builder.SetContentText("Here's your notification!");


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

