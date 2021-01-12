using UnityEngine;

public class GroundDeleter : MonoBehaviour
{
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if(Vector2.Distance(player.position,transform.position) > 32)
            Destroy(gameObject);
    }
}
