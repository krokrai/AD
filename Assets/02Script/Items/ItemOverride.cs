using UnityEngine;
using UnityEngine.UI;

public class ItemOverride : MonoBehaviour
{
    [SerializeField]Jams jam;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        image.sprite = jam.image;
    }
}
