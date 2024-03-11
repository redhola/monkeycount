using UnityEngine;
using UnityEngine.AI; // Required for manipulating NavMeshAgent


public class PlayerTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoadFollower"))
        {
            // Implement logic for the follower to start following the player
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
            // GameManager.Instance.GainFollower(1);
            if (agent != null && !agent.enabled)
            {
                agent.enabled = true; 
                agent.SetDestination(transform.position);
                GameManager.Instance.GainFollower(1);
            }
        }
        if (other.CompareTag("Obstacle"))
        {
            GameManager.Instance.LoseFollower(5);
        }
    }
}
