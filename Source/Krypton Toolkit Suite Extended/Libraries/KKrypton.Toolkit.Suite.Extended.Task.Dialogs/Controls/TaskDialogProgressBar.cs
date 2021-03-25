﻿using System;

using TaskDialogFlags = Krypton.Toolkit.Suite.Extended.Task.Dialogs.TaskDialogNativeMethods.TASKDIALOG_FLAGS;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    // <summary>
    /// 
    /// </summary>
    public sealed class TaskDialogProgressBar : TaskDialogControl
    {
        private TaskDialogProgressBarState _state;

        private int _minimum = 0;

        private int _maximum = 100;

        private int _value;

        private int _marqueeSpeed;

        /// <summary>
        /// 
        /// </summary>
        public TaskDialogProgressBar()
            : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public TaskDialogProgressBar(TaskDialogProgressBarState state)
            : this()
        {
            // Use the setter which will validate the value.
            State = state;
        }

        /// <summary>
        /// Gets or sets the state of the progress bar.
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown. However, it is
        /// not possible to change the state from
        /// <see cref="TaskDialogProgressBarState.None"/> to any other state,
        /// and vice versa.
        /// </remarks>
        public TaskDialogProgressBarState State
        {
            get => _state;

            set
            {
                DenyIfBoundAndNotCreated();
                DenyIfWaitingForInitialization();

                if (BoundPage != null && value == TaskDialogProgressBarState.None)
                    throw new InvalidOperationException(
                            "Cannot remove the progress bar while the task dialog is shown.");

                //// TODO: Verify the enum value is actually valid

                TaskDialogProgressBarState previousState = _state;
                _state = value;
                try
                {
                    if (BoundPage != null)
                    {
                        TaskDialog taskDialog = BoundPage.BoundTaskDialog;

                        // Check if we need to switch between a marquee and a
                        // non-marquee bar.
                        bool newStateIsMarquee = ProgressBarStateIsMarquee(_state);
                        bool switchMode = ProgressBarStateIsMarquee(previousState) != newStateIsMarquee;
                        if (switchMode)
                        {
                            // When switching from non-marquee to marquee mode, we
                            // first need to set the state to "Normal"; otherwise
                            // the marquee will not show.
                            if (newStateIsMarquee && previousState != TaskDialogProgressBarState.Normal)
                                taskDialog.SetProgressBarState(TaskDialogNativeMethods.PBST_NORMAL);

                            taskDialog.SwitchProgressBarMode(newStateIsMarquee);
                        }

                        // Update the properties.
                        if (newStateIsMarquee)
                        {
                            taskDialog.SetProgressBarMarquee(
                                    _state == TaskDialogProgressBarState.Marquee,
                                    _marqueeSpeed);
                        }
                        else
                        {
                            taskDialog.SetProgressBarState(GetNativeProgressBarState(_state));

                            if (switchMode)
                            {
                                // Also need to set the other properties after switching
                                // the mode.
                                taskDialog.SetProgressBarRange(
                                        _minimum,
                                        _maximum);
                                taskDialog.SetProgressBarPosition(
                                        _value);

                                // We need to set the position a second time to work
                                // reliably if the state is not "Normal".
                                // See this comment in the TaskDialog implementation
                                // of the Windows API Code Pack 1.1:
                                // "Due to a bug that wasn't fixed in time for RTM of
                                // Vista, second SendMessage is required if the state
                                // is non-Normal."
                                // Apparently, this bug is still present in Win10 V1803.
                                if (_state != TaskDialogProgressBarState.Normal)
                                    taskDialog.SetProgressBarPosition(
                                            _value);
                            }
                        }
                    }
                }
                catch
                {
                    // Revert to the previous state. This could happen if the dialog's
                    // DenyIfDialogNotShownOrWaitingForNavigatedEvent() (called by
                    // one of the Set...() methods) throws.
                    _state = previousState;
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown.
        /// </remarks>
        public int Minimum
        {
            get => _minimum;

            set
            {
                if (value < 0 || value > ushort.MaxValue)
                    throw new ArgumentOutOfRangeException(nameof(value));

                DenyIfBoundAndNotCreated();
                DenyIfWaitingForInitialization();

                // We only update the TaskDialog if the current state is a
                // non-marquee progress bar.
                if (BoundPage != null && !ProgressBarStateIsMarquee(_state))
                {
                    BoundPage.BoundTaskDialog.SetProgressBarRange(
                            value,
                            _maximum);
                }

                _minimum = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown.
        /// </remarks>
        public int Maximum
        {
            get => _maximum;

            set
            {
                if (value < 0 || value > ushort.MaxValue)
                    throw new ArgumentOutOfRangeException(nameof(value));

                DenyIfBoundAndNotCreated();
                DenyIfWaitingForInitialization();

                // We only update the TaskDialog if the current state is a
                // non-marquee progress bar.
                if (BoundPage != null && !ProgressBarStateIsMarquee(_state))
                {
                    BoundPage.BoundTaskDialog.SetProgressBarRange(
                            _minimum,
                            value);
                }

                _maximum = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown.
        /// </remarks>
        public int Value
        {
            get => _value;

            set
            {
                if (value < 0 || value > ushort.MaxValue)
                    throw new ArgumentOutOfRangeException(nameof(value));

                DenyIfBoundAndNotCreated();
                DenyIfWaitingForInitialization();

                // We only update the TaskDialog if the current state is a
                // non-marquee progress bar.
                if (BoundPage != null && !ProgressBarStateIsMarquee(_state))
                {
                    BoundPage.BoundTaskDialog.SetProgressBarPosition(
                            value);
                }

                _value = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// This property can be set while the dialog is shown.
        /// </remarks>
        public int MarqueeSpeed
        {
            get => _marqueeSpeed;

            set
            {
                DenyIfBoundAndNotCreated();

                int previousMarqueeSpeed = _marqueeSpeed;
                _marqueeSpeed = value;
                try
                {
                    // We only update the TaskDialog if the current state is a
                    // marquee progress bar.
                    if (BoundPage != null && ProgressBarStateIsMarquee(_state))
                        State = _state;
                }
                catch
                {
                    _marqueeSpeed = previousMarqueeSpeed;
                    throw;
                }
            }
        }

        internal override bool IsCreatable
        {
            get => base.IsCreatable && _state != TaskDialogProgressBarState.None;
        }

        private static bool ProgressBarStateIsMarquee(
                TaskDialogProgressBarState state)
        {
            return state == TaskDialogProgressBarState.Marquee ||
                    state == TaskDialogProgressBarState.MarqueePaused;
        }

        private static int GetNativeProgressBarState(
                TaskDialogProgressBarState state)
        {
            switch (state)
            {
                case TaskDialogProgressBarState.Normal:
                    return TaskDialogNativeMethods.PBST_NORMAL;
                case TaskDialogProgressBarState.Paused:
                    return TaskDialogNativeMethods.PBST_PAUSED;
                case TaskDialogProgressBarState.Error:
                    return TaskDialogNativeMethods.PBST_ERROR;
                default:
                    throw new ArgumentException();
            }
        }

        private protected override TaskDialogFlags BindCore()
        {
            TaskDialogFlags flags = base.BindCore();

            if (ProgressBarStateIsMarquee(_state))
                flags |= TaskDialogFlags.TDF_SHOW_MARQUEE_PROGRESS_BAR;
            else
                flags |= TaskDialogFlags.TDF_SHOW_PROGRESS_BAR;

            return flags;
        }

        private protected override void ApplyInitializationCore()
        {
            if (_state == TaskDialogProgressBarState.Marquee)
            {
                State = _state;
            }
            else if (_state != TaskDialogProgressBarState.MarqueePaused)
            {
                State = _state;
                BoundPage.BoundTaskDialog.SetProgressBarRange(
                        _minimum,
                        _maximum);
                BoundPage.BoundTaskDialog.SetProgressBarPosition(
                        _value);

                // See comment in property "State" for why we need to set
                // the position it twice.
                if (_state != TaskDialogProgressBarState.Normal)
                    BoundPage.BoundTaskDialog.SetProgressBarPosition(
                            _value);
            }
        }
    }
}