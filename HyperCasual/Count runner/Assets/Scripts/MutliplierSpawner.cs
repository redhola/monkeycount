using UnityEngine;

public class MutliplierSpawner : MonoBehaviour
{
    public GameObject followerPrefab; // Assign this in the inspector
    public int spawnMultiplier = 5; // Multiplier for followers to spawn, set this in the inspector
    public GameObject spawnera;
    public GameObject spawnerb;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger area
        if (other.CompareTag("Player"))
        {
            // Retrieve the total number of followers from the GameManager
            int totalFollowers = GameManager.Instance.followerCount;
            // Calculate the spawn count based on the total followers and multiplier from the inspector
            int spawnCount = totalFollowers * (spawnMultiplier - 1 );
            
            // Spawn the followers
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnFollower();
                GameManager.Instance.GainFollower(1);
            }

            // Optionally deactivate the spawner objects
            spawnera.SetActive(false);
            spawnerb.SetActive(false);
        }
    }

    void SpawnFollower()
    {
        // Calculate the spawn position behind the player
        Vector3 spawnPos = transform.position - transform.forward * 2; // Adjust as needed
        Quaternion spawnRot = Quaternion.identity; // Followers will face the original rotation
        Instantiate(followerPrefab, spawnPos, spawnRot);
    }
}
