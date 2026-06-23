using UnityEngine;

public class GeneratorRepair : MonoBehaviour
{
    public int repairCost = 10;
    public GameObject winCanvas;   // Drag your Win Canvas here

    private bool playerInRange = false;
    private int totalDeposited = 0;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Harvester harvester = FindFirstObjectByType<Harvester>();
            if (harvester != null && harvester.oreCount >= repairCost)
            {
                harvester.oreCount -= repairCost;
                totalDeposited += repairCost;

                if (totalDeposited >= 120 && winCanvas != null)
                {
                    winCanvas.SetActive(true);
                    Debug.Log("You Win!");
                    ;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }
}