//
// testflight.cs: API definition for the TestFlight SDK
//
// Authors:
//  Miguel de Icaza (miguel@xamarin.com)
//
// Copyright 2011 Xamarin Inc.
//

using System;
using MonoTouch.Foundation;

namespace MonoTouch.TestFlight {

	[BaseType (typeof (NSObject))]
	public interface TestFlight {
		[Static, Export ("addCustomEnvironmentInformation:forKey:")]
		void AddCustomEnvironmentInformation (string information, string key);

		[Static, Export ("takeOff:")]
		void TakeOff (string teamToken);

		// The values that the dictionary accepts:
		// NSString ("reinstallCrashHandlers") -> NSNumber.Boolean, set to true to reinstall the crash
		// handlers, in case some other library does
		[Internal]
		[Static, Export ("setOptions:")]
		void SetOptionsRaw (NSDictionary options);

		[Static, Export ("passCheckpoint:")]
		void PassCheckpoint (string checkpointName);

		[Static, Export ("openFeedbackView")]
		void OpenFeedbackView ();

		[Static, Export ("submitFeedback:")]
		void SubmitFeedback (string feedback);

		[Static, Export ("setDeviceIdentifier:")]
		void SetDeviceIdentifier (string deviceIdentifer);
	}

	[Static]
	public interface OptionKeys {
		/// <summary>
		/// Defaults to @NO. Setting to @YES attaches the current backtrace, with symbols, to the 
		/// feedback.
		/// </summary>
		[Field ("TFOptionAttachBacktraceToFeedback", "__Internal")]
		NSString AttachBacktraceToFeedback { get; }
		
		/// <summary>
		/// Defaults to @NO. Setting to @YES, disables the in app update screen shown in BETA apps 
		/// when there is a new version available on TestFlight.
		/// </summary>
		[Field ("TFOptionDisableInAppUpdates", "__Internal")]
		NSString DisableInAppUpdates { get; }
		
		/// <summary>
		/// Defaults to @YES. Prints remote logs to Apple System Log.
		/// </summary>
		[Field ("TFOptionLogToConsole", "__Internal")]
		NSString LogToConsole { get; }
		
		/// <summary>
		/// Defaults to @YES. Sends remote logs to STDERR when debugger is attached.
		/// </summary>
		[Field ("TFOptionLogToSTDERR", "__Internal")]
		NSString LogToSTDERR { get; }
		
		/// <summary>
		/// If set to @YES: Reinstalls crash handlers, to be used if a third party library installs 
		/// crash handlers overtop of the TestFlight Crash Handlers.
		/// </summary>
		[Field ("TFOptionReinstallCrashHandlers", "__Internal")]
		NSString ReinstallCrashHandlers { get; }
		
		/// <summary>
		/// Defaults to @NO. Setting to @YES stops remote logs from being sent when sessions end. 
		/// They would only be sent in the event of a crash.
		/// </summary>
		[Field ("TFOptionSendLogOnlyOnCrash", "__Internal")]
		NSString SendLogOnlyOnCrash { get; }
	}
}