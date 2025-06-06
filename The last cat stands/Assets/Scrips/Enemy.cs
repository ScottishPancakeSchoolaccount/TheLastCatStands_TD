using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

     void Start()
    {
        //Referencing the points array in the Waypoints script
        target = Waypoints.points[0];
    }
     void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
    
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        void GetNextWaypoint()
        {
            if ( (wavepointIndex >= Waypoints.points.Length - 1) ) 
            {
                Destroy(gameObject);
                return; // This prevents the code to go further until the gameObject is destroyed
            }
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }


    }   
}
