using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser3 : MonoBehaviour
{
	private GameObject player;
	private Rigidbody2D laser_rigidbody;
	private Vector3 inicPosition;
	private float speed;
	private float limit;
	
	private float speedY;
	
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.Find("player2");
		Vector3 playerPos = player.transform.position;
		
		speed = 6.0f;
		limit = 2.0f;
		
		speedY = speed;

        laser_rigidbody = GetComponent<Rigidbody2D>();
        laser_rigidbody.velocity = new Vector2(speed,speed);
		
		gameObject.transform.position = new Vector3(playerPos.x + 1.3f, playerPos.y, playerPos.z);
		inicPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 laserPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
        if (laserPos.y >= (inicPosition.y + limit))
		{
			laserPos.y = inicPosition.y + limit;
			speedY *= -1;
		}
		
		if (laserPos.y <= (inicPosition.y - limit))
		{
			laserPos.y = inicPosition.y - limit;
			speedY *= -1;
		}
		
		laser_rigidbody.velocity = new Vector2(speed, speedY);
		gameObject.transform.position = laserPos;
		
		if(transform.position.x >= 17.0f)
			Destroy(gameObject);
    }
}
