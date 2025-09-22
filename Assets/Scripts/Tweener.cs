using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private readonly List<Tween> activeTweens = new List<Tween>();
    void Update()
    {
        //To update the tween from last to first
        for (int i = activeTweens.Count -1; i>= 0;)
        {
            Tween tween = activeTweens[i];
            tween.ElapsedTime += Vector3.Lerp(tween.StartPosition, tween.EndPos
        }
    }
}
