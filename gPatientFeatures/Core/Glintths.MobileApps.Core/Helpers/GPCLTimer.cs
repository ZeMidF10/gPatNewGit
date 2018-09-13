using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Glintths.MobileApps.Core.Helpers
{
	public enum GPCLTimerStatus
	{
		Stopped,
		Started
	}

	public class GPCLTimer
	{
		public delegate void ElapsedTimetHandler (object sender);

		public delegate bool IsAllowedToRun ();

		public event ElapsedTimetHandler OnElapsedTime;

		private int _timeInterval { get; set; }

		private Task _task;

		private CancellationTokenSource cancelTokenSource;
		private IsAllowedToRun _checkMethod;
		private string _timerName;

		public GPCLTimer (string timerName, int timeInterval, IsAllowedToRun checkMethod)
		{
			_checkMethod = checkMethod;
			_timeInterval = timeInterval;
			_timerName = timerName;
			cancelTokenSource = new CancellationTokenSource ();
			Status = GPCLTimerStatus.Stopped;
		}

		public GPCLTimerStatus Status { get; private set; }

		public void Start ()
		{
			if (Status == GPCLTimerStatus.Started) {
				return;
			}
			Debug.WriteLine (_timerName + " Timer Start");
			if (!_checkMethod.Invoke ()) {
				Debug.WriteLine (_timerName + " Timer not allowed to run");
				return;
			}

			Status = GPCLTimerStatus.Started;
			Debug.WriteLine (_timerName + " Timer allowed to run");

			if (_task != default(Task)) {
				if (cancelTokenSource.Token.CanBeCanceled) {
					cancelTokenSource.Cancel ();
					cancelTokenSource = new CancellationTokenSource ();
				}
			}
			_task = Task.Factory.StartNew (async () => {

				await Task.Delay (_timeInterval, cancelTokenSource.Token);
				if (OnElapsedTime != null) {
					OnElapsedTime (this);
				}
				Status = GPCLTimerStatus.Stopped;
				Debug.WriteLine (_timerName + " Elapsed Time");
			}, cancelTokenSource.Token);
		}

		public void Stop ()
		{
			if (_task != null) {
				if (cancelTokenSource.Token.CanBeCanceled) {
					cancelTokenSource.Cancel ();
				}

			}
			Status = GPCLTimerStatus.Stopped;
			Debug.WriteLine (_timerName + " Timer Stop");
		}


	}
}
