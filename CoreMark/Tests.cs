using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CoreMark
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void LoginWithNoPassword()
		{
			app.Tap("et_user_name");
			app.Screenshot("Tapped on 'User Name' Text Field");

			app.EnterText("Xamarin");
			app.Screenshot("Entered 'Xamarin' as my username");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap("btn_login");
			app.Screenshot("Tapped 'Log In' Button");
		}

		[Test]
		public void LoginWithNoUserName()
		{
			app.Tap("et_password");
			app.Screenshot("Tapped on 'Passoword' Text Field");

			app.EnterText("Microsoft");
			app.Screenshot("Entered 'Microsoft' as my password");

			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");

			app.Tap("btn_login");
			app.Screenshot("Tapped 'Log In' Button");
		}

		[Test]
		public void SaveSyncPoint()
		{
			app.Tap(x => x.Class("android.widget.TextView").Index(5));
			app.Screenshot("Tap on icon");

			app.Tap(x => x.Marked("Sync Point"));
			app.Screenshot("Tapp on 'Sync Point'");

			app.Tap(x => x.Marked("Save"));
			app.Screenshot("Save my 'Sync Point' settings");
		}



	}
}
