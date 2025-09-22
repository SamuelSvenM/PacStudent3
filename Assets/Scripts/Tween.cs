using System;
using UnityEngine;

public class Tween
{
    public float Duration { get; private set; }
    public float ElapsedTime { get; private set; }
    public bool IsFinished { get; private set; }
    private Action<float> onUpdate;
    private Func<float, float> easingFunction;

    public Tween(float duration, Action<float> onUpdate, Func<float, float> easingFunction = null)
    {
        Duration = duration;
        this.onUpdate = onUpdate;
        this.easingFunction = easingFunction ?? (t => t);
        ElapsedTime = 0f;
        IsFinished = false;
    }

    public void Update(float deltaTime)
    {
        if (IsFinished) return;

        ElapsedTime += deltaTime;
        float progress = Mathf.Clamp01(ElapsedTime / Duration);
        float eased = easingFunction(progress);
        onUpdate(eased);

        if (ElapsedTime >= Duration)
        {
            IsFinished = true;
            onUpdate(1f);
        }
    }
}