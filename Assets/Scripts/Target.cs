using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public int ScoreValue = 5;
    public float TimeValue = 5.0f;

    public ParticleSystem ExplosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (!(GameManager.GM.CurrentState == GameManager.GameState.GameOver ))
        {
            if (other.gameObject.tag == "Projectile")
            {
                GameManager.GM.AddScore(ScoreValue);
                GameManager.GM.TimerValue += TimeValue;

                if(ExplosionPrefab)
                {
                    Instantiate(ExplosionPrefab, transform.position, transform.rotation);
                }

                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
