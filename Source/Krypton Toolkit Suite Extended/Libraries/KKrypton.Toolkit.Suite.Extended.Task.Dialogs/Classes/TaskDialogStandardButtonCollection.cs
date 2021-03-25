﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskDialogStandardButtonCollection : KeyedCollection<TaskDialogResult, TaskDialogStandardButton>
    {
        private TaskDialogPage _boundPage;

        /// <summary>
        /// 
        /// </summary>
        public TaskDialogStandardButtonCollection() : base()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons"></param>
        public static implicit operator TaskDialogStandardButtonCollection(TaskDialogButtons buttons)
        {
            var collection = new TaskDialogStandardButtonCollection();

            // Get the button results for the flags.
            foreach (TaskDialogResult result in GetResultsForButtonFlags(buttons))
                collection.Add(new TaskDialogStandardButton(result));

            return collection;
        }

        internal TaskDialogPage BoundPage
        {
            get => _boundPage;
            set => _boundPage = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buttons"></param>
        internal static IEnumerable<TaskDialogResult> GetResultsForButtonFlags(TaskDialogButtons buttons)
        {
            // Note: The order in which we yield the results is the order in which
            // the task dialog actually displays the buttons.
            if ((buttons & TaskDialogButtons.OK) == TaskDialogButtons.OK)
                yield return TaskDialogResult.OK;
            if ((buttons & TaskDialogButtons.Yes) == TaskDialogButtons.Yes)
                yield return TaskDialogResult.Yes;
            if ((buttons & TaskDialogButtons.No) == TaskDialogButtons.No)
                yield return TaskDialogResult.No;
            if ((buttons & TaskDialogButtons.Abort) == TaskDialogButtons.Abort)
                yield return TaskDialogResult.Abort;
            if ((buttons & TaskDialogButtons.Retry) == TaskDialogButtons.Retry)
                yield return TaskDialogResult.Retry;
            if ((buttons & TaskDialogButtons.Cancel) == TaskDialogButtons.Cancel)
                yield return TaskDialogResult.Cancel;
            if ((buttons & TaskDialogButtons.Ignore) == TaskDialogButtons.Ignore)
                yield return TaskDialogResult.Ignore;
            if ((buttons & TaskDialogButtons.TryAgain) == TaskDialogButtons.TryAgain)
                yield return TaskDialogResult.TryAgain;
            if ((buttons & TaskDialogButtons.Continue) == TaskDialogButtons.Continue)
                yield return TaskDialogResult.Continue;
            if ((buttons & TaskDialogButtons.Close) == TaskDialogButtons.Close)
                yield return TaskDialogResult.Close;
            if ((buttons & TaskDialogButtons.Help) == TaskDialogButtons.Help)
                yield return TaskDialogResult.Help;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public TaskDialogStandardButton Add(TaskDialogResult result)
        {
            var button = new TaskDialogStandardButton(result);
            Add(button);

            return button;
        }

        internal void HandleKeyChange(TaskDialogStandardButton button, TaskDialogResult newKey) => ChangeItemKey(button, newKey);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override TaskDialogResult GetKeyForItem(TaskDialogStandardButton item) => item.Result;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        protected override void SetItem(int index, TaskDialogStandardButton item)
        {
            // Disallow collection modification, so that we don't need to copy it
            // when binding the TaskDialogPage.
            _boundPage?.DenyIfBound();
            DenyIfHasOtherCollection(item);

            TaskDialogStandardButton oldItem = this[index];

            // Call the base method first, as it will throw if we would insert a
            // duplicate item.
            base.SetItem(index, item);

            oldItem.Collection = null;
            item.Collection = this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        protected override void InsertItem(int index, TaskDialogStandardButton item)
        {
            // Disallow collection modification, so that we don't need to copy it
            // when binding the TaskDialogPage.
            _boundPage?.DenyIfBound();
            DenyIfHasOtherCollection(item);

            // Call the base method first, as it will throw if we would insert a
            // duplicate item.
            base.InsertItem(index, item);

            item.Collection = this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        protected override void RemoveItem(int index)
        {
            // Disallow collection modification, so that we don't need to copy it
            // when binding the TaskDialogPage.
            _boundPage?.DenyIfBound();

            TaskDialogStandardButton oldItem = this[index];
            oldItem.Collection = null;
            base.RemoveItem(index);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ClearItems()
        {
            // Disallow collection modification, so that we don't need to copy it
            // when binding the TaskDialogPage.
            _boundPage?.DenyIfBound();

            foreach (TaskDialogStandardButton button in this)
                button.Collection = null;
            base.ClearItems();
        }

        private void DenyIfHasOtherCollection(TaskDialogStandardButton item)
        {
            if (item.Collection != null && item.Collection != this)
            {
                throw new InvalidOperationException("This control is already part of a different collection.");
            }
        }
    }
}