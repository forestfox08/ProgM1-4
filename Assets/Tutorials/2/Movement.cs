using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float sensitivity = 5;
    public Rigidbody rb;
    public bool onGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Speler Klaar");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            // Hoop dat dit ook ok is in plaats van wat er in de opdracht stond.
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
        }
        void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void UnlockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        if (Input.GetMouseButton(0))
        {
            LockCursor();
        }


        // is voor nu niet nodig!!
        //float mouseX = Input.GetAxis("Mouse X");
       //float mouseY = Input.GetAxis("Mouse Y");

        //transform.Rotate(0, mouseX * sensitivity, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

}