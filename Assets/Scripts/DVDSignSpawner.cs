using System.Collections;
using UnityEngine;

public class DVDSignSpawner : SpawnManager
{
    [SerializeField] float delay;
    private void Start()
    {
        ScoreManager.Score = 0;
        StartCoroutine("DVDSpawn");
    }

    private void SpawnDVDSign()
    {
        DVDSign clone = getSign();
        if (clone == null) return;
        clone.Spawn();
    }

    IEnumerator DVDSpawn()
    {
        // initial delay
        yield return new WaitForSeconds(delay);

        // constant spawning
        while (true)
        {
            if (ExplosionAnim.playerIsDead) break;
            SpawnDVDSign();
            ScoreManager.Score++;
            yield return new WaitForSeconds(delay);
        }
    }
}
