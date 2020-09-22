using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : Enemy
{
    private GameObject m_player;
    private Rigidbody m_rigidbody;
    public float m_speed = 100;
    public AudioMusic m_deathSound;
    public GameObject m_deathParticle;

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.MovePosition(Vector3.MoveTowards(transform.position, m_player.transform.position, m_speed * Time.deltaTime));
    }

    public override void Die()
    {
        soundPlayer.Play(m_deathSound);
        Instantiate(m_deathParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public override void EnemyStart()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        m_rigidbody = GetComponent<Rigidbody>();
    }
}
