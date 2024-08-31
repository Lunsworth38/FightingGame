using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupAndEquip : MonoBehaviour
{   
    public enum Weapon { bareHands, pistol };
    [SerializeField]public Weapon equippedWeapon;
    GameObject pistol;
    [SerializeField] GameObject pistolGameObject;
    characterControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        equippedWeapon = Weapon.bareHands;
        playerControlScript = GetComponent<characterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (equippedWeapon == Weapon.pistol)
        {
            pistolGameObject.SetActive(true);
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if (other.gameObject.name == "pistolPickUp")
        {
            equippedWeapon = Weapon.pistol;
            playerControlScript.equipRangedWeapon(true);
        }
    }
}
