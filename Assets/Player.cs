using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private GameObject rightArm;
    [SerializeField] private GameObject weaponEquipLocation;
    private GameObject weapon;


	// Use this for initialization
	void Start () {
        weapon = null;
	}

    public void equipWeapon(GameObject weaponObj)
    {
        // no weapon equiped
        if (weapon == null)
        {
            weapon = weaponObj;
            //weapon.transform.Find("EquipLocation").transform.position = weaponEquipLocation.transform.position;
            weaponObj.transform.position = weaponEquipLocation.transform.position;
            weapon.transform.parent = weaponEquipLocation.transform;
            weapon.transform.position = new Vector3(weapon.transform.position.x, weapon.transform.position.y + 0.3f, weapon.transform.position.z);
            
        } else // we have a weapon equipped already
        {

        }
    }
}
