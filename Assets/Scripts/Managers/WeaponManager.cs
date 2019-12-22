using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour {

    

    public static WeaponManager WM;
    public List<Weapon> Weapons = new List<Weapon>();
    public Text AmmoCounterGraphic;

    private Weapon _currentWeapon;

    private float weaponSwapTimer = 0;
    private float weaponSwapTimerRange = 0.3f;


    [Header("Testing variables")]
    public int CurrentWeapon = 0;

    private void Awake()
    {
        WM = this;
    }

    // Use this for initialization
    void Start () {
        Weapons[CurrentWeapon].gameObject.SetActive(true);
        _currentWeapon = Weapons[CurrentWeapon];
        UpdateAmmo(_currentWeapon.CurrentAmmo, _currentWeapon.MaxAmmo);
    }
	
	// Update is called once per frame
	void Update ()
    {
        weaponSwapTimer += Time.deltaTime;
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && weaponSwapTimer > weaponSwapTimerRange)
        {
            weaponSwapTimer = 0;
            ChangeWeapon(CurrentWeapon + 1);
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0 && weaponSwapTimer > weaponSwapTimerRange)
        {
            weaponSwapTimer = 0;
            ChangeWeapon(CurrentWeapon - 1);
        }
    }

    private void ChangeWeapon(int nextWeaponIndex)
    {
        if (nextWeaponIndex > Weapons.Count - 1) nextWeaponIndex = 0;
        if (nextWeaponIndex < 0) nextWeaponIndex = Weapons.Count - 1;

        CurrentWeapon = nextWeaponIndex;
        
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].gameObject.SetActive(false);
        }
        Weapons[CurrentWeapon].gameObject.SetActive(true);
        _currentWeapon = Weapons[CurrentWeapon];
        UpdateAmmo(_currentWeapon.CurrentAmmo, _currentWeapon.MaxAmmo);
        _currentWeapon._anim.Play(_currentWeapon._weaponPullOut.name);
    }

    public void UpdateAmmo(int currentAmmo, int maxAmmo)
    {
        AmmoCounterGraphic.text = (currentAmmo.ToString() + "/" + maxAmmo.ToString());
    }

    public void AddAmmo (int ammount)
    {
        _currentWeapon.CurrentAmmo += ammount;
        UpdateAmmo(_currentWeapon.CurrentAmmo, _currentWeapon.MaxAmmo);
    }
}
