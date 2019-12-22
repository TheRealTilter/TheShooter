using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    public Slider HealthSliderGraphic;


    [Header("These are private")]
    [SerializeField]
    private float _currentHealthPoints = 100.0f;
    [SerializeField]
    private float _maxHealthPoints = 200.0f;



    //Properties
    //Might remove some setting functionality later if not needed outside this class
    public float HealthPoints
    {
        get { return _currentHealthPoints; }
        set { _currentHealthPoints = value; }
    }

    private void Start()
    {
        UpdateHealth();
    }

    public void HealFor(float healAmount)
    {
        _currentHealthPoints += healAmount;
        if (_currentHealthPoints > _maxHealthPoints)
        {
            _currentHealthPoints = _maxHealthPoints;
        }

        UpdateHealth();
    }

    public void UpdateHealth()
    {
        HealthSliderGraphic.value = _currentHealthPoints / _maxHealthPoints;
    }
}
