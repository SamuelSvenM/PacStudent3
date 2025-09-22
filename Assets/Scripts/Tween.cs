using System;
using UnityEngine;

public class Tween
{
    public float Duration { get; }//duration of tween animation
    public float TimeElapsed { get; private set; }
    public bool Completed { get; private set; }

    private Action<float> onUpdate;

    private Func<float, float> easingFunction;//optional easing function 
    public Tween(float duration, Action<float> onUpdate, Func<float, float> easingFunction = null)
    {
        Duration = duration;
        this.onUpdate = onUpdate;
        this.easingFunction = easingFunction ?? (t => t);
        TimeElapsed = 0f;
        Completed = false;
    }
    public void Update(float deltaTime)
    {
        if (Completed) return;

        TimeElapsed += deltaTime;
        float progress = Mathf.Clamp01(TimeElapsed / Duration);
        float easedProgress = easingFunction(progress);

        onUpdate(easedProgress);

        if (TimeElapsed >= Duration)
        {
            Completed = true;
            onUpdate(1f);
        }
    }
}


