using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Factory : MonoBehaviour
{
	public int amount;
	public float size;
	public float velocity;
	private Object[] background_prefabs;
	
    // Start is called before the first frame update
    void Start()
    {
		velocity = 0.025f;
        size = 40.8f;
		amount = 4;
		background_prefabs = new Object[amount];
		
		for(int i = 0; i < amount; i++)
		{
			GameObject background = (GameObject) Object.Instantiate(Resources.Load("bg-space-1"));
			background.transform.SetParent(transform);
			background.transform.position = new Vector3(size*i-2.0f,0,2);
			background_prefabs[i] = background;
		}
			
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < background_prefabs.Length; i++)
		{
			GameObject background = (GameObject) background_prefabs[i];
			background.transform.position = new Vector3(background.transform.position.x - velocity, 0, 2);
			
			if(background.transform.position.x < -(size + 2.0f))
				background.transform.position = new Vector3(background.transform.position.x + amount*size, 0, 2);
		}
    }
}
