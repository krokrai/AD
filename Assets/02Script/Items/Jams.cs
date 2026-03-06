using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Jam", menuName = "Items/Jam")]
public class Jams : ScriptableObject
{
    [Header("기본 설정")]
    public int jamID;
    public string jamName;
    public string[] description;

    [Header("이미지 변경")]
    public Sprite image;

    [Header("보정치")]
    public float modify1;
    public float modify2;

    public void SetData(string[] datas)
    {
        if (datas == null || datas.Length < 8)
        {
            Debug.LogError("Jams에 들어갈 Data가 없거나 부족합니다.");
            return;
        }

        if (!int.TryParse(datas[1], out jamID))
            Debug.LogError("Character ID에 잘못된 값이 입력되었습니다.");

        jamName = datas[2];

        for ( int i = 0; i < 2; i++ )
        {
            for (int j = 0; j < datas.Length; j++ )
            {
                if (datas[j] == "")
                    continue;
                if (i == 0)
                {
                    float.TryParse(datas[j], out modify1);
                    break;
                }
                else
                {
                    float.TryParse(datas[j], out modify2);
                    break;
                }
            }
        }
    }
}
