using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private static Tweener instance;
    private List<Tween> activeTweens = new List<Tween>();

    public static Tweener Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Tweener");
                instance = go.AddComponent<Tweener>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }

    public void AddTween(Tween tween)
    {
        if (!activeTweens.Contains(tween))
            activeTweens.Add(tween);
    }

    private void Update()
    {
        float deltaTime = Time.deltaTime;

        for (int i = activeTweens.Count - 1; i >= 0; i--)
        {
            activeTweens[i].Update(deltaTime);
            if (activeTweens[i].IsFinished)
                activeTweens.RemoveAt(i);
        }
    }
}