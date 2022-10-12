using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] _roomsArr;
	public int roomLimit = 10;
	public List<GameObject> rooms;
	private Transform bossRoomPosition;
	private Transform miniBossRoomPosition;
	public float waitTimeBoss;
	public float waitTimeMiniBoss;
	private bool spawnedBoss =true;
	private bool spawnedMiniBoss;
	public GameObject bossRoom;
	public GameObject miniBossRoom;
	void Update(){
		if (waitTimeMiniBoss <= 0 && spawnedMiniBoss == false){
			MiniBossSpawn(rooms.Count - 3);
		}else waitTimeMiniBoss -= Time.deltaTime;
		if (waitTimeBoss <= 0 && spawnedBoss == false){
				BossSpawn(rooms.Count - 1);
		}else waitTimeBoss -= Time.deltaTime;
	}
	void MiniBossSpawn(int ri){
		if(!spawnedMiniBoss){
			Transform trynidad = rooms[ri].transform;
			Destroy(rooms[ri]);
			rooms.Remove(rooms[ri]);
			Instantiate(miniBossRoom, trynidad.position, Quaternion.identity);
			spawnedMiniBoss = true;
		}
	}
	void BossSpawn(int ri){
		if(!spawnedBoss){
			Transform trynidad = rooms[ri].transform;
			Destroy(rooms[ri]);
			rooms.RemoveAt(ri);
			Instantiate(bossRoom, trynidad.position, Quaternion.identity);
			spawnedBoss = true;
		}
	}
}