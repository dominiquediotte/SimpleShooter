using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    private int m_life = 1;
    protected SoundPlayer soundPlayer;

    public void TakeDamage(int damage)
    {
        m_life -= damage;

        if (m_life <= 0)
        {
            Die();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>();
        EnemyStart();
    }

    public abstract void EnemyStart();
    public abstract void Die();
}
