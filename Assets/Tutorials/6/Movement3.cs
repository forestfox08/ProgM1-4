using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement3 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sensitivity = 5;
    public Rigidbody rb;
    public bool onGround = true;

    private GameObject Bullet;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private GameObject enemyposition;

    void Start()
    {
        Debug.Log("Current Speed is: " + moveSpeed);

        rb = GetComponent<Rigidbody>();
        Debug.Log("Speler Klaar");

    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 move = new Vector3(moveX, 0f, moveZ);
        transform.Translate(move);

        if (Input.GetKeyDown(KeyCode.T))
        {
            FireBullet();
        }
        if (Bullet != null)
        {
            Bullet.transform.position = Vector3.Lerp(Bullet.transform.position, enemyposition.transform.position, 10f * Time.deltaTime);
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

    }
    void FireBullet()
    {
        Bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check of het een munt is
        if (collision.gameObject.tag == "Coin")
        {

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