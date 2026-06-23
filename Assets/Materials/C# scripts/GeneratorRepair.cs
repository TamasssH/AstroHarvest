using UnityEngine;

public class GeneratorRepair : MonoBehaviour
{
    public int repairCost = 10;   // ores needed per repair

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Harvester harvester = FindFirstObjectByType<Harvester>();
            if (harvester != null && harvester.oreCount >= repairCost)
            {
                harvester.oreCount -= repairCost;
                Debug.Log("Ore deposited! Generator repaired.");
                
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