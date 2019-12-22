using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    /*
    [System.Serializable]
    public struct AudioSettings
    {
        public string Name;
        public GameObject AudioClip;
    }

    public List<AudioSettings> AudioList = new List<AudioSettings>();

    public Dictionary<string, GameObject> AudioSettingsDick = new Dictionary<string, GameObject>();
    */

    public List<GameObject> PossiblePrefabsToSpawn = new List<GameObject>();
    public float SpawnInterval = 0.25f;

    private void Start()
    {
        StartCoroutine(SpawnCourutine());
    }

    private void SpawnObject(GameObject objectToSpawn)
    {
        GameObject objectClone = Instantiate(objectToSpawn, transform.position, Quaternion.identity, transform);
    }

    private IEnumerator SpawnCourutine()
    {
        while (GameManager.GM.CurrentState == GameManager.GameState.Playing)
        {
            int randomIndex = Random.Range(0, PossiblePrefabsToSpawn.Count);

            SpawnObject(PossiblePrefabsToSpawn[randomIndex]);

            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}
