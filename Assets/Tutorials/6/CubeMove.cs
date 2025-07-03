using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // SP = StartPosition
    // 2P

    [SerializeField] private GameObject SP;
    [SerializeField] private GameObject secP;
    [SerializeField] private float MovementSpeed = 1.0f;

    private bool GoToSecP = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // :P
        if (SP != null)
        {
            Debug.Log("StartPosition not found, please configure!");
        }
        if (secP != null)
        {
            Debug.Log("Second Position not found, please configure!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = GoToSecP ? SP.transform.position : secP.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, target, MovementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
           GoToSecP = !GoToSecP;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
