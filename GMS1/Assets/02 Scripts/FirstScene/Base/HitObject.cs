using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitObject : MonoBehaviour, IHitCheck
{
    public abstract void Hit();

    private void OnCollisionEnter(Collision collision)
    {
        IHitCheck hitCheck = collision.gameObject.GetComponent<IHitCheck>();

        if (hitCheck != null)
        {
            hitCheck.Hit();
        }
    }
}
