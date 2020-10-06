using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Passive data class holding schedule information
    /// </summary>
    [Serializable]
    public class Task
    {
        /// <summary>
        /// Initialize a new task to hold schedule information
        /// </summary>
        public Task()
        {
            Complete = 0.0f;
            Start = TimeSpan.Zero;
            End = new TimeSpan(1, 0, 0, 0);
            Duration = new TimeSpan(1, 0, 0, 0);
            Slack = TimeSpan.Zero;
        }

        /// <summary>
        /// Get or set the Name of this Task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicate whether this task is collapsed such that sub tasks are hidden from view. Only groups can be collasped.
        /// </summary>
        public bool IsCollapsed { get; set; }

        /// <summary>
        /// Get or set the pecentage complete of this task, expressed in float between 0.0 and 1.0f.
        /// </summary>
        public float Complete { get; internal set; }

        /// <summary>
        /// Get the start time of this Task relative to the project start
        /// </summary>
        public TimeSpan Start { get; internal set; }

        /// <summary>
        /// Get the end time of this Task relative to the project start
        /// </summary>
        public TimeSpan End { get; internal set; }

        /// <summary>
        /// Get the duration of this Task in days
        /// </summary>
        public TimeSpan Duration { get; internal set; }

        /// <summary>
        /// Get the amount of slack (free float)
        /// </summary>
        public TimeSpan Slack { get; internal set; }

        /// <summary>
        /// Convert this Task to a descriptive string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Name = {0}, Start = {1}, End = {2}, Duration = {3}, Complete = {4}]", Name, Start, End, Duration, Complete);
        }
    }

    /// <summary>
    /// ProjectManager interface
    /// </summary>
    /// <typeparam name="T">Task class type</typeparam>
    /// <typeparam name="R">Resource class type</typeparam>
    public interface IProjectManager<T, R>
        where T : Task
        where R : class
    {
        /// <summary>
        /// Add task to project manager
        /// </summary>
        /// <param name="task"></param>
        void Add(T task);
        /// <summary>
        /// Delete task from project manager
        /// </summary>
        /// <param name="task"></param>
        void Delete(T task);
        /// <summary>
        /// Group the member task under the group task. Group task cannot have relations.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="member"></param>
        void Group(T group, T member);
        /// <summary>
        /// Ungroup member task from group task. If there are no more task under group, group will become a normal task.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="member"></param>
        void Ungroup(T group, T member);
        /// <summary>
        /// Split the specified task into consecutive parts part1 and part2.
        /// </summary>
        /// <param name="task">The regular task to split which has duration of at least 2 to make two parts of 1 time unit duration each.</param>
        /// <param name="part1">New Task part (1) of the split task, with the start time of the original task and the specified duration value.</param>
        /// <param name="part2">New Task part (2) of the split task, starting 1 time unit after part (1) ends and having the remaining of the duration of the origina task.</param>
        /// <param name="duration">The duration of part (1) will be set to the specified duration value but will also be adjusted to approperiate value if necessary.</param>
        void Split(T task, T part1, T part2, TimeSpan duration);
        /// <summary>
        /// Split the specified part and obtain another part from it.
        /// </summary>
        /// <param name="part">The task part to split which has duration of at least 2 to make two parts of 1 time unit duration each. Its duration will be set to the specified duration value.</param>
        /// <param name="another">New Task part of the original part, starting 1 time unit after it ends and having the remaining of the duration of the original part.</param>
        /// <param name="duration">The duration of part (1) will be set to the specified duration value but will also be adjusted to approperiate value if necessary.</param>
        void Split(T part, T another, TimeSpan duration);
        /// <summary>
        /// Join part1 and part2 in a split task into a single part represented by part1, and part2 will be deleted from the ProjectManager.
        /// The resulting part will have a duration total of the two parts. Schedule of other parts will be packed according to direction of join.
        /// If the join will result in only one part remaining, the split task will merge instead.
        /// </summary>
        /// <param name="part1">The part to keep in the ProjectManager after the join completes successfully.</param>
        /// <param name="part2">The part to join into part1 and be deleted afterwards from the ProjectManager.</param>
        void Join(T part1, T part2);
        /// <summary>
        /// Merge all the parts of the splitted task back into one task, having duration equal to sum of total duration of individual task parts, and aggregating the resources onto the resulting task.
        /// </summary>
        /// <param name="split">The split Task to merge</param>
        void Merge(T split);
        /// <summary>
        /// Get the parts of the split task
        /// </summary>
        /// <param name="split"></param>
        /// <returns></returns>
        IEnumerable<T> PartsOf(T split);
        /// <summary>
        /// Get the split task that the specified part belogs to.
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        T SplitTaskOf(T part);
        /// <summary>
        /// Get whether the specified task is a split task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool IsSplit(T task);
        /// <summary>
        /// Get whether the specified task is a part of a split task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool IsPart(T task);
        /// <summary>
        /// Ungroup all member task under the specfied group task. The specified group task will become a normal task.
        /// </summary>
        /// <param name="group"></param>
        void Ungroup(T group);
        /// <summary>
        /// Move the specified task by offset positions in the task enumeration
        /// </summary>
        /// <param name="task"></param>
        /// <param name="offset"></param>
        void Move(T task, int offset);
        /// <summary>
        /// Set a relation between the precedent and dependant task
        /// </summary>
        /// <param name="precedent"></param>
        /// <param name="dependant"></param>
        void Relate(T precedent, T dependant);
        /// <summary>
        /// Unset the relation between the precedent and dependant task, if any.
        /// </summary>
        /// <param name="precedent"></param>
        /// <param name="dependant"></param>
        void Unrelate(T precedent, T dependant);
        /// <summary>
        /// Remove all dependant task from specified precedent task
        /// </summary>
        /// <param name="precedent"></param>
        void Unrelate(T precedent);
        /// <summary>
        /// Enumerate through all tasks that is a precedent, having dependants.
        /// </summary>
        IEnumerable<T> Precedents { get; }
        /// <summary>
        /// Enumerate through all the tasks in the ProjectManager.
        /// If there are no change to groups and no add/delete tasks, the order between consecutive calls is preserved.
        /// </summary>
        IEnumerable<T> Tasks { get; }
        /// <summary>
        /// Set the start time of the specified task.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="start">Number of timescale units after ProjectManager.Start</param>
        void SetStart(T task, TimeSpan start);
        /// <summary>
        /// Set the end time of the specified task. Duration is automatically adjusted to satisfy.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="end">Number of timescale units after ProjectManager.Start</param>
        void SetEnd(T task, TimeSpan end);
        /// <summary>
        /// Set the duration of the specified task from start to end.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="duration">Number of timescale units between ProjectManager.Start</param>
        void SetDuration(T task, TimeSpan duration);
        /// <summary>
        /// Set the percentage complete of the specified task from 0.0f to 1.0f.
        /// No effect on group tasks as they will get the aggregated percentage complete of all child tasks
        /// </summary>
        /// <param name="task"></param>
        /// <param name="complete"></param>
        void SetComplete(T task, float complete);
        /// <summary>
        /// Set whether to collapse the specified group task. No effect on regular tasks.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="collasped"></param>
        void SetCollapse(T group, bool collasped);
        /// <summary>
        /// Set the "now" time. Its value is the number of timescale units after the start time.
        /// </summary>
        TimeSpan Now { get; }
        /// <summary>
        /// Set the start date of the project.
        /// </summary>
        DateTime Start { get; set; }
        /// <summary>
        /// Get the zero-based index of the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        int IndexOf(T task);
        /// <summary>
        /// Enumerate through parent group and grandparent groups of the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IEnumerable<T> GroupsOf(T task);
        /// <summary>
        /// Enumerate through all the children and grandchildren of the specified group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        IEnumerable<T> MembersOf(T group);
        /// <summary>
        /// Enumerate through all the direct children of the specified group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        IEnumerable<T> DirectMembersOf(T group);
        /// <summary>
        /// Enumerate through all the direct precedents and indirect precedents of the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IEnumerable<T> PrecedentsOf(T task);
        /// <summary>
        /// Enumerate through all the direct dependants and indirect dependants of the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IEnumerable<T> DependantsOf(T task);
        /// <summary>
        /// Enumerate through all the direct precedents of the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IEnumerable<T> DirectPrecedentsOf(T task);
        /// <summary>
        /// Enumerate through all the direct dependants of the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IEnumerable<T> DirectDependantsOf(T task);
        /// <summary>
        /// Enumerate through all the critical paths. Each path is an enumerable of tasks, starting from the final task of each path.
        /// </summary>
        IEnumerable<IEnumerable<T>> CriticalPaths { get; }
        /// <summary>
        /// Get the parent group of the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        T DirectGroupOf(T task);
        /// <summary>
        /// Get whether the specified task is a group
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool IsGroup(T task);
        /// <summary>
        /// Get whether the specified task is a member
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool IsMember(T task);
        /// <summary>
        /// Get whether the specified task has relations, either has dependants or has precedents connecting to it.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        bool HasRelations(T task);
        /// <summary>
        /// Assign the specified resource to the specified task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="resource"></param>
        void Assign(T task, R resource);
        /// <summary>
        /// Unassign the specified resource from the specfied task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="resource"></param>
        void Unassign(T task, R resource);
        /// <summary>
        /// Unassign all resources from the specified task
        /// </summary>
        /// <param name="task"></param>
        void Unassign(T task);
        /// <summary>
        /// Unassign the specified resource from all tasks that has this resource assigned
        /// </summary>
        /// <param name="resource"></param>
        void Unassign(R resource);
        /// <summary>
        /// Enumerate through all the resources that has been assigned to some task.
        /// </summary>
        IEnumerable<R> Resources { get; }
        /// <summary>
        /// Enumerate through all the resources that has been assigned to the specified task.
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        IEnumerable<R> ResourcesOf(T task);
        /// <summary>
        /// Enumerate through all the tasks that has the specified resource assigned to it.
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        IEnumerable<T> TasksOf(R resource);
    }
}