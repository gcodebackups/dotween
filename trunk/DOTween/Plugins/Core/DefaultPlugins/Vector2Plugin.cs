﻿// Author: Daniele Giardini - http://www.demigiant.com
// Created: 2014/07/10 16:51
// 
// License Copyright (c) Daniele Giardini.
// This work is subject to the terms at http://dotween.demigiant.com/license.php

using System;
using DG.Tweening.Core;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins.Core.DefaultPlugins.Options;
using UnityEngine;

#pragma warning disable 1591
namespace DG.Tweening.Plugins.Core.DefaultPlugins
{
    public class Vector2Plugin : ABSTweenPlugin<Vector2, Vector2, VectorOptions>
    {
        public override void Reset(TweenerCore<Vector2, Vector2, VectorOptions> t) { }

        public override Vector2 ConvertToStartValue(TweenerCore<Vector2, Vector2, VectorOptions> t, Vector2 value)
        {
            return value;
        }

        public override void SetRelativeEndValue(TweenerCore<Vector2, Vector2, VectorOptions> t)
        {
            t.endValue += t.startValue;
        }

        public override void SetChangeValue(TweenerCore<Vector2, Vector2, VectorOptions> t)
        {
            switch (t.plugOptions.axisConstraint) {
            case AxisConstraint.X:
                t.changeValue = new Vector2(t.endValue.x - t.startValue.x, 0);
                break;
            case AxisConstraint.Y:
                t.changeValue = new Vector2(0, t.endValue.y - t.startValue.y);
                break;
            default:
                t.changeValue = t.endValue - t.startValue;
                break;
            }
        }

        public override float GetSpeedBasedDuration(VectorOptions options, float unitsXSecond, Vector2 changeValue)
        {
            return changeValue.magnitude / unitsXSecond;
        }

        public override Vector2 Evaluate(VectorOptions options, Tween t, bool isRelative, DOGetter<Vector2> getter, float elapsed, Vector2 startValue, Vector2 changeValue, float duration)
        {
            if (t.loopType == LoopType.Incremental) startValue += changeValue * (t.isComplete ? t.completedLoops - 1 : t.completedLoops);

            switch (options.axisConstraint) {
            case AxisConstraint.X:
                Vector2 resX = getter();
                resX.x = EaseManager.Evaluate(t, elapsed, startValue.x, changeValue.x, duration, t.easeOvershootOrAmplitude, t.easePeriod);
                if (options.snapping) resX.x = (float)Math.Round(resX.x);
                return resX;
            case AxisConstraint.Y:
                Vector2 resY = getter();
                resY.y = EaseManager.Evaluate(t, elapsed, startValue.y, changeValue.y, duration, t.easeOvershootOrAmplitude, t.easePeriod);
                if (options.snapping) resY.y = (float)Math.Round(resY.y);
                return resY;
            default:
                startValue.x = EaseManager.Evaluate(t, elapsed, startValue.x, changeValue.x, duration, t.easeOvershootOrAmplitude, t.easePeriod);
                startValue.y = EaseManager.Evaluate(t, elapsed, startValue.y, changeValue.y, duration, t.easeOvershootOrAmplitude, t.easePeriod);
                if (options.snapping) {
                    startValue.x = (float)Math.Round(startValue.x);
                    startValue.y = (float)Math.Round(startValue.y);
                }
                return startValue;
            }
        }
    }
}