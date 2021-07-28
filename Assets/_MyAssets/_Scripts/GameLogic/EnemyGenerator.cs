using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] float mfTimeBetweenWaves = 10;
    [SerializeField] int miEnemiesPerWaves = 5;


    [SerializeField] GameObject mEnemyPrefab;
    [SerializeField] float mfSpawnRadius = 50f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateWave", mfTimeBetweenWaves, mfTimeBetweenWaves);
    }

    void GenerateWave()
    {

        for (int i = 0; i < miEnemiesPerWaves; i++)
        {

            Vector2 lRandomPoint2D = Random.insideUnitCircle;

            Vector3 lRandomPoint = new Vector3(lRandomPoint2D.x, 0, lRandomPoint2D.y);
            lRandomPoint.Normalize();
            Vector3 lvSpawnPoint = this.transform.position + lRandomPoint * mfSpawnRadius;

            Instantiate(mEnemyPrefab, lvSpawnPoint, Quaternion.identity);

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, mfSpawnRadius);
    }

}
