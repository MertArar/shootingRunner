using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [Range(200, 2000)] [SerializeField] private float moveSpeed;

    protected void Move(Vector3 direction)
    {
        myRigidbody.velocity = direction * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag($"Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
