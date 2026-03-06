using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JamSelecter : MonoBehaviour
{
    [SerializeField] GameObject selecter;
    [SerializeField] Image[] target;
    [SerializeField] Jams[] jams;
    [SerializeField] TextMeshProUGUI description;

    int selectTarget;

    private void Start()
    {
        description.SetText("");
    }

    // TODO : 플레이어 스텟 부분 완성 시 추가 수정 필요.
    // 현재 스프라이트 와 설명만 뜨게 만들어져있음.
    // - 적용한 jam 정보와 갯수를 넘겨줘서 스텟에 추가 필요.

    public void Select(int ID)
    {
        if (!selecter.activeSelf)
            selecter.SetActive(true);
        else if (selectTarget == ID)
            selecter.SetActive(false);
        selectTarget = ID;
    }

    public void ChangeSprite(int ID)
    {
        target[selectTarget].sprite = jams[ID].image;
        GameController.instance.ItemSelect(selectTarget, ID);
        description.SetText($"{jams[ID].description[0]}\n{jams[ID].description[1]}");
    }
}
