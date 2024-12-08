using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    // Corregido el nombre del método
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Corregida la comparación usando ==
        if (collision.tag == "Player")
        {
            // Corregido el punto faltante antes de TakeDamage
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
