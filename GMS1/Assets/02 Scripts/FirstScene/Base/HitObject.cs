using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitObject : MonoBehaviour, IHitAble
{
    public abstract void Hit();

    private void OnCollisionEnter(Collision collision)
    {
        IHitAble hitCheck = collision.gameObject.GetComponent<IHitAble>();

        if (hitCheck != null)
        {
            hitCheck.Hit();
        }
    }
}
