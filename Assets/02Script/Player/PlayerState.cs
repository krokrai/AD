using UnityEngine;
using UnityEngine.Rendering;

public class PlayerState
{
    public int pID { get; private set; }
    public string pName { get; private set; }
    public float pMaxHealth { get; private set; }
    public float pCurrentHealth;
    public float pDamage { get; private set; }
    public float pMaxEnergy { get; private set; }
    public float pCurrentEnergy;
    public float pUseEnergy { get; private set; }
    public float pJumpPower { get; private set; }
    public float pMoveSpeed { get; private set; }
    public float pDashDistance { get; private set; }
    public float pDashCoolDown { get; private set; }

    public PlayerState(PlayerStateSO so)
    {
        pID = so.characterID;
        pName = so.name;
        pMaxHealth = so.characterHealth;
        pCurrentHealth = so.characterHealth;
        pDamage = so.characterDamage;
        pMaxEnergy = so.characterMaxEnergy;
        pCurrentEnergy = so.characterMaxEnergy;
        pUseEnergy = so.characterUseEnergy;
        pJumpPower = so.characterJumpPower;
        pMoveSpeed = so.characterMoveSpeed;
        pDashDistance = so.characterDashDistance;
        pDashCoolDown = so.characterDashCoolDown;
    }

    public void SetData(PlayerStateSO so)
    {
        pID = so.characterID;
        pName = so.name;
        pMaxHealth = so.characterHealth;
        pCurrentHealth = so.characterHealth;
        pDamage = so.characterDamage;
        pMaxEnergy = so.characterMaxEnergy;
        pCurrentEnergy = so.characterMaxEnergy;
        pUseEnergy = so.characterUseEnergy;
        pJumpPower = so.characterJumpPower;
        pMoveSpeed = so.characterMoveSpeed;
        pDashDistance = so.characterDashDistance;
        pDashCoolDown = so.characterDashCoolDown;
    }
}
