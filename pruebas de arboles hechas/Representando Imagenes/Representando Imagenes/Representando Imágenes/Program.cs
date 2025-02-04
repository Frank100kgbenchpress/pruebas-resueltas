﻿using System.Diagnostics;
using Exam;
namespace Main;

public static class Program
{
    static void Main(string[] args)
    {
        var qt = QuadTreeFactory.Create(4);
        qt.DrawPixel(0, 0, true);
        Debug.Assert(qt.CountPixels() == 1);

        qt.DrawPixel(0, 1, true);
        Debug.Assert(qt.CountPixels() == 2);

        var topLeft = qt.TopLeft;
        Debug.Assert(qt.Color == QuadNodeColor.Gray);

        var bottomRight = qt.BottomRight;
        Debug.Assert(qt.Color == QuadNodeColor.White);

        qt.DrawPixel(1,0, true);
        qt.DrawPixel(1,1, true);
        Debug.Assert(qt.CountPixels() == 4);
        Debug.Assert(qt.TopLeft.Color == QuadNodeColor.Black);

        qt.DrawPixel(3,3,true);
        Debug.Assert(qt.BottomRight.Color == QuadNodeColor.Gray);
    }
}