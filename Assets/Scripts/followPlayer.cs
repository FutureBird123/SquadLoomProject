using UnityEngine;

public class followPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition= transform.position;
        newPosition.x = player.position.x;
        transform.position=newPosition;
    }
}
