using UnityEngine;
using TMPro; 

public class Harvester : MonoBehaviour
{
    public float range = 3f;
    public LayerMask oreLayer;
    public int oreCount = 0;

    public TextMeshProUGUI oreText;

    private float harvestTimer = 0f;

    void Update()
    {
        bool harvesting = false;

        if (Input.GetMouseButton(0))
        {
            Camera cam = Camera.main;
            if (cam == null) return;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, range, oreLayer) &&
                hit.collider != null && hit.collider.CompareTag("Ore"))
            {

                harvesting = true;
                harvestTimer += Time.deltaTime;

                if (harvestTimer >= 1f)
                {
                    oreCount += 20;
                    Destroy(hit.collider.gameObject);
                    harvestTimer = 0f;
                }
            }
        }

        if (!harvesting) harvestTimer = 0f;

        if (oreText) oreText.text = "Ore: " + oreCount;
    }
}