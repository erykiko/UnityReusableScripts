using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRandomRooms : MonoBehaviour
{
    [SerializeField] RoomSpawner spawn1;
    [SerializeField] RoomSpawner spawn2;
    [SerializeField] RoomSpawner spawn3;
    [SerializeField] RoomSpawner spawn4;
    private void Awake()
    {
        spawn1.enabled = spawn2.enabled = spawn3.enabled = spawn4.enabled = true;
            
		int ran = Random.Range(0, 4);
        
        switch(ran)
        {
            case 0: 
				spawn1.enabled = false; break;
            case 1: 
				spawn2.enabled = false; break;
            case 2: 
				spawn3.enabled = false; break;
            case 3: 
				spawn4.enabled = false; break;
            }  
    }
}