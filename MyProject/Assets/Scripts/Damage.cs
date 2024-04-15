using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    public void HitByVector(Vector2 vector, float force)
    {
        rb.AddForce(vector * force, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null && player.canHurt)
        {
            player.health -= 1;
        }
    }
}
