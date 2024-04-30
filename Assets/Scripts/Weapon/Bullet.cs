using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _delayDeadTime;

    private void Start()
    {
        Invoke("DestroyWithDelay", _delayDeadTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void DestroyWithDelay()
    {
        Destroy(gameObject);
    }



}
