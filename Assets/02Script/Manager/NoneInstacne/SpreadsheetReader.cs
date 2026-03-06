using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public enum SheetType
{
    CSV, TSV
}

[System.Serializable]
public struct SpreadsheetReader
{
    [field: SerializeField] public string Url;
    [field: SerializeField] public SheetType Type { get; private set; }
    public char splitSymbol => Type == SheetType.CSV ? ',' : '\t';

    public IEnumerator Load(Action<char, string[]> SuccessCallback) //, Action FailureCallback) 실패 했을 때 게임에 대한 예외처리 사항을 등록해야 할때.
    {
        // 1. url 자르기
        string sheetId = Url.Split("d/")[1].Split('/')[0];
        string gid = Url.Split("gid=")[1].Split('&')[0].Split('#')[0];

        string format = Type == SheetType.CSV ? "csv" : "tsv";

        // 2. tsv로 받아오기
        string exprotUrl = $"https://docs.google.com/spreadsheets/d/{sheetId}/export?format={format}&gid={gid}";

        // 3. 웹 요청
        using (UnityWebRequest uwr = UnityWebRequest.Get(exprotUrl))
        {
            // 3.1 요청 보내고 응답까지 대기
            yield return uwr.SendWebRequest();

            // 3.2. 실패라면 에러 발생.
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(uwr.error);
                //FailureCallback?.Invoke();
                yield break;
            }

            // 3.3. 성공적으로 받아 왔으면 데이터 반영하기
            string sheetDataText = uwr.downloadHandler.text;
            string[] lines = sheetDataText.Split('\n');

            SuccessCallback?.Invoke(splitSymbol, lines);

            Debug.Log("<color=green>스프레드 시트 읽기 성공적.</color>");
        }
    }
}
