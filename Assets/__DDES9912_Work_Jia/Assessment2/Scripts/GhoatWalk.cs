using UnityEngine;
using UnityEngine.Events;

public class GhostWalk : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    public float arriveDistance = 0.1f;
    public float waitTime = 2f;

    [Tooltip("Which waypoint index is in front of the button (0-based).")]
    public int buttonPointIndex = 0;

    [Tooltip("Events to fire when the ghost reaches the button waypoint.")]
    public UnityEvent onReachButtonPoint;

    private int currentIndex = 0;
    private bool isWaiting = false;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        if (isWaiting) return;

        Transform target = waypoints[currentIndex];

        Vector3 dir = target.position - transform.position;
        Vector3 move = dir.normalized * speed * Time.deltaTime;
        if (move.magnitude > dir.magnitude)
            move = dir;

        transform.position += move;

        if (dir.sqrMagnitude > 0.001f)
            transform.forward = dir.normalized;

        if (dir.magnitude <= arriveDistance)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    System.Collections.IEnumerator WaitAtPoint()
    {
        isWaiting = true;

        // If this waypoint is the one in front of the button, fire the event
        if (currentIndex == buttonPointIndex && onReachButtonPoint != null)
        {
            Debug.Log("[GhostWalk] Reached button waypoint, invoking onReachButtonPoint");
            onReachButtonPoint.Invoke();
        }

        yield return new WaitForSeconds(waitTime);

        currentIndex++;
        if (currentIndex >= waypoints.Length)
            currentIndex = 0;

        isWaiting = false;
    }
}
