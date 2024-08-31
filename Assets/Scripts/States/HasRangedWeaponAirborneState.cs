using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static UnityEditor.VersionControl.Asset;

public class HasRangedWeaponAirborneState : State
{
    pickupAndEquip weapon;
    bool pistolEquipped;
    public State currentstate;


    public override void Enter()
    {
        isComplete = false;

        weapon = core.characterControl.GetComponent<pickupAndEquip>();
        pistolEquipped = weapon.equippedWeapon == pickupAndEquip.Weapon.pistol;

    }

    public override void Do()
    {
        currentstate = machine.state;
        SelectState();
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
    }

    void SelectState()
    {
        if (pistolEquipped)
        {
            machine.Set(core.characterControl.airbornePistolState);
        }

    }

}
