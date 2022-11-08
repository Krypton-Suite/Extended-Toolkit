#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    [Flags]
    internal enum SsmlElement
    {
        Speak = 0x1,
        Voice = 0x2,
        Audio = 0x4,
        Lexicon = 0x8,
        Meta = 0x10,
        MetaData = 0x20,
        Sentence = 0x40,
        Paragraph = 0x80,
        SayAs = 0x100,
        Phoneme = 0x200,
        Sub = 0x400,
        Emphasis = 0x800,
        Break = 0x1000,
        Prosody = 0x2000,
        Mark = 0x4000,
        Desc = 0x8000,
        Text = 0x10000,
        PromptEngineOutput = 0x20000,
        PromptEngineDatabase = 0x40000,
        PromptEngineDiv = 0x80000,
        PromptEngineId = 0x100000,
        PromptEngineTTS = 0x200000,
        PromptEngineWithTag = 0x400000,
        PromptEngineRule = 0x800000,
        ParagraphOrSentence = 0xC0,
        AudioMarkTextWithStyle = 0x37F06,
        PromptEngineChildren = 0xFC0000
    }
}