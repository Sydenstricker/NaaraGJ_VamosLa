using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    public Transform parentWay;
    public float speedMove = 5f;
    List<Transform> waypoints = new List<Transform>();
    int waypointIndex = 0;
    void Start()
    {
        Transform[] transformsArray = parentWay.GetComponentsInChildren<Transform>();

        for(int i = 0; i < transformsArray.Length; i++)
        {
            if(transformsArray[i] != parentWay)
            {
                waypoints.Add(transformsArray[i]);
            }
        }
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
        
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = speedMove * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
            //Destroy(gameObject);
        }
    }
}
