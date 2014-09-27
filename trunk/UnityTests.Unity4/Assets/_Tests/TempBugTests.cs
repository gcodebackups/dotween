﻿using DG.Tweening;
using System.Collections;
using UnityEngine;

public class TempBugTests : BrainBase
{
	public Transform[] targets;

	Sequence main;

    void OnGUI()
    {
        DGUtils.BeginGUI();

        if (GUILayout.Button("TogglePause")) DOTween.TogglePause();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Rewind")) DOTween.Rewind();
        if (GUILayout.Button("Complete")) DOTween.Complete();
        if (GUILayout.Button("Flip")) DOTween.Flip();
        if (GUILayout.Button("Goto 0.5")) DOTween.Goto(0.5f);
        if (GUILayout.Button("Goto 1")) DOTween.Goto(1);
        if (GUILayout.Button("Goto 1.5")) DOTween.Goto(1.5f);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Sequence > LoopType.Restart")) NewSequence(LoopType.Restart, false);
        if (GUILayout.Button("Sequence > LoopType.Restart > Flipped")) NewSequence(LoopType.Restart, true);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Sequence > LoopType.Yoyo")) NewSequence(LoopType.Yoyo, false);
        if (GUILayout.Button("Sequence > LoopType.Yoyo > Flipped")) NewSequence(LoopType.Yoyo, true);
        GUILayout.EndHorizontal();

        DGUtils.EndGUI();
    }

    void NewSequence(LoopType loopType, bool flip)
    {
    	main.Rewind();
    	main.Kill();

    	Sequence innerS0 = DOTween.Sequence()
            .SetId("INNER");
            // .SetLoops(3, loopType)
            // .Append(targets[0].DOMoveX(3, 1).SetEase(Ease.Linear));
        // innerS0.InsertCallback(0.25f, ()=> Callback("INNER"));

        Sequence innerS1 = DOTween.Sequence()
            .SetId("INNER INNER")
            .SetLoops(3, loopType)
            .Append(targets[0].DOMoveX(3, 1).SetEase(Ease.Linear));
        innerS1.InsertCallback(0.25f, ()=> Callback("INNER INNER"));
        innerS0.Append(innerS0);

        main = DOTween.Sequence()
            .SetId("MAIN")
            .SetLoops(2, loopType)
            .SetAutoKill(false)
            // .Append(targets[0].DOMoveX(3, 1).SetEase(Ease.Linear));
            .Append(innerS0);
        // main.InsertCallback(0.25f, ()=> Callback("MAIN"));

        if (flip) {
        	main.Complete();
        	main.Flip();
        	main.PlayBackwards();
        }
    }

    void Callback(string id)
    {
    	Debug.Log("<color=#92FF70>>>> " + id + " > Callback > " + main.Elapsed(true) + "</color>");
    }
}