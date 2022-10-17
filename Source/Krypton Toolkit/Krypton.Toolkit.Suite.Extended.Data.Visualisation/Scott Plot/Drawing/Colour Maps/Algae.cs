﻿#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Algae : IColourMap
    {
        public string Name => "Algae";

        public (byte r, byte g, byte b) GetRGB(byte value) =>
            (cmaplocal[value, 0], cmaplocal[value, 1], cmaplocal[value, 2]);

        private static readonly byte[,] cmaplocal = {
            { 215, 249, 208 },
            { 214, 248, 206 },
            { 212, 247, 205 },
            { 211, 246, 203 },
            { 210, 245, 202 },
            { 209, 244, 200 },
            { 207, 244, 199 },
            { 206, 243, 197 },
            { 205, 242, 196 },
            { 204, 241, 195 },
            { 202, 240, 193 },
            { 201, 239, 192 },
            { 200, 238, 190 },
            { 199, 237, 189 },
            { 197, 236, 187 },
            { 196, 235, 186 },
            { 195, 235, 185 },
            { 194, 234, 183 },
            { 192, 233, 182 },
            { 191, 232, 180 },
            { 190, 231, 179 },
            { 189, 230, 177 },
            { 187, 229, 176 },
            { 186, 228, 175 },
            { 185, 228, 173 },
            { 184, 227, 172 },
            { 182, 226, 171 },
            { 181, 225, 169 },
            { 180, 224, 168 },
            { 178, 223, 166 },
            { 177, 222, 165 },
            { 176, 222, 164 },
            { 175, 221, 162 },
            { 173, 220, 161 },
            { 172, 219, 160 },
            { 171, 218, 158 },
            { 170, 218, 157 },
            { 168, 217, 156 },
            { 167, 216, 154 },
            { 166, 215, 153 },
            { 164, 214, 152 },
            { 163, 213, 150 },
            { 162, 213, 149 },
            { 160, 212, 148 },
            { 159, 211, 146 },
            { 158, 210, 145 },
            { 157, 209, 144 },
            { 155, 209, 143 },
            { 154, 208, 141 },
            { 153, 207, 140 },
            { 151, 206, 139 },
            { 150, 205, 138 },
            { 149, 205, 136 },
            { 147, 204, 135 },
            { 146, 203, 134 },
            { 145, 202, 133 },
            { 143, 202, 131 },
            { 142, 201, 130 },
            { 140, 200, 129 },
            { 139, 199, 128 },
            { 138, 199, 126 },
            { 136, 198, 125 },
            { 135, 197, 124 },
            { 133, 196, 123 },
            { 132, 196, 122 },
            { 131, 195, 121 },
            { 129, 194, 119 },
            { 128, 193, 118 },
            { 126, 193, 117 },
            { 125, 192, 116 },
            { 123, 191, 115 },
            { 122, 190, 114 },
            { 120, 190, 113 },
            { 119, 189, 111 },
            { 117, 188, 110 },
            { 116, 187, 109 },
            { 114, 187, 108 },
            { 113, 186, 107 },
            { 111, 185, 106 },
            { 110, 185, 105 },
            { 108, 184, 104 },
            { 107, 183, 103 },
            { 105, 182, 102 },
            { 103, 182, 101 },
            { 102, 181, 100 },
            { 100, 180, 99 },
            { 98, 180, 98 },
            { 97, 179, 97 },
            { 95, 178, 96 },
            { 93, 178, 95 },
            { 91, 177, 94 },
            { 90, 176, 93 },
            { 88, 175, 93 },
            { 86, 175, 92 },
            { 84, 174, 91 },
            { 82, 173, 90 },
            { 80, 173, 89 },
            { 78, 172, 89 },
            { 76, 171, 88 },
            { 74, 171, 87 },
            { 72, 170, 87 },
            { 70, 169, 86 },
            { 68, 168, 85 },
            { 66, 168, 85 },
            { 63, 167, 84 },
            { 61, 166, 84 },
            { 59, 166, 84 },
            { 57, 165, 83 },
            { 55, 164, 83 },
            { 52, 163, 83 },
            { 50, 163, 82 },
            { 48, 162, 82 },
            { 46, 161, 82 },
            { 44, 160, 82 },
            { 42, 160, 82 },
            { 40, 159, 81 },
            { 38, 158, 81 },
            { 36, 157, 81 },
            { 34, 156, 81 },
            { 32, 156, 81 },
            { 30, 155, 81 },
            { 28, 154, 81 },
            { 27, 153, 81 },
            { 25, 152, 81 },
            { 24, 151, 80 },
            { 22, 150, 80 },
            { 21, 150, 80 },
            { 19, 149, 80 },
            { 18, 148, 80 },
            { 16, 147, 80 },
            { 15, 146, 80 },
            { 14, 145, 80 },
            { 13, 144, 79 },
            { 12, 143, 79 },
            { 11, 143, 79 },
            { 10, 142, 79 },
            { 9, 141, 79 },
            { 9, 140, 79 },
            { 8, 139, 78 },
            { 8, 138, 78 },
            { 7, 137, 78 },
            { 7, 136, 78 },
            { 7, 135, 77 },
            { 7, 134, 77 },
            { 7, 134, 77 },
            { 7, 133, 77 },
            { 7, 132, 77 },
            { 7, 131, 76 },
            { 7, 130, 76 },
            { 8, 129, 76 },
            { 8, 128, 75 },
            { 8, 127, 75 },
            { 9, 126, 75 },
            { 9, 125, 75 },
            { 10, 124, 74 },
            { 10, 124, 74 },
            { 11, 123, 74 },
            { 11, 122, 73 },
            { 12, 121, 73 },
            { 12, 120, 73 },
            { 13, 119, 72 },
            { 13, 118, 72 },
            { 14, 117, 72 },
            { 14, 116, 71 },
            { 15, 115, 71 },
            { 15, 115, 71 },
            { 16, 114, 70 },
            { 16, 113, 70 },
            { 17, 112, 69 },
            { 17, 111, 69 },
            { 18, 110, 69 },
            { 18, 109, 68 },
            { 18, 108, 68 },
            { 19, 107, 67 },
            { 19, 106, 67 },
            { 20, 106, 67 },
            { 20, 105, 66 },
            { 20, 104, 66 },
            { 21, 103, 65 },
            { 21, 102, 65 },
            { 21, 101, 64 },
            { 22, 100, 64 },
            { 22, 99, 64 },
            { 22, 98, 63 },
            { 23, 98, 63 },
            { 23, 97, 62 },
            { 23, 96, 62 },
            { 23, 95, 61 },
            { 24, 94, 61 },
            { 24, 93, 60 },
            { 24, 92, 60 },
            { 24, 91, 59 },
            { 24, 91, 59 },
            { 25, 90, 58 },
            { 25, 89, 58 },
            { 25, 88, 57 },
            { 25, 87, 57 },
            { 25, 86, 56 },
            { 25, 85, 56 },
            { 25, 84, 55 },
            { 25, 84, 55 },
            { 26, 83, 54 },
            { 26, 82, 53 },
            { 26, 81, 53 },
            { 26, 80, 52 },
            { 26, 79, 52 },
            { 26, 78, 51 },
            { 26, 77, 51 },
            { 26, 77, 50 },
            { 26, 76, 50 },
            { 26, 75, 49 },
            { 26, 74, 48 },
            { 26, 73, 48 },
            { 26, 72, 47 },
            { 26, 71, 47 },
            { 26, 71, 46 },
            { 26, 70, 46 },
            { 26, 69, 45 },
            { 26, 68, 44 },
            { 26, 67, 44 },
            { 25, 66, 43 },
            { 25, 65, 43 },
            { 25, 64, 42 },
            { 25, 64, 41 },
            { 25, 63, 41 },
            { 25, 62, 40 },
            { 25, 61, 39 },
            { 25, 60, 39 },
            { 24, 59, 38 },
            { 24, 59, 38 },
            { 24, 58, 37 },
            { 24, 57, 36 },
            { 24, 56, 36 },
            { 24, 55, 35 },
            { 23, 54, 34 },
            { 23, 53, 34 },
            { 23, 53, 33 },
            { 23, 52, 32 },
            { 23, 51, 32 },
            { 22, 50, 31 },
            { 22, 49, 30 },
            { 22, 48, 30 },
            { 22, 47, 29 },
            { 21, 47, 28 },
            { 21, 46, 28 },
            { 21, 45, 27 },
            { 20, 44, 26 },
            { 20, 43, 26 },
            { 20, 42, 25 },
            { 20, 41, 24 },
            { 19, 41, 24 },
            { 19, 40, 23 },
            { 19, 39, 22 },
            { 18, 38, 22 },
            { 18, 37, 21 },
            { 18, 36, 20 }

        };
    }
}