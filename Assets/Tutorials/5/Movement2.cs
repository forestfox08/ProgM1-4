using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public scoreManager scoreManager;

    public float moveSpeed = 5f;
    public float sensitivity = 5;
    public Rigidbody rb;
    public bool onGround = true;

    void Start()
    {
        Debug.Log("Current Speed is: " + moveSpeed);

        rb = GetComponent<Rigidbody>();
        Debug.Log("Speler Klaar");

        if (scoreManager == null)
        {
            Debug.LogError("Scoremanager not found !! - Please Config your scoremanager !!");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector3 move = new Vector3(moveX, 0f, 0f);
        transform.Translate(move);

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

    void OnCollisionEnter(Collision collision)
    {
        // Check of het een munt is
        if (collision.gameObject.tag == "Coin")
        {
            scoreManager.AddScore(10); // Roep de AddScore methode van je score-script aan en geef 10 punten mee

            // Geef in de console een bericht dat je een munt hebt gepakt!
            Debug.Log("Munt gepakt!");

            // Vernietig de munt
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

}