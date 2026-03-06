using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(fileName = "EnemyStateSO", menuName = "Enemys/CommonEnemyStateSO")]
public class EnemyStateSO : ScriptableObject
{
    public int commonEnemyID;
    public string commonEnemyName;
    public float commonEnemyHealth;
    public float commonEnemyDamage;
    public int commonEnemyMaxAttackCounte;
    public float commonEnemyMoveSpeed;
    public bool commonEnemyCanFly;

    public void SetData(string[] datas)
    {
        if (datas == null || datas.Length < 7)
        {
            Debug.LogError("EnemyStateSO에 들어갈 Data가 없거나 부족합니다.");
            return;
        }

        if (!int.TryParse(datas[1], out commonEnemyID))
            Debug.LogError("Enemy ID에 잘못된 값이 입력되었습니다.");

        commonEnemyName = datas[2];

        if (!float.TryParse(datas[3], out commonEnemyHealth))
            Debug.LogError("Enemy Heealth에 잘못된 값이 입력되었습니다.");

        if (!float.TryParse(datas[4], out commonEnemyDamage))
            Debug.LogError("Enemy Damage에 잘못된 값이 입력되었습니다.");

        if (!int.TryParse(datas[5], out commonEnemyMaxAttackCounte))
            Debug.LogError("Enemy MaxEnergy에 잘못된 값이 입력되었습니다.");

        if (!float.TryParse(datas[6], out commonEnemyMoveSpeed))
            Debug.LogError("Enemy UseEnergy에 잘못된 값이 입력되었습니다.");

        switch(datas[7])
        {
            case "FALSE":
                commonEnemyCanFly = false;
                break;
            case "TRUE":
                commonEnemyCanFly = true;
                break;
            default:
                Debug.LogError("Enemy CanFly에 잘못된 값이 입력되었습니다.");
                break;
        }
    }
}
