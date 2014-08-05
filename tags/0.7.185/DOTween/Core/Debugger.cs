﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/03 11:33
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 

using UnityEngine;

namespace DG.Tweening.Core
{
    internal static class Debugger
    {
        // 0: errors only - 1: default - 2: verbose
        internal static int logPriority;

        internal static void Log(object message)
        {
            Debug.Log("DOTWEEN :: " + message);
        }
        internal static void LogWarning(object message)
        {
            Debug.LogWarning("DOTWEEN :: " + message);
        }
        internal static void LogError(object message)
        {
            Debug.LogError("DOTWEEN :: " + message);
        }

        internal static void LogReport(object message)
        {
            Debug.Log("<color=#00B500FF>DOTWEEN :: " + message + "</color>");
        }

        internal static void LogInvalidTween(Tween t)
        {
            LogWarning("This Tween has been killed and is now invalid");
        }

        internal static void SetLogPriority(LogBehaviour logBehaviour)
        {
            switch (logBehaviour) {
            case LogBehaviour.Default:
                logPriority = 1;
                break;
            case LogBehaviour.Verbose:
                logPriority = 2;
                break;
            default:
                logPriority = 0;
                break;
            }
        }
    }
}