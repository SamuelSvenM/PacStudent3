using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target;
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float ElapsedTime;
    public float Duration;
    public Tween(Transform target, Vector3 start, Vector3 end, float duration)
    {

        Target = target;
        StartPosition = start;
        EndPosition = end;
        Duration = duration;
        ElapsedTime = 0f;

    }
    public float Progress
    {
        get { return Mathf.Clamp01(ElapsedTime / Duration); }
    }
}





  
