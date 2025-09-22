using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private readonly List<Tween> activeTweens = new List<Tween>();
    public void AddTween(Tween tween)
    {
        activeTweens.Add(tween);
    }
    void Update()
    {
        //To update the tween from last to first
        for (int i = activeTweens.Count - 1; i >= 0; i--)
        {
            Tween tween = activeTweens[i];

            tween.ElapsedTime = Time.deltaTime;//Advance elapsed time by frame duration for the frame-rate independent motion

            tween.Target.position = Vector3.Lerp(tween.StartPosition, tween.EndPosition, tween.Progress);

            //Removes tween once completed
            if (tween.Progress >= 1f)
            {
                activeTweens.RemoveAt(i);
            }

        }
    }

}
