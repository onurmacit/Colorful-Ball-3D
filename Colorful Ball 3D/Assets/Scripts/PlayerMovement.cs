using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f; // Topun hızı
    private Rigidbody rb; // Topun Rigidbody bileşeni

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Topun Rigidbody bileşenini al
    }

    void FixedUpdate()
    {
        // Topun sabit hızda ilerlemesi için hız vektörünü oluştur
        Vector3 velocity = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")) * speed;
        rb.velocity = velocity;
    }
}