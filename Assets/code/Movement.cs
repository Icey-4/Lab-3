using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float vInput;
    private float hInput;

    public int bulletSpeed;

    private Rigidbody _rb;

    bool ground;

    public GameObject bullet;
    public Transform bulletpos;

    private GameObject bulletSpawn;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }

    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (Input.GetKey(KeyCode.Space) && ground)
        {
            jump();
        }

    }

    void jump()
    {
        _rb.AddForce(transform.up * 10, ForceMode.Impulse);
        ground = false;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.tag == "Ground") 
        {
            for (int i = 0; i < collision.contacts.Length; i++) 
            {
                if (collision.contacts[i].normal.y > 0.5)
                {
                    ground = true;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bulletSpawn = Instantiate(bullet, bulletpos.position, bullet.transform.rotation);
        bulletSpawn.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, bulletSpeed);
    }
}


