using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;

    public void ReceiveDamage(int damageValue)
    {
        health -= damageValue;
        
        if (health <= 0)
            OnDeath();
    }

    public void OnDeath()
    {
        GameManager.instance.enemyList.Remove(this);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * moveSpeed);
    }
}
