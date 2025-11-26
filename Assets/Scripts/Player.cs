using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Movementt controls;
    private Vector2 moveInput;

    private Rigidbody2D rb;

    [Header("Shooting Settings")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;
    public float nextFireTime = 0f;

    void Awake()
    {
        controls = new Movementt();
        controls.Move.Enable();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = controls.Move.Movement.ReadValue<Vector2>();
        if(Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
        rb.angularVelocity = 0f;

        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
