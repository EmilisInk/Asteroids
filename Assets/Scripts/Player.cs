using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Movementt controls;
    private Vector2 moveInput;

    [Header("Shooting Settings")]
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float fireRate = 0.5f;

    public float nextFireTime = 0f;

    void Awake()
    {
        controls = new Movementt();
        controls.Move.Enable();
    }

    void Update()
    {
        moveInput = controls.Move.Movement.ReadValue<Vector2>();
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
