using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageHitboxes : MonoBehaviour
{
    [SerializeField] GameObject punchHitbox;
    [SerializeField] GameObject secondPunchHitbox;
    [SerializeField] GameObject kickHitbox;
    [SerializeField] GameObject chargedKickHitbox;

    [SerializeField] GameObject flyingKickHitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void activatePunchHitbox()
    {
        punchHitbox.GetComponent<HitBox>().setIsActive(true);
    }
    void deactivatePunchHitbox()
    {
        punchHitbox.GetComponent<HitBox>().setIsActive(false);
    }

    void activateSecondPunchHitbox()
    {
        secondPunchHitbox.GetComponent<HitBox>().setIsActive(true);
    }
    void deactivateSecondPunchHitbox()
    {
        punchHitbox.GetComponent<HitBox>().setIsActive(false);
    }

    void activateKickHitbox()
    {
        kickHitbox.GetComponent<HitBox>().setIsActive(true);
    }
    void deactivateKickHitbox()
    {
        kickHitbox.GetComponent<HitBox>().setIsActive(false);
    }

    void activateChargedKickHitbox()
    {
        chargedKickHitbox.GetComponent<HitBox>().setIsActive(true);
    }
    void deactivateChargedKickHitbox()
    {
        chargedKickHitbox.GetComponent<HitBox>().setIsActive(false);
    }

    void activateFlyingKickHitbox()
    {
        flyingKickHitbox.SetActive(true);
    }
    public void deactivateFlyingKickHitbox()
    {
        flyingKickHitbox.SetActive(false);
    }
}
