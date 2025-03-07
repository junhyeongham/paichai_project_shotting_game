using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//EnemyBullet_M is Character Missile
public class EnemyBullet_M : Bullet
{
    Rigidbody rb;
    bool isAddForce;

    protected override void Initializing()
    {
        isAddForce = false;
        moveDir = transform.forward;
        rb = GetComponent<Rigidbody>();
    }

    protected override void Special()
    {
        moveDir = transform.forward;
        isFired = false;

        if(!isAddForce)
        {
            isAddForce = true;

            rb.AddForce(moveDir * dmg, ForceMode.Impulse);
        }

        transform.forward = rb.velocity;
    }

    protected override void Explosive()
    {
        GameManager.Instance.GetCurrentSceneT<InGameScene>().EffectSystem.ServeEffect(EffectCode.quatro, transform.position);
    }
    protected override void Resize()
    {
        transform.forward = new Vector3(0, 0.8f, -0.6f);
        rb.velocity = Vector3.zero;
    }
}
