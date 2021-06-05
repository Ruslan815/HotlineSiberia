using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private float timeBtwAttack;
	public float startTimeBtwAttack;

	public int health;
	public float speed;
	public int damage;
	
	private Player player;
	private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (health <= 0) {
			Destroy(gameObject);
			player.killedEnemies += 1;
		}
		
		if (player.transform.position.x > transform.position.x) {
			transform.eulerAngles = new Vector3(0, 180, 0);
		} else {
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		
		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    
    public void TakeDamage(int damage) {
		health -= damage;
	}
	
	public void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("Player")) {
			if (timeBtwAttack <= 0) {
				anim.SetTrigger("enemyAttack");
			} else {
				timeBtwAttack -= Time.deltaTime;
			}
		}
	}
	
	public void OnEnemyAttack() {
		player.ChangeHealth(-damage);
		timeBtwAttack = startTimeBtwAttack;
	}
}
