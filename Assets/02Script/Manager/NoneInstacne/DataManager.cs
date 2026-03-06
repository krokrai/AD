using UnityEngine;
using System.Collections.Generic;

public class DataManager : MonoBehaviour
{
    [SerializeField]SpreadsheetReader SsheetReader;
    [SerializeField] List<PlayerStateSO> PlayerStates;
    [SerializeField] List<EnemyStateSO> EnemyStates;
    [SerializeField] List<Jams> JamStates;

    [SerializeField] List<string> Urls; // 보스는 미등록 상태 후에 추가 필요.

    void Start()
    {
        if( !GameController.instance.isDataReaded)
        {
            // 시간이 부족하니 하드 코딩으로 대체
            SsheetReader.Url = Urls[0];
            StartCoroutine(SsheetReader.Load(SetPlayerData));

            SsheetReader.Url = Urls[1];
            StartCoroutine(SsheetReader.Load(SetEnemyDatas));

            // FIXME :  작동 실패 예외 처리 재작업 시 수정 필요
            //SsheetReader.Url = Urls[2];
            //StartCoroutine(SsheetReader.Load(SetJamDatas));

            GameController.instance.DataReadedInvoke();
        }
    }

    // 후에 인터페이스나 추상 클래스로 묶어서 작업 필요.
    public void SetEnemyDatas(char splitSymbol, string[] lines)
    {
        if (lines == null)
        {
            Debug.LogError("스프레드 시트에서 입력된 데이터 없음.");
            return;
        }

        for (int i = 2; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split(splitSymbol);

            EnemyStateSO player;

            for (int j = 0; j < EnemyStates.Count; j++)
            {
                if (EnemyStates[j].name == cols[0])
                {
                    EnemyStates[j].SetData(cols);
                    Debug.Log($"성공적으로 {cols[0]}이 추가됌");
                    break;
                }
                else if (j == EnemyStates.Count - 1)
                {
                    // 권장하지 않지만 임시로(project에 생성되지않는) SO 생성
                    player = ScriptableObject.CreateInstance<EnemyStateSO>();
                    player.name = cols[0];
                    player.SetData(cols);
                    EnemyStates.Add(player);
                    Debug.LogWarning($"<color=yellow>MonsterSO 누락, {cols[0]} 추가됌.</color> ");
                }
            }
        }
    }

    public void SetJamDatas(char splitSymbol, string[] lines)
    {
        if (lines == null)
        {
            Debug.LogError("스프레드 시트에서 입력된 데이터 없음.");
            return;
        }

        for (int i = 2; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split(splitSymbol);
            Jams player;
            for (int j = 0; j < JamStates.Count; j++)
            {
                if (JamStates[j].name == cols[0])
                {
                    JamStates[j].SetData(cols);
                    Debug.Log($"성공적으로 {cols[0]}이 추가됌");
                    break;
                }
                else if (j == JamStates.Count - 1)
                {
                    // 권장하지 않지만 임시로(project에 생성되지않는) SO 생성
                    player = ScriptableObject.CreateInstance<Jams>();
                    player.name = cols[0];
                    player.SetData(cols);
                    JamStates.Add(player);
                    Debug.LogWarning($"<color=yellow>MonsterSO 누락, {cols[0]} 추가됌.</color> ");
                }
            }
        }
    }

    public void SetPlayerData(char symbol,string[] lines)
    {
        for (int i = 2; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split(symbol);

            PlayerStateSO player;
            
            for (int j = 0; j < PlayerStates.Count; j++)
            {
                if (PlayerStates[j].name == cols[0])
                {
                    PlayerStates[j].SetData(cols);
                    Debug.Log($"성공적으로 {cols[0]}이 추가됌");
                    break;
                }
                else if (j == PlayerStates.Count-1)
                {
                    // 권장하지 않지만 임시로(project에 생성되지않는) SO 생성
                    player = ScriptableObject.CreateInstance<PlayerStateSO>();
                    player.name = cols[0];
                    player.SetData(cols);
                    PlayerStates.Add(player);
                    Debug.LogWarning($"<color=yellow>MonsterSO 누락, {cols[0]} 추가됌.</color> ");
                }
            }
        }
    }
}
