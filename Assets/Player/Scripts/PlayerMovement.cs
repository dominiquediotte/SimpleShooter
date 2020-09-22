using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    private Camera m_camera;
    private float m_delayBeforeNextFire = 0;
    public int m_movementSpeed = 100;
    public GameObject m_bulletPrefab;
    public float m_fireDelay = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Orientate();
        ProcessFire();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * m_movementSpeed;
        m_rigidbody.MovePosition(m_rigidbody.position + movement);
    }

    private void Orientate()
    {
        Vector3 result = FindMousePosition();
        result.y = m_rigidbody.position.y;
        Vector3 relativePosition = result - transform.position;
        Quaternion quaternionRotation = Quaternion.LookRotation(relativePosition, Vector3.up);
        m_rigidbody.MoveRotation(quaternionRotation);
    }

    private void ProcessFire()
    {
        m_delayBeforeNextFire -= Time.deltaTime;

        if (Input.GetAxis("Fire1") != 0)
        {
            if (m_delayBeforeNextFire <= 0)
            {
                // Shoot
                Shoot();
                m_delayBeforeNextFire = m_fireDelay;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(m_bulletPrefab, transform.position + transform.forward, transform.rotation);
    }

    private Vector3 FindMousePosition()
    {
        Vector3 result = Vector3.zero;
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000))
        {
            result.x = hit.point.x;
            result.y = hit.point.y;
            result.z = hit.point.z;
        }

        return result;
    }
}
