using System.Collections.Generic;
using UnityEngine;
public class PacStudentMovement : MonoBehaviour
{
    public float tweenDuration = 1f;
    public Vector3[] positions;

    private int currentIndex = 0;
    private bool isMoving = false;

    void Start()
    {
        if (positions == null || positions.Length == 0)
        {
            Debug.LogError("Positions array is empty! Assign some coordinates.");
            return;
        }

        transform.position = positions[currentIndex];
        currentIndex = (currentIndex + 1) % positions.Length;

        MoveToNextPosition();
    }

    void MoveToNextPosition()
    {
        if (isMoving) return;

        isMoving = true;

        Vector3 startPos = transform.position;
        Vector3 targetPos = positions[currentIndex];

        if (startPos == targetPos)
        {
            AdvanceIndex();
            isMoving = false;
            MoveToNextPosition();
            return;
        }

        Tween tween = new Tween(tweenDuration, (float t) =>
        {
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            if (t >= 1f)
            {
                isMoving = false;
                transform.position = targetPos;
                AdvanceIndex();
                MoveToNextPosition();
            }
        }, EaseInOut);

        Tweener.Instance.AddTween(tween);
    }

    private void AdvanceIndex()
    {
        currentIndex = (currentIndex + 1) % positions.Length;
    }

    float EaseInOut(float t)
    {
        return t * t * (3f - 2f * t);
    }
} 
