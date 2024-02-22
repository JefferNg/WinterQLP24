using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchAttack : MonoBehaviour
{
    [SerializeField] int damage;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().isHit(damage);
        }
    }
}
