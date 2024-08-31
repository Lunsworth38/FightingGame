using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class animationScript : MonoBehaviour
{
   
    Animator animator;
    GameObject parent;
    
    [SerializeField] GameObject punchCollider;
    public GameObject playerBase;
    pickupAndEquip.Weapon? equippedWeapon;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        parent = transform.parent.gameObject;
        equippedWeapon = playerBase.GetComponent<pickupAndEquip>().equippedWeapon;


}

// Update is called once per frame
void Update()
    {
        
        characterControl ctrl = parent.GetComponentInChildren<characterControl>();
        
        equippedWeapon = playerBase.GetComponent<pickupAndEquip>().equippedWeapon;


        Debug.Log(equippedWeapon);
        switch (equippedWeapon)
        {
           case pickupAndEquip.Weapon.pistol:
            animator.SetBool("hasPistol", true);
            break;
        }
    }

}
