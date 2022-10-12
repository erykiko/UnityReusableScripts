using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	[SerializeField] int _enemyTier;
	public bool _used = false;
	private int rand;
	private EnemyTemplates templates;
	private Collider2D player;
	void Start(){
		templates = GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyTemplates>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.GetComponent<RoomSpawner>() == player.gameObject.GetComponent<RoomSpawner>()){
			switch (_enemyTier)
			{
				case 1:
					Spawn(templates._EnemiesT1Arr);
					break;
				case 2:
					Spawn(templates._EnemiesT2Arr);
					break;
				case 3:
					Spawn(templates._EnemiesT3Arr);
					break;
				default:
					Debug.Log("Tier is not set");
					break;
			}
		}
	}  
	void Spawn(GameObject[] array){
		rand = Random.Range(0, array.Length);
		if (!_used)
		{
			Instantiate(array[rand], transform.position, Quaternion.identity);
			_used = true;
		}
	}
}