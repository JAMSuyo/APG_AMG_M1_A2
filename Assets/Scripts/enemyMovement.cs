using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform cannon;
    public float moveSpeed = 3f;

    private void Update()
    {
        if (cannon != null)
        {
            Vector3 direction = (cannon.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
