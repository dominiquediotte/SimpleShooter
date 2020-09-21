using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour, IDamageable
{
    private GameObject m_player;
    private Rigidbody m_rigidbody;
    public float m_speed = 100;

    public void TakeDamage(int damage)
    {
        Die();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.MovePosition(Vector3.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.deltaTime));
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
