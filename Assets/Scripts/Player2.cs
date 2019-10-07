using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
	public int lives;
	public float velocity;
	public string name;
	public float verticalBound;
	public float horizontalBound;

	private Rigidbody2D rigidbody;
	public Object laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
		lives = 3;
		velocity = 6.0f;
		name = "mother_fuck_destroyer2";
		rigidbody = GetComponent<Rigidbody2D>();
		verticalBound = 5.73f;
		horizontalBound = 16.56f;
		
		laserPrefab = Resources.Load("laserGreen");
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 targetVelocity = Vector2.zero;
		Vector2 targetPosition = new Vector2(transform.position.x,transform.position.y);
		Quaternion targetRotation = new Quaternion(0,0,-90,90);

		if(Input.GetKey(KeyCode.W))
		{
			targetVelocity.y = velocity;
			targetRotation = Quaternion.Euler(0,0,-60);
		}
		   
		if(Input.GetKey(KeyCode.S))
		{
			targetVelocity.y = -velocity;
			targetRotation = Quaternion.Euler(0,0,-120);
		}

		if(Input.GetKey(KeyCode.D))
			targetVelocity.x = velocity;
		   
		if(Input.GetKey(KeyCode.A))
			targetVelocity.x = -velocity;
		
		if(Input.GetKeyUp(KeyCode.X))
		{
			GameObject newLaser = (GameObject) Object.Instantiate(laserPrefab);
			newLaser.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		}
		
		if(transform.position.y >= verticalBound)
			targetPosition.y = verticalBound;
		
		if(transform.position.y <= -verticalBound)
			targetPosition.y = -verticalBound;
		
		if(transform.position.x >= horizontalBound)
			targetPosition.x = horizontalBound;
		
		if(transform.position.x <= -horizontalBound)
			targetPosition.x = -horizontalBound;
		
		transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,0.13f);
		transform.position = targetPosition;
		rigidbody.velocity = targetVelocity;
    }
}