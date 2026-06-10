using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeapon = 0;

    void Start()
    {
        SwitchToWeapon(0);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentWeapon = (currentWeapon == 0) ? 1 : 0;
            SwitchToWeapon(currentWeapon);
        }
    }

    void SwitchToWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i]) weapons[i].SetActive(i == index);
        }
    }
}