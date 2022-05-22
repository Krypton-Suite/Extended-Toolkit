﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Solar : IColourMap
    {
        public string Name => "Solar";

        public (byte r, byte g, byte b) GetRGB(byte value) =>
            (cmaplocal[value, 0], cmaplocal[value, 1], cmaplocal[value, 2]);

        private static readonly byte[,] cmaplocal = {
            { 51, 20, 24 },
            { 53, 20, 24 },
            { 54, 21, 25 },
            { 55, 21, 25 },
            { 56, 21, 26 },
            { 58, 22, 26 },
            { 59, 22, 27 },
            { 60, 23, 27 },
            { 61, 23, 28 },
            { 62, 24, 28 },
            { 64, 24, 29 },
            { 65, 24, 29 },
            { 66, 25, 29 },
            { 67, 25, 30 },
            { 69, 26, 30 },
            { 70, 26, 31 },
            { 71, 26, 31 },
            { 72, 27, 31 },
            { 74, 27, 32 },
            { 75, 27, 32 },
            { 76, 28, 32 },
            { 77, 28, 33 },
            { 79, 28, 33 },
            { 80, 29, 33 },
            { 81, 29, 34 },
            { 82, 30, 34 },
            { 84, 30, 34 },
            { 85, 30, 34 },
            { 86, 31, 35 },
            { 87, 31, 35 },
            { 89, 31, 35 },
            { 90, 32, 35 },
            { 91, 32, 35 },
            { 92, 32, 36 },
            { 94, 33, 36 },
            { 95, 33, 36 },
            { 96, 33, 36 },
            { 97, 34, 36 },
            { 99, 34, 36 },
            { 100, 34, 36 },
            { 101, 35, 36 },
            { 102, 35, 37 },
            { 104, 35, 37 },
            { 105, 36, 37 },
            { 106, 36, 37 },
            { 107, 36, 37 },
            { 109, 37, 37 },
            { 110, 37, 37 },
            { 111, 37, 37 },
            { 112, 38, 37 },
            { 114, 38, 37 },
            { 115, 39, 36 },
            { 116, 39, 36 },
            { 117, 39, 36 },
            { 119, 40, 36 },
            { 120, 40, 36 },
            { 121, 41, 36 },
            { 122, 41, 36 },
            { 123, 42, 36 },
            { 124, 42, 35 },
            { 126, 43, 35 },
            { 127, 43, 35 },
            { 128, 44, 35 },
            { 129, 44, 34 },
            { 130, 45, 34 },
            { 131, 45, 34 },
            { 132, 46, 34 },
            { 133, 46, 33 },
            { 135, 47, 33 },
            { 136, 48, 33 },
            { 137, 48, 33 },
            { 138, 49, 32 },
            { 139, 49, 32 },
            { 140, 50, 32 },
            { 141, 51, 31 },
            { 142, 52, 31 },
            { 143, 52, 31 },
            { 144, 53, 30 },
            { 145, 54, 30 },
            { 146, 54, 30 },
            { 147, 55, 29 },
            { 147, 56, 29 },
            { 148, 57, 29 },
            { 149, 58, 29 },
            { 150, 58, 28 },
            { 151, 59, 28 },
            { 152, 60, 28 },
            { 153, 61, 27 },
            { 154, 62, 27 },
            { 154, 63, 27 },
            { 155, 64, 26 },
            { 156, 64, 26 },
            { 157, 65, 26 },
            { 158, 66, 26 },
            { 159, 67, 25 },
            { 159, 68, 25 },
            { 160, 69, 25 },
            { 161, 70, 25 },
            { 162, 71, 24 },
            { 163, 72, 24 },
            { 163, 73, 24 },
            { 164, 74, 24 },
            { 165, 74, 23 },
            { 166, 75, 23 },
            { 166, 76, 23 },
            { 167, 77, 23 },
            { 168, 78, 22 },
            { 168, 79, 22 },
            { 169, 80, 22 },
            { 170, 81, 22 },
            { 171, 82, 22 },
            { 171, 83, 21 },
            { 172, 84, 21 },
            { 173, 85, 21 },
            { 173, 86, 21 },
            { 174, 87, 21 },
            { 175, 88, 20 },
            { 175, 89, 20 },
            { 176, 90, 20 },
            { 177, 91, 20 },
            { 177, 92, 20 },
            { 178, 93, 20 },
            { 178, 94, 20 },
            { 179, 95, 20 },
            { 180, 96, 19 },
            { 180, 97, 19 },
            { 181, 98, 19 },
            { 182, 99, 19 },
            { 182, 100, 19 },
            { 183, 101, 19 },
            { 183, 102, 19 },
            { 184, 104, 19 },
            { 184, 105, 19 },
            { 185, 106, 19 },
            { 186, 107, 19 },
            { 186, 108, 19 },
            { 187, 109, 19 },
            { 187, 110, 19 },
            { 188, 111, 19 },
            { 188, 112, 19 },
            { 189, 113, 19 },
            { 190, 114, 19 },
            { 190, 115, 19 },
            { 191, 116, 19 },
            { 191, 117, 19 },
            { 192, 118, 19 },
            { 192, 119, 20 },
            { 193, 121, 20 },
            { 193, 122, 20 },
            { 194, 123, 20 },
            { 194, 124, 20 },
            { 195, 125, 20 },
            { 195, 126, 21 },
            { 196, 127, 21 },
            { 196, 128, 21 },
            { 197, 129, 21 },
            { 197, 130, 21 },
            { 198, 132, 22 },
            { 198, 133, 22 },
            { 199, 134, 22 },
            { 199, 135, 22 },
            { 199, 136, 23 },
            { 200, 137, 23 },
            { 200, 138, 23 },
            { 201, 139, 24 },
            { 201, 140, 24 },
            { 202, 142, 24 },
            { 202, 143, 25 },
            { 203, 144, 25 },
            { 203, 145, 25 },
            { 203, 146, 26 },
            { 204, 147, 26 },
            { 204, 148, 26 },
            { 205, 150, 27 },
            { 205, 151, 27 },
            { 206, 152, 28 },
            { 206, 153, 28 },
            { 206, 154, 28 },
            { 207, 155, 29 },
            { 207, 156, 29 },
            { 208, 158, 30 },
            { 208, 159, 30 },
            { 208, 160, 31 },
            { 209, 161, 31 },
            { 209, 162, 32 },
            { 209, 164, 32 },
            { 210, 165, 32 },
            { 210, 166, 33 },
            { 211, 167, 33 },
            { 211, 168, 34 },
            { 211, 169, 34 },
            { 212, 171, 35 },
            { 212, 172, 36 },
            { 212, 173, 36 },
            { 213, 174, 37 },
            { 213, 175, 37 },
            { 213, 177, 38 },
            { 214, 178, 38 },
            { 214, 179, 39 },
            { 214, 180, 39 },
            { 215, 181, 40 },
            { 215, 183, 40 },
            { 215, 184, 41 },
            { 215, 185, 42 },
            { 216, 186, 42 },
            { 216, 188, 43 },
            { 216, 189, 43 },
            { 217, 190, 44 },
            { 217, 191, 44 },
            { 217, 193, 45 },
            { 217, 194, 46 },
            { 218, 195, 46 },
            { 218, 196, 47 },
            { 218, 198, 47 },
            { 218, 199, 48 },
            { 219, 200, 49 },
            { 219, 201, 49 },
            { 219, 203, 50 },
            { 219, 204, 50 },
            { 220, 205, 51 },
            { 220, 206, 52 },
            { 220, 208, 52 },
            { 220, 209, 53 },
            { 221, 210, 54 },
            { 221, 212, 54 },
            { 221, 213, 55 },
            { 221, 214, 55 },
            { 221, 215, 56 },
            { 222, 217, 57 },
            { 222, 218, 57 },
            { 222, 219, 58 },
            { 222, 221, 59 },
            { 222, 222, 59 },
            { 222, 223, 60 },
            { 223, 225, 61 },
            { 223, 226, 61 },
            { 223, 227, 62 },
            { 223, 229, 63 },
            { 223, 230, 63 },
            { 223, 231, 64 },
            { 223, 233, 65 },
            { 224, 234, 65 },
            { 224, 235, 66 },
            { 224, 237, 67 },
            { 224, 238, 67 },
            { 224, 240, 68 },
            { 224, 241, 69 },
            { 224, 242, 69 },
            { 224, 244, 70 },
            { 224, 245, 71 },
            { 224, 246, 71 },
            { 224, 248, 72 },
            { 224, 249, 73 },
            { 224, 251, 73 },
            { 225, 252, 74 },
            { 225, 253, 75 }

        };
    }
}

