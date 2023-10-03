using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class ForceField : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float forceFieldSize;
    private CircleCollider2D forceField;

    private void Awake()
    {
        forceField = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Jump")) return;
        transform.position = player.position;
        ForceFieldActivation();
    }

    private void ForceFieldActivation()
    {
        forceField.radius = forceFieldSize;
    }
}
