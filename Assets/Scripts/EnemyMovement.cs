using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target; // Location of waypoint
    private int waypointIndex; // The order of waypoint

    private Enemy enemy;

    private bool pathNested = false;

    void Start()
    {
        enemy = GetComponent<Enemy>();

        target = Waypoints.points[0];
    }

    void Update()   
    {
        Vector3 dir = target.position - transform.position; // Find the direction of movement needed
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World); // Move the target accordingly
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // transform.LookAt(target);

        // Follow the next waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        // Destroy the enemy if it reaches the ENDPOINT
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
        }

        else
        {
            // Move the target to the next waypoint
            waypointIndex++;
            target = Waypoints.points[waypointIndex];

            //if (target.childCount > 0)
            //{
            //    pathNested = true;
            //    int path = Random.Range(0, target.childCount - 1);
            //    target = Waypoints.points[waypointIndex].GetChild(path);
            //}
            //else
            //{   
            //    if (pathNested)
            //    {

            //    }
            //    else
            //    {
            //        // Move the target to the next waypoint
            //        waypointIndex++;
            //        target = Waypoints.points[waypointIndex];
            //    }
                
            //}


        }

    }


    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }
}
