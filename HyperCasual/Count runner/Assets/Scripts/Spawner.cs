using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject followerPrefab; // Assign this in the inspector
    public int spawnCount = 5; // Number of followers to spawn
    public GameObject spawnera;
    public GameObject spawnerb;

    // This function gets called when something enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger area
        if (other.CompareTag("Player"))
        {
            
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnFollower();
                GameManager.Instance.GainFollower(1);
            }
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
