using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using DG.Tweening;

public class SpaceRoverMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float movementSpeed = 5f; 

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex = 0;


    public void StartMovement(float speed)
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        movementSpeed = speed;
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
    }

    private void Update()
    {

        if (navMeshAgent.remainingDistance < 0.1f)
        {
            SetDestination();
        }

        RotateTowardsTarget();

    }

    private void SetDestination()
    {
        if (waypoints.Count > 0)
        {
            navMeshAgent.SetDestination(new Vector3(waypoints[currentWaypointIndex].position.x, transform.position.y, waypoints[currentWaypointIndex].position.z));
  
            navMeshAgent.speed = movementSpeed;

            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }

    private void RotateTowardsTarget()
    {
        if (navMeshAgent.velocity.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}
