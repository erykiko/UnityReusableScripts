using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other){
		if(other.gameObject.GetComponent<RoomSpawner>() != null){
			if (other.gameObject.GetComponent<RoomSpawner>().spawned != true){
				Destroy(other.gameObject);
			}
		}
	}
}