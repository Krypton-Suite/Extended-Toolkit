#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class CommandManager
    {
        public static int MaxHistoryLength = 200;

        LimitedStack<UndoableCommand> history;
        Stack<UndoableCommand> redoStack = new Stack<UndoableCommand>();
        public TextSource TextSource { get; private set; }
        public bool UndoRedoStackIsEnabled { get; set; }

        public event EventHandler RedoCompleted = delegate { };

        public CommandManager(TextSource ts)
        {
            history = new LimitedStack<UndoableCommand>(MaxHistoryLength);
            TextSource = ts;
            UndoRedoStackIsEnabled = true;
        }

        public virtual void ExecuteCommand(Command cmd)
        {
            if (disabledCommands > 0)
                return;

            //multirange ?
            if (cmd.ts.CurrentTB.Selection.ColumnSelectionMode)
                if (cmd is UndoableCommand)
                    //make wrapper
                    cmd = new MultiRangeCommand((UndoableCommand)cmd);


            if (cmd is UndoableCommand)
            {
                //if range is ColumnRange, then create wrapper
                (cmd as UndoableCommand).autoUndo = autoUndoCommands > 0;
                history.Push(cmd as UndoableCommand);
            }

            try
            {
                cmd.Execute();
            }
            catch (ArgumentOutOfRangeException)
            {
                //OnTextChanging cancels enter of the text
                if (cmd is UndoableCommand)
                    history.Pop();
            }
            //
            if (!UndoRedoStackIsEnabled)
                ClearHistory();
            //
            redoStack.Clear();
            //
            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                var cmd = history.Pop();
                //
                BeginDisableCommands();//prevent text changing into handlers
                try
                {
                    cmd.Undo();
                }
                finally
                {
                    EndDisableCommands();
                }
                //
                redoStack.Push(cmd);
            }

            //undo next autoUndo command
            if (history.Count > 0)
            {
                if (history.Peek().autoUndo)
                    Undo();
            }

            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        protected int disabledCommands = 0;

        private void EndDisableCommands()
        {
            disabledCommands--;
        }

        private void BeginDisableCommands()
        {
            disabledCommands++;
        }

        int autoUndoCommands = 0;

        public void EndAutoUndoCommands()
        {
            autoUndoCommands--;
            if (autoUndoCommands == 0)
                if (history.Count > 0)
                    history.Peek().autoUndo = false;
        }

        public void BeginAutoUndoCommands()
        {
            autoUndoCommands++;
        }

        internal void ClearHistory()
        {
            history.Clear();
            redoStack.Clear();
            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        internal void Redo()
        {
            if (redoStack.Count == 0)
                return;
            UndoableCommand cmd;
            BeginDisableCommands();//prevent text changing into handlers
            try
            {
                cmd = redoStack.Pop();
                if (TextSource.CurrentTB.Selection.ColumnSelectionMode)
                    TextSource.CurrentTB.Selection.ColumnSelectionMode = false;
                TextSource.CurrentTB.Selection.Start = cmd.sel.Start;
                TextSource.CurrentTB.Selection.End = cmd.sel.End;
                cmd.Execute();
                history.Push(cmd);
            }
            finally
            {
                EndDisableCommands();
            }

            //call event
            RedoCompleted(this, EventArgs.Empty);

            //redo command after autoUndoable command
            if (cmd.autoUndo)
                Redo();

            TextSource.CurrentTB.OnUndoRedoStateChanged();
        }

        public bool UndoEnabled
        {
            get
            {
                return history.Count > 0;
            }
        }

        public bool RedoEnabled
        {
            get
            {
                return redoStack.Count > 0;
            }
        }
    }
}