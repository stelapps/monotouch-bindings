using System;

namespace MonoTouch.TestFlight
{
	[Flags]
	public enum Options
	{
		AttachBacktraceToFeedback = 0x1,
		DisableInAppUpdates = 0x2,
		LogToConsole = 0x4,
		LogToSTDERR = 0x8,
		ReinstallCrashHandlers = 0x10,
		SendLogOnlyOnCrash = 0x20,
		DisableAutoDeviceIdentifying = 0x40
	}
}

