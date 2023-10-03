using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 lastPosition;
    private Vector3 relativePosition;

    private Vector2 mousePosition
    {
        get { return Camera.main.ScreenToWorldPoint(Input.mousePosition); }
    }

    private void FixedUpdate()
    {
        // with delay
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.fixedDeltaTime);
        Rotate();

        // without delay
        // transform.position = mousePosition;

        // hide the cursor when in-game
        if (!Cursor.visible) return;
        Cursor.visible = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Sign")) return;
        ExplosionAnim.playerIsDead = true;
    }

    private void Rotate()
    {
        Vector3 target = mousePosition;
        relativePosition = target - transform.position;
        if (relativePosition == lastPosition) return;
        transform.rotation = Quaternion.FromToRotation(Vector2.up, relativePosition);
        lastPosition = relativePosition;
    }
}
