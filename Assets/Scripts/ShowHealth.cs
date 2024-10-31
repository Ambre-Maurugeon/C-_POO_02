using UnityEngine;
using UnityEngine.UI;
//using System;

public class ShowHealth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _health.OnTakeDamage += ShowSlider;
        _health.OnHeal += ShowSlider;
        _slider.maxValue = _health.currentHealth;
        _slider.value = _health.currentHealth;
    }

    
    private void OnDestroy(){
        _health.OnTakeDamage -= ShowSlider;
    }

    private void ShowSlider(int amount){
        _slider.value = _health.currentHealth;
    }
}
