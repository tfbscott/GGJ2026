using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public float followStrength = 0.01f;

    private const float epsilon = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) > epsilon)
        {
            Vector3 NewPos = Vector3.Lerp(transform.position, player.position, followStrength);
            NewPos.z = -10;

            transform.position = NewPos;
        }
    }
}
