using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionAnim : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject particles;
    [SerializeField] private float delay;
    public static bool playerIsDead;

    private void Start()
    {
        player.SetActive(true);
        particles.SetActive(false);
        playerIsDead = false;
    }

    private void Update()
    {
        if (!playerIsDead) return;
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        player.SetActive(false);
        particles.SetActive(true);
        particles.transform.position = player.transform.position;
        yield return new WaitForSeconds(delay);
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }
}
