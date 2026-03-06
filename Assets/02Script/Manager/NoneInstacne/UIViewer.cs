using UnityEngine;
using UnityEngine.UI;

public class UIViewer : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Slider energySlider;
    [SerializeField] Slider lifeSlider;
    [SerializeField] Slider bossHPSlider;

    public void SetHpSlider(float value) => hpSlider.value = value;

    public void SetEnergySlider(float value) => energySlider.value = value;
    
    public void SetLifeSlider(float value) => lifeSlider.value = value;

    public void SetBossHPSlider(float value) => bossHPSlider.value = value;
}
