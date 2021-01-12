using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject ground;
    private Transform player;
    private float offset = 16f;
    private float x = 0f;
    private float y = 0f;
    private bool generate = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Instantiate(ground,new Vector2(0,0),Quaternion.identity);
        Instantiate(ground,new Vector2(0,offset),Quaternion.identity);
        Instantiate(ground,new Vector2(offset,0),Quaternion.identity);
        Instantiate(ground,new Vector2(0,-offset),Quaternion.identity);
        Instantiate(ground,new Vector2(-offset,0),Quaternion.identity);
        Instantiate(ground,new Vector2(offset,offset),Quaternion.identity);
        Instantiate(ground,new Vector2(offset,-offset),Quaternion.identity);
        Instantiate(ground,new Vector2(-offset,offset),Quaternion.identity);
        Instantiate(ground,new Vector2(-offset,-offset),Quaternion.identity);
    }
 
    void Update()
    {
        if(player.position.x > (x + 8))
        {
            x += offset;
            generate = true;
        }
        if(player.position.x < (x - 8))
        {
            x -= offset;
            generate = true;
        }
        if(player.position.y > (y + 8))
        {
            y += offset;
            generate = true;
        }
        if(player.position.y < (y - 8))
        {
            y -= offset;
            generate = true;
        }

        if(generate)
        {
            Instantiate(ground,new Vector2(x,y),Quaternion.identity);
            Instantiate(ground,new Vector2(x,y + offset),Quaternion.identity);
            Instantiate(ground,new Vector2(x + offset,y),Quaternion.identity);
            Instantiate(ground,new Vector2(x,y - offset),Quaternion.identity);
            Instantiate(ground,new Vector2(x - offset,y),Quaternion.identity);
            Instantiate(ground,new Vector2(x + offset,y + offset),Quaternion.identity);
            Instantiate(ground,new Vector2(x + offset,y - offset),Quaternion.identity);
            Instantiate(ground,new Vector2(x - offset,y + offset),Quaternion.identity);
            Instantiate(ground,new Vector2(x - offset,y - offset),Quaternion.identity);

            generate = false;
        }

    }
}
