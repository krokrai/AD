using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] UIViewer viewer;
    [SerializeField] PlayerController pController;
    [SerializeField] StagOneController stageCtrl;
    [SerializeField] BossController bossCtrl;

    private void OnEnable()
    {
        pController.OnHPValueChanged += viewer.SetHpSlider;
        pController.OnEnergyValueChanged += viewer.SetEnergySlider;
        stageCtrl.OnLifeChanged += viewer.SetLifeSlider;
        bossCtrl.OnBossHealthChanged += viewer.SetBossHPSlider;
    }

    private void OnDisable()
    {
        pController.OnHPValueChanged -= viewer.SetHpSlider;
        pController.OnEnergyValueChanged -= viewer.SetEnergySlider;
        stageCtrl.OnLifeChanged -= viewer.SetLifeSlider;
        bossCtrl.OnBossHealthChanged -= viewer.SetBossHPSlider;
    }
}
