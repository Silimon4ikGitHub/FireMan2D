using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Color low;
    [SerializeField] private Color hight;
    [SerializeField] private Vector3 offset;
    
    
        void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    
    public void SetHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = health;
        slider.maxValue = maxHealth;

        //slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, hight, slider.normalizedValue);

    }
}
