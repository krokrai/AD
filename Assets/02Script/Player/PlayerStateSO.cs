using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "PlayerCharacter/Char")]
public class PlayerStateSO : ScriptableObject
{
    public int characterID;
    public string characterName;
    public float characterHealth;
    public float characterDamage;
    public float characterMaxEnergy;
    public float characterUseEnergy;
    public float characterJumpPower;
    public float characterMoveSpeed;
    public float characterDashDistance;
    public float characterDashCoolDown;

    public void SetData(string[] datas)
    {
        if (datas == null || datas.Length < 10)
        {
            Debug.LogError("PlayerState에 들어갈 Data가 없거나 부족합니다.");
            return;
        }

        if (!int.TryParse(datas[1], out characterID))
            Debug.LogError("Character ID에 잘못된 값이 입력되었습니다.");

        characterName = datas[2];

        if (!float.TryParse(datas[3], out characterHealth))
            Debug.LogError("Character Heealth에 잘못된 값이 입력되었습니다.");

        if(!float.TryParse (datas[4],out characterDamage))
            Debug.LogError("Character Damage에 잘못된 값이 입력되었습니다.");

        if(!float.TryParse (datas[5],out characterMaxEnergy))
            Debug.LogError("Character MaxEnergy에 잘못된 값이 입력되었습니다.");

        if (!float.TryParse(datas[6], out characterUseEnergy))
            Debug.LogError("Character UseEnergy에 잘못된 값이 입력되었습니다.");

        if (!float.TryParse(datas[7],out characterJumpPower))
            Debug.LogError("Character JumpPower에 잘못된 값이 입력되었습니다.");

        if (!float.TryParse(datas[8],out characterMoveSpeed))
            Debug.LogError("Character MoveSpeed에 잘못된 값이 입력되었습니다.");

        if (!float.TryParse(datas[9],out characterDashDistance))
            Debug.LogError("Character DashPower에 잘못된 값이 입력되었습니다.");

        if (!float.TryParse(datas[10],out characterDashCoolDown))
            Debug.LogError("Character DashCoolDown에 잘못된 값이 입력되었습니다.");
    }
}
