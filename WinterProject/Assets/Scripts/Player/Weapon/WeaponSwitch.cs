using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public Player player;

    public int[] playerWeapons = new int[3];

    public int selectedWeaponTab;
    public int selectedWeaponList;


    public bool IsLightWeapon = true;
    public bool IsMediumWeapon = false;
    public bool IsHeavyWeapon = false;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        if(!IsMediumWeapon && !IsHeavyWeapon)
        {
            return;
        }

        int previousWeapon = selectedWeaponTab;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeaponTab >= 2)
            {
                selectedWeaponTab = 0;
            }
            else
            {
                selectedWeaponTab++;
            }

            
            //if there is not HeavyWeapon
            if (selectedWeaponTab >= 2 && !IsHeavyWeapon)
            {
                selectedWeaponTab = 0;
            }

            //if there is not MediumWeapon
            if (selectedWeaponTab == 1 && !IsMediumWeapon)
            {
                selectedWeaponTab = 2;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeaponTab <= 0)
            {
                selectedWeaponTab = 2;
            }
            else
            {
                selectedWeaponTab--;
            }

            //if there is not HeavyWeapon
            if (selectedWeaponTab >= 2 && !IsHeavyWeapon)
            {
                selectedWeaponTab = 1;
            }

            //if there is not MediumWeapon
            if (selectedWeaponTab == 1 && !IsMediumWeapon)
            {
                selectedWeaponTab = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && IsLightWeapon)
        {
            selectedWeaponTab = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && IsMediumWeapon)
        {
            selectedWeaponTab = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && IsHeavyWeapon)
        {
            selectedWeaponTab = 2;
        }



        if (previousWeapon != selectedWeaponTab)
        {
            selectedWeaponList = playerWeapons[selectedWeaponTab];
            SelectWeapon();
        }
       
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == selectedWeaponList)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void PickupWeapon(GameObject weaponType)
    {

        int i = 0;
        foreach (Transform weapon in transform)
        {

            if(weapon.tag == weaponType.tag)
            {
                if(weapon.GetComponent<LightGun>())
                {
                    playerWeapons[0] = i;
                    IsLightWeapon = true;
                }
                else if(weapon.GetComponent<MediumGun>())
                {
                    playerWeapons[1] = i;
                    IsMediumWeapon = true;
                }
                else if(weapon.GetComponent<HeavyGun>())
                {
                    playerWeapons[2] = i;
                    IsHeavyWeapon = true;
                }
                selectedWeaponList = playerWeapons[selectedWeaponTab];
                SelectWeapon();
                return;
            }
            i++;
        }

        
    }
}
