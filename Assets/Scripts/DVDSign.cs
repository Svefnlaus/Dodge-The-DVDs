using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TMP_Text))]
public class DVDSign : MonoBehaviour
{
    // public variables
    [SerializeField] protected float speed;
    [SerializeField] protected float delay;

    // private variables
    private Rigidbody2D rb;
    private TMP_Text text;
    private Color[] colors = new Color[] { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta, Color.cyan };

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        StartCoroutine("ColorSwap");
        rb.AddForce(Direction() * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (rb.velocity.magnitude != speed && !ExplosionAnim.playerIsDead)
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);

        if (ExplosionAnim.playerIsDead)
            rb.velocity = Vector2.zero;
    }

    private Vector2 Direction()
    {
        int x, y;
        do
        { 
            x = Random.Range(-1, 2);
            y = Random.Range(-1, 2);
        } while (x == 0 || y == 0);
        return new Vector2(x,y);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
    }

    public bool IsActive
    {
        get { return gameObject.activeSelf; }
    }

    IEnumerator ColorSwap()
    {
        while (true)
        {
            int chance = Random.Range(0, colors.Length);
            text.color = colors[chance];
            yield return new WaitForSeconds(delay);
        }
    }
}
