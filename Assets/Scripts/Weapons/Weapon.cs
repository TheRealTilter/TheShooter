using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    public GameObject ProjectilePrefab;
    public Transform FiringPoint;
    public float Power = 10;
    public int CurrentAmmo;
    public int MaxAmmo;
    public float Damage;
    

    protected GameObject _bulletBox;
    [Header("PRIVATE")]
    [SerializeField]
    protected float _fireRate = 0.2f;
    [SerializeField]
    protected float _firingTimer = 1f;

    protected AudioSource _audioSource;
    public Animator _anim;

    [SerializeField]
    public AnimationClip _weaponPullOut;
    [SerializeField]
    public AnimationClip _weaponStore;

    private void Awake()
    {
        _bulletBox = new GameObject("BulletBox");
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _firingTimer += Time.deltaTime;

        if (Input.GetButton("Fire1") && (_firingTimer > _fireRate) && CurrentAmmo > 0)
        {
            Fire();
            if (_audioSource)
            {
                _audioSource.Play();
            }
            WeaponManager.WM.UpdateAmmo(CurrentAmmo, MaxAmmo);
        }
        if (Input.GetButton("Fire2") && (_firingTimer > _fireRate) && CurrentAmmo > 0)
        {
            AltFire();
            _audioSource.Play();
            WeaponManager.WM.UpdateAmmo(CurrentAmmo, MaxAmmo);
        }
    }

    public virtual void AltFire()
    {
        throw new NotImplementedException();
    }

    public virtual void Fire()
    {
        throw new NotImplementedException();
    }
}
