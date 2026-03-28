using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHP(float hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }

    public void SetHP(float hp)
    {
        slider.value = hp;
    }
}