using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextLvLTp : MonoBehaviour
{
	[SerializeField] protected Animator tpAnimator;
	protected string currentAnimation;
	private GameObject player;
	private Rigidbody2D rb;
	private playerMovement pm;
	private float _cooldownDuration = 2.0f;
	private float _checkInterval = 0.5f;
	private int _tpRange = 200;
	public int _tpDirection = -1;
	public int enemies = 0;
	private SpriteRenderer spirit;
	public Sprite imgCan, imgCanNot;
	private string anima;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		rb = player.GetComponent<Rigidbody2D>();
		pm = player.GetComponent<playerMovement>();
		spirit = GetComponent<SpriteRenderer>();
		EnemiesRefresh();
		StartCoroutine("EnemiesCheck");
		StartCoroutine("EnemiesCheckTop");
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.GetComponent<playerMovement>() != null)
        {
			EnemiesRefresh();
			if (enemies == 0 && pm.isTpAvaible())
			{
				tpToNextRoom(_tpDirection);
				StartCoroutine("StartCooldown");
			}
		}
	}

	void tpToNextRoom(int direction){
		switch (direction)
		{
			//BTLR
			case 0:
				rb.position = new Vector3(rb.position.x, rb.position.y - _tpRange, 0);
				break;
			case 1:
				rb.position = new Vector3(rb.position.x, rb.position.y + _tpRange, 0);
				break;
			case 2:
				rb.position = new Vector3(rb.position.x - _tpRange, rb.position.y, 0);
				break;
			case 3:
				rb.position = new Vector3(rb.position.x + _tpRange, rb.position.y, 0);
				break;
			default:
				Debug.Log("Nieokreślony kierunek");
				break;
		}
	}

	private void EnemiesRefresh(){
		enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
	}

	public IEnumerator StartCooldown()
	{
		pm.tpChangeState();
		Debug.Log(pm.isTpAvaible());
		yield return new WaitForSeconds(_cooldownDuration);
		pm.tpChangeState();
		Debug.Log(pm.isTpAvaible());
	}

	public IEnumerator EnemiesCheck() {
	while(true) {
		EnemiesRefresh();
		if ( _tpDirection != 1 && pm.isTpAvaible() == true && enemies == 0){
				spirit.sprite = imgCan;
		} else
		{
				if ( _tpDirection != 1){spirit.sprite = imgCanNot; }
		}
		yield return new WaitForSeconds(_checkInterval);
    }
	}

	public IEnumerator EnemiesCheckTop() {
    while(true) {
        EnemiesRefresh();
		if ( _tpDirection == 1 && pm.isTpAvaible() == true && enemies == 0){
				ChangeAnimation("GreeceDoor");
		} else
		{
				if ( _tpDirection == 1){ ChangeAnimation("GreeceDoorClose"); }
		}
		yield return new WaitForSeconds(_checkInterval);
    }
	}

	private void ChangeAnimation(string newAnimation)
	{
		if (currentAnimation == newAnimation) return;

		tpAnimator.Play(newAnimation);

		currentAnimation = newAnimation;
	}

}