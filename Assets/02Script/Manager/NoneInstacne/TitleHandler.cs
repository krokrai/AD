using UnityEditor;
using UnityEngine;

public class TitleHandler : MonoBehaviour
{
    [SerializeField] GameObject mainTitle;
    [SerializeField] GameObject stageSelect;
    [SerializeField] GameObject characterSelect;

    private void Awake()
    {
        mainTitle.SetActive(true);
        stageSelect.SetActive(false);
        characterSelect.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainTitleToStageSelect()
    {
        mainTitle.SetActive(false);
        stageSelect.SetActive(true);
    }

    public void StageSelectToMainTitle()
    {
        mainTitle.SetActive(true);
        stageSelect.SetActive(false);
    }

    public void StageSelectToCharacterSelect(int stageNum)
    {
        GameController.instance.StageSelect(stageNum);
        stageSelect.SetActive(false);
        characterSelect.SetActive(true);
    }

    public void CharacterSelectToStageSelect()
    {
        stageSelect.SetActive(true);
        characterSelect.SetActive(false);
    }
}
