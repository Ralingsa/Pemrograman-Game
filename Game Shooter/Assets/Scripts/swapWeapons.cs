using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swapWeapons : MonoBehaviour
{
    int selectWeapon = 1;
    public GameObject ak47, shotgun;

    void switchWeapon(int tipeSenjata)
    {
        if (tipeSenjata == 1)
        {
            ak47.SetActive(true);
            shotgun.SetActive(false);
            selectWeapon = 1;
        }
        if (tipeSenjata == 2)
        {
            ak47.SetActive(false);
            shotgun.SetActive(true);
            selectWeapon = 2;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        switchWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (selectWeapon != 1)
            {
                switchWeapon(1);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (selectWeapon != 2)
            {
                switchWeapon(2);
            }
        }
    }
}
