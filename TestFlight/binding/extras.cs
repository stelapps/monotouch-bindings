using System;
using System.Runtime.InteropServices;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.TestFlight
{
	public partial class TestFlight
	{
		static bool isFirstTime = true;
		
		/// <summary>Sets custom options</summary>
		/// <param name="options">Option mask containing the options you want to set. Available 
		/// options are described 
		/// below at Options enum</param>
		public static void SetOptions (Options options, bool bValue = true)
		{
			var optionsDict = new NSMutableDictionary();
			var strValue = bValue ? new NSString("YES") : new NSString("NO");
			
			if ((options & Options.DisableAutoDeviceIdentifying) == 0 && isFirstTime) {
				TestFlight.SetDeviceIdentifier(UIDevice.CurrentDevice.UniqueIdentifier);
				isFirstTime = false;
			}
			
			if ((options & Options.AttachBacktraceToFeedback) != 0) {
				optionsDict.Add (strValue, OptionKeys.AttachBacktraceToFeedback);
			}
			if ((options & Options.DisableInAppUpdates) != 0) {
				optionsDict.Add (strValue, OptionKeys.DisableInAppUpdates);
			}
			if ((options & Options.LogToConsole) != 0) {
				optionsDict.Add (strValue, OptionKeys.LogToSTDERR);
			}
			if ((options & Options.LogToSTDERR) != 0) {
				optionsDict.Add (strValue, OptionKeys.ReinstallCrashHandlers);
			}
			if ((options & Options.SendLogOnlyOnCrash) != 0) {
				optionsDict.Add (strValue, OptionKeys.SendLogOnlyOnCrash);
			}
			
			TestFlight.SetOptionsRaw(optionsDict);
		}
		
		public static void SetOptions (Options active, Options nonActive) 
		{
			TestFlight.SetOptions(active);
			TestFlight.SetOptions(nonActive);
		}
	}
}

