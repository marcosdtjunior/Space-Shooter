using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Factory : MonoBehaviour
{
	public float horizontalSpawn;
	public float verticalSpawnBound;
	public float spawnDuration;
	public float spawnTimer;
	private Object[] meteorsPrefab; 
	
    // Start is called before the first frame update
    void Start()
    {
        horizontalSpawn = 20.41f;
		verticalSpawnBound = 5.18f;
		spawnTimer = 0;
		spawnDuration = 1.0f;
		meteorsPrefab = new Object[3];
		meteorsPrefab[0] = Resources.Load("meteorBrown");
		meteorsPrefab[1] = Resources.Load("meteor2");
		meteorsPrefab[2] = Resources.Load("meteor3");
    }

    // Update is called once per frame
    void Update()
    {
		spawnTimer += Time.deltaTime;
		
		if(spawnTimer >= spawnDuration)
		{
			GameObject newMeteor = (GameObject) Object.Instantiate(meteorsPrefab[Random.Range(0,3)]);
			newMeteor.transform.SetParent(transform);
			newMeteor.transform.position = new Vector2(horizontalSpawn, Random.Range(-verticalSpawnBound,verticalSpawnBound));
			spawnTimer = 0;
		}
    }
}
