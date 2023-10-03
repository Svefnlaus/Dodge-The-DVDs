using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] protected int spawnCount;
    [SerializeField] private DVDSign sign;
    [SerializeField] private Transform[] spawnPoint;

    private DVDSign[] spawnedSigns;

    private void Awake()
    {
        spawnedSigns = new DVDSign[spawnCount];
        for (int i = 0; i < spawnCount; i++)
        {
            int point = Random.Range(0, spawnPoint.Length);
            spawnedSigns[i] = Instantiate(sign, spawnPoint[point]);
            spawnedSigns[i].Despawn();
        }
    }

    protected DVDSign getSign()
    {
        for (int i = 0;i < spawnedSigns.Length;i++)
        {
            if (!spawnedSigns[i].IsActive) return spawnedSigns[i];
        }
        return null;
    }
}
