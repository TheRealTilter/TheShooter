using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedeemerMissile : Projectile {

    public Camera MissileCamera;
    public GameObject Explosion;
    public AudioSource PlayerAudioSource;

    private MeshRenderer mesh;

    bool _exploded = false;

    private void Start()
    {
        mesh = this.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (!_exploded)
        {
            this.transform.Translate(Vector3.forward * 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Weapon")
        {
            StartCoroutine(ExplosionCor());
            other.GetComponent<TargetDummyScript>().WriteDamage(Damage);
        }
    }


    public IEnumerator ExplosionCor()
    {
        _exploded = true;

        mesh.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        if (Redeemer.StaticRedeem.RedeemerAlt == true)
        {
            Redeemer.StaticRedeem.ReverseCameras();
            Redeemer.StaticRedeem.RedeemerAlt = false;
        }

        GameObject explosion = Instantiate(Explosion, this.transform.position, Quaternion.identity);

        AreaDamageEnemies(transform.position, 14, 250);

        yield return new WaitForSeconds(3.9f);
        Destroy(explosion);
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
        foreach (Collider col in objectsInRange)
        {
            EnemyHealth enemy = col.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage, 1);
            }
        }

    }
}