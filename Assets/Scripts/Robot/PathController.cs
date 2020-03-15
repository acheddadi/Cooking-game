using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathController : MonoBehaviour
{
    private const bool FORWARD = true, REVERSE = false;
    [SerializeField] private float travelDuration = 2.0f;
    [SerializeField] private PathCreator robotPath;
    [SerializeField] [Range(0.0f, 1.0f)] private float[] pitStops;
    private VertexPath path;
    private int currentPitStop;
    private float currentTimeOnPath;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        path = robotPath.path;
        if (pitStops.Length > 0)
        {
            transform.position = path.GetPointAtTime(pitStops[0]);
            currentTimeOnPath = pitStops[0];
            currentPitStop = 0;
        }
        else Debug.LogError("No pit stops set!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 pathDirection = path.GetDirection(currentTimeOnPath);
            Vector3 directionToCheck = Vector3.Project(Camera.main.transform.forward, path.GetDirection(currentTimeOnPath));
            if (Vector3.Angle(pathDirection, directionToCheck) != 0.0f) SelectNextWaypoint(REVERSE);
            else SelectNextWaypoint(FORWARD);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 pathDirection = path.GetDirection(currentTimeOnPath);
            Vector3 directionToCheck = Vector3.Project(Camera.main.transform.forward, path.GetDirection(currentTimeOnPath));
            if (Vector3.Angle(pathDirection, directionToCheck) != 0.0f) SelectNextWaypoint(FORWARD);
            else SelectNextWaypoint(REVERSE);
        }
    }

    private void SelectNextWaypoint(bool direction)
    {
        int nextPitStop;
        bool isLastPitStop = false;
        if (!isMoving)
        {
            if (direction == FORWARD)
            {
                if (currentPitStop + 1 == pitStops.Length)
                {
                    nextPitStop = 0;
                    isLastPitStop = true;
                }
                else nextPitStop = currentPitStop + 1;
            }
            else
            {
                if (currentPitStop - 1 == -1)
                {
                    nextPitStop = pitStops.Length - 1;
                    isLastPitStop = true;
                } 
                else nextPitStop = currentPitStop - 1;
            }
            StartCoroutine(MoveTowards(nextPitStop, isLastPitStop, direction));
            Debug.Log(nextPitStop);
        }
    }

    private IEnumerator MoveTowards(int nextPitStop, bool isLastPitStop, bool direction)
    {
        isMoving = true;
        float t = 0.0f, initialTime = currentTimeOnPath;
        float finalTime = pitStops[nextPitStop];
        if (isLastPitStop)
        {
            if (direction == FORWARD) initialTime -= 1.0f;
            else finalTime -= 1.0f;
        }

        while (t < 1.0f)
        {
            currentTimeOnPath =  Mathf.SmoothStep(initialTime, finalTime, t);
            transform.position = path.GetPointAtTime(currentTimeOnPath);
            t += Time.deltaTime / travelDuration;
            yield return new WaitForEndOfFrame();
        }
        currentTimeOnPath = pitStops[nextPitStop];
        currentPitStop = nextPitStop;
        isMoving = false;
    }

    void OnDrawGizmosSelected()
    {
        if (robotPath != null)
        {
            foreach (float t in pitStops)
            {
                // Draw a yellow sphere at each pit stop.
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(robotPath.path.GetPointAtTime(t), 1);
            }
        }
    }
}
