using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    private int rand;
    public bool spawned;
    void Start(){
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if(templates.roomLimit > 0){
			Invoke("Spawn", 0.1f);
		}


	}
    void Spawn()
    {
		if (!spawned)
		{
			rand = Random.Range(0, templates._roomsArr.Length);
			Instantiate(templates._roomsArr[rand], transform.position, Quaternion.identity);
			spawned = true;
			templates.roomLimit--;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
			Destroy(gameObject);
		}
	}
}