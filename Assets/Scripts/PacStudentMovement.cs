using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public Transform[] Waypoints;

    public float Speed = 3f;

    public Animator Animator;

    public AudioSource MoveAudio;

    private Tweener tweener;

    private int currentWaypoint = 0;

    private void Start()
    {
        tweener = FindObjectOfType<Tweener>();

        if (Waypoints == null || Waypoints.Length == 0)
        {
            Debug.LogError("Waypoints are not assigned in PacStudentMovement");
            return;
        }
        transform.position = Waypoints[0].position;
        StartCoroutine(MoveAlongWaypoints());

    }
    private IEnumerator MoveAlongWaypoints()
    {
        yield return null; 
    }
}