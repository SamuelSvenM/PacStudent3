using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentMovement : MonoBehaviour
{
    public Transform[] Waypoints;//Array of waypoints in clockwise in order for Pacstudent to move

    public float Speed = 3f;//the speed

    public Animator Animator;

    public AudioSource MoveAudio;

    private Tweener tweener;//To reference tweener controller

    private int currentWaypoint = 0;

    private void Start()
    {
        tweener = FindFirstObjectByType<Tweener>();

        if (Waypoints == null || Waypoints.Length == 0)//to check if waypoint array is set
        {
            Debug.LogError("Waypoints are not assigned in PacStudentMovement");
            return;
        }
        transform.position = Waypoints[0].position;//position pacstudent at first waypoint of start
        StartCoroutine(MoveAlongWaypoints());

    }
    private IEnumerator MoveAlongWaypoints()
    {
        while (true)//infinite loop to keep pacstudent moving continuosly
        {
            int nextWaypoint = (currentWaypoint + 1) % Waypoints.Length;//determine the index of the next waypoint

            Vector3 startPos = Waypoints[currentWaypoint].position;
            Vector3 endPos = Waypoints[nextWaypoint].position;

            float distance = Vector3.Distance(startPos, endPos);//calculate thet distance between waypoints
            float duration = distance / Speed;

            Animator.SetBool("isMoving", true);//set the animation boolean to indicate if Pacstudent is moving

            if (MoveAudio != null && !MoveAudio.isPlaying)//play movement audio if available 
            {
                MoveAudio.Play();
            }

            tweener.AddTween(new Tween(transform, startPos, endPos, duration));//create and add a new tween to move PacStudent from start to end over the duration

            yield return new WaitForSeconds(duration);//wait for the movement duration before moving to the next waypoint

            currentWaypoint = nextWaypoint;//Update current waypoint index for the next loop iteration
            yield return null;

           

        }
    }
}