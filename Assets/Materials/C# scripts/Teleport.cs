using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform targetSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teleport triggered!");

            if (targetSpawnPoint != null)
            {
                CharacterController cc = other.GetComponent<CharacterController>();
                if (cc != null) cc.enabled = false;

                other.transform.position = targetSpawnPoint.position;
                other.transform.rotation = targetSpawnPoint.rotation;

                if (cc != null) cc.enabled = true;

                Debug.Log("Player teleported to: " + targetSpawnPoint.position);
            }
        }
    }
}