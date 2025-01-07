using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    public enum EffectType { None, Stun, Float }
    public EffectType effectOnHit;

    public GameObject cannonPosition;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("cannon"))
        {
            effectOnHit = (EffectType)Random.Range(0, 3);
            ApplyEffect();
        }
    }

    void ApplyEffect()
    {
        switch (effectOnHit)
        {
            case EffectType.Stun:
                StunEnemy();
                break;
            case EffectType.Float:
                FloatEnemy();
                break;
            default:
                if (cannonPosition != null)
                {
                    Destroy(cannonPosition);
                }
                break;
        }
    }

    void StunEnemy()
    {
        
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
        Invoke("UnstunEnemy", 2f);
    }

    void UnstunEnemy()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    void FloatEnemy()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}
