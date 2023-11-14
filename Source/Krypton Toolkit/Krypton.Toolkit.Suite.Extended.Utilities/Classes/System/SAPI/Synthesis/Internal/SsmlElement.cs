#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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