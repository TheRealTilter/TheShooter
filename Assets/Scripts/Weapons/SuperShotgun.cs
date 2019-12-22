using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShotgun : RaycastWeapon {

    [SerializeField]
    private bool _firstShot = true;
    private bool _emptyClip;

    
    public override void Fire()
    {
        _audioSource.pitch = 1f;
        Ray shot = new Ray(FiringPoint.transform.position, FiringPoint.transform.forward);
        RaycastHit shotHit;
        Physics.Raycast(shot, out shotHit);

        if(_firstShot)
        {
            _fireRate = 0.1f;
            _firstShot = false;
            _anim.Play("SuperShotgunRightMuzzleFlash");
            Debug.Log("I am first shot");
            DealDamage(Damage, shotHit, 1);
            CurrentAmmo -= 1;
            _firingTimer = 0.0f;
        }
        else
        {
            _fireRate = 2;
            _firstShot = true;
            _anim.Play("SuperShotgunLeftMuzzleFlash");
            Debug.Log("I am second shot");
            DealDamage(Damage, shotHit, 1);
            CurrentAmmo -= 1;
            _firingTimer = 0.0f;
        }
    }

    public override void AltFire()
    {
        Ray shot = new Ray(FiringPoint.transform.position, FiringPoint.transform.forward);
        RaycastHit shotHit;
        Physics.Raycast(shot, out shotHit);
        if (_firstShot)
        {
            _fireRate = 2f;
            _audioSource.pitch = 0.75f;
            //Debug.Log("I just hit tag: " + shotHit.transform.tag);
            _firingTimer = 0.0f;
            CurrentAmmo -= 2;
            //_anim["SuperShotgunShot"].layer = 123;
            _anim.Play("SuperShotgunDoubleMuzzleFlash");
            DealDamage(Damage * 2, shotHit, 1);
        }
        else
        {
            _audioSource.pitch = 1f;
            _fireRate = 2;
            _firstShot = true;
            _anim.Play("SuperShotgunLeftMuzzleFlash");
            Debug.Log("I am second shot");
            DealDamage(Damage, shotHit, 1);
            CurrentAmmo -= 1;
            _firingTimer = 0.0f;
        }
    }

}