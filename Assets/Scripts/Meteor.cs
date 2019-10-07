using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
	private Rigidbody2D meteor_rigidbody;
	public float speed;
	private Object explosionPrefab;
	private int lives; 


    // Start is called before the first frame update
    void Start()
    {	
		meteor_rigidbody = GetComponent<Rigidbody2D>();
		speed = Random.Range(3,5);
        meteor_rigidbody.velocity = new Vector2(-speed,0);
		meteor_rigidbody.rotation = 30f;
		explosionPrefab = Resources.Load("Explosion");
		lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
		meteor_rigidbody.rotation += 1.0f;
		
        if(transform.position.x <= -20.41f)
			Destroy(gameObject);
    }
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log("There was a collision with: " + collider.gameObject.name);
		
		if(collider.gameObject.name == "player1" || collider.gameObject.name == "player2")
			Destroy(collider.gameObject);
		
		if(collider.gameObject.name == "laserBlue(Clone)" || collider.gameObject.name == "laserGreen(Clone)" ||
		collider.gameObject.name == "Machine Gun(Clone)" || collider.gameObject.name == "Ball_02(Clone)")
		{
			Destroy(collider.gameObject);
			lives--;
		}
		
		if (lives == 0)
		{
			GameObject newExplosion = (GameObject) Object.Instantiate(explosionPrefab);
			newExplosion.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
			Destroy(gameObject);
			lives = 3;
		}
	}
}
