using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using Caliburn.Micro;

namespace UgBoard.Framework.Results
{
    public class TimerResult : IResult
    {
        /// <summary>
        /// The _timer.
        /// </summary>
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerResult"/> class.
        /// </summary>
        /// <param name="timeSpan">
        /// The time span.
        /// </param>
        public TimerResult(TimeSpan timeSpan)
        {
            TimeSpan = timeSpan;
            _timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerResult"/> class.
        /// </summary>
        /// <param name="timeSpan">
        /// The time span.
        /// </param>
        /// <param name="userState">
        /// The user state.
        /// </param>
        public TimerResult(TimeSpan timeSpan, object userState)
        {
            TimeSpan = timeSpan;
            UserState = userState;
            _timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// The completed event.
        /// </summary>
        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        /// <summary>
        /// Gets TimeSpan.
        /// </summary>
        public TimeSpan TimeSpan { get; private set; }

        /// <summary>
        /// Gets UserState.
        /// </summary>
        public object UserState { get; private set; }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public void Execute(ActionExecutionContext context)
        {
            _timer.Interval = TimeSpan;
            _timer.Start();
        }

        /// <summary>
        /// The timer_ tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// Timer empty event args.
        /// </param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            Caliburn.Micro.Execute.OnUIThread(() => Completed(this, new ResultCompletionEventArgs()));
        }
    }
}
