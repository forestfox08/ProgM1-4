using Unity.VisualScripting;
using UnityEngine;

public class FollowAndReturn : MonoBehaviour
{
    public float returnSpeed = 5f;
    public Transform target;
    private Vector3 startPosition;
    private bool isResetting = false;
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isResetting)
        {
            ReturnToStart();
        }
        else
        {
            FollowTarget();
        }
    }
    private void FollowTarget()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);

        float distance = Vector3.Distance(transform.position, target.position);

        Debug.Log("distance to player: " + distance);

        if (distance < 0.1f)
        {
            isResetting = true;

        }
    }
    private void ReturnToStart()
    {
        Vector3 direction = (startPosition - target.position).normalized;

        transform.Translate(direction * returnSpeed * Time.deltaTime);

        float distToStart = Vector3.Distance(transform.position, startPosition);

        if (distToStart < 0.01f)
        {
            isResetting = false;
        }

    }
}
