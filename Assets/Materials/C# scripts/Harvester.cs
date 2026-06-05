using UnityEngine;

public class Harvester : MonoBehaviour
{
    public float range = 3f;
    public LayerMask oreLayer;
    public int oreCount = 0;

    private float harvestTimer = 0f;

    void Update()
    {
        bool harvesting = false;

        if (Input.GetMouseButton(0))
        {
            Camera cam = Camera.main;
            if (cam == null) return; // Fix for null camera

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, range, oreLayer) &&
                hit.collider != null && hit.collider.CompareTag("Ore"))
            {
                harvesting = true;
            }
        }

        if (harvesting)
        {
            harvestTimer += Time.deltaTime;
            if (harvestTimer >= 1f)
            {
                oreCount += Random.Range(1, 4);
                harvestTimer = 0f;
            }
        }
        else
        {
            harvestTimer = 0f;
        }
    }
}