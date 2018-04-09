using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IWeapon))]
public class PlayerInventory : MonoBehaviour
{

    public IWeapon[] inventroy;
    public int InventorySlots = 4;
    public int ActiveSlot;

    private void Start()
    {
        inventroy = new IWeapon[InventorySlots];
        inventroy[0] = GetComponent<IWeapon>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ActiveSlot = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2) && inventroy[1] != null)
            ActiveSlot = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3) && inventroy[2] != null)
            ActiveSlot = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4) && inventroy[3] != null)
            ActiveSlot = 3;
    }

    public bool AddWeapon(System.Type _WeaponToAdd)
    {
        int i;
        if ((i = CheckInventory()) != -1)
        {
            foreach (IWeapon weapon in inventroy)
            {
                if (weapon.GetType() != _WeaponToAdd)
                {           
                    inventroy[i] = (IWeapon)gameObject.AddComponent(_WeaponToAdd);
                    return true;
                }
            }
        }
        return false;
    }

    private int CheckInventory()
    {
        for (int i = 0; i < inventroy.Length; i++)
        {
            if (inventroy[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

}
