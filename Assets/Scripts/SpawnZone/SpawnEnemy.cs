using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _spawnDelay;

    private List<Transform> _spawnPoints = new List<Transform>();

    private void Start()
    {
        _spawnPoints.AddRange(GetComponentsInChildren<Transform>());

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        bool isWork = true;

        Instantiate(_enemyPrefab,new Vector3(0,0,0), Quaternion.identity);

        while (isWork)
        {
            for (int i = 0; i < _spawnPoints.Count; i++)
            {
                Instantiate(_enemyPrefab, _spawnPoints[i].transform.position, Quaternion.identity);

                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}
