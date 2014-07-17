﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/11 13:04
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

using DG.Tween.Core;
using DG.Tween.Plugins.Core;
using UnityEngine;

namespace DG.Tween.Plugins.DefaultPlugins
{
    // BEWARE: RectOffset seems a struct but is a class
    // USING THIS PLUGIN WILL GENERATE GC ALLOCATIONS
    public class RectOffsetPlugin : ABSTweenPlugin<RectOffset, RectOffset, NoOptions>
    {
        public override RectOffset ConvertT1toT2(NoOptions options, RectOffset value)
        {
            return new RectOffset(value.left, value.right, value.top, value.bottom);
        }

        public override RectOffset GetRelativeEndValue(NoOptions options, RectOffset startValue, RectOffset changeValue)
        {
            return new RectOffset(
                startValue.left + changeValue.left,
                startValue.right + changeValue.right,
                startValue.top + changeValue.top,
                startValue.bottom + changeValue.bottom
            );
        }

        public override RectOffset GetChangeValue(NoOptions options, RectOffset startValue, RectOffset endValue)
        {
            return new RectOffset(
                endValue.left - startValue.left,
                endValue.right - startValue.right,
                endValue.top - startValue.top,
                endValue.bottom - startValue.bottom
            );
        }

        public override RectOffset Evaluate(NoOptions options, bool isRelative, MemberGetter<RectOffset> getter, float elapsed, RectOffset startValue, RectOffset changeValue, float duration, EaseFunction ease)
        {
            return new RectOffset(
                Mathf.RoundToInt(ease(elapsed, startValue.left, changeValue.left, duration, 0, 0)),
                Mathf.RoundToInt(ease(elapsed, startValue.right, changeValue.right, duration, 0, 0)),
                Mathf.RoundToInt(ease(elapsed, startValue.top, changeValue.top, duration, 0, 0)),
                Mathf.RoundToInt(ease(elapsed, startValue.bottom, changeValue.bottom, duration, 0, 0))
            );
        }
    }
}