using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    


    [Header("These are private")]
    [SerializeField]
    private float _currentHealthPoints = 100.0f;
    [SerializeField]
    private float _maxHealthPoints = 200.0f;

    private Animator _anim;

    // Use this for initialization
    void Start () {
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// if current damage instance kills
    /// typeOfDeath should be 0 or 1
    /// 0 - normal death
    /// 1 - gruesome death
    /// </summary>
    /// <param name="typeOfDeath"></param>
    public void TakeDamage(float amount, int typeOfDeath)
    {
        _currentHealthPoints -= amount;
        if (_currentHealthPoints <= 0)
        {
            Death(typeOfDeath);
        }
    }

    private void Death(int typeOfDeath)
    {
        switch (typeOfDeath)
        {
            case 0:
                _anim.Play("NormalDeath");
                break;
            case 1:
                _anim.Play("GruesomeDeath");
                break;
            default:
                _anim.Play("NormalDeath");
                break;
        }

    }
}
