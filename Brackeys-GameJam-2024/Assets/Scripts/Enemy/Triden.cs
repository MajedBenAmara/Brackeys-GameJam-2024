using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triden : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("ReceiveDamage", _damage);
        }
    }
}
