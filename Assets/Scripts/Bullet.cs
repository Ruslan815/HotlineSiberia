using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	public float lifetime;
	public float distance;
	public int damage;
	public LayerMask whatIsSolid;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
			if (hitInfo.collider.CompareTag("Enemy")) {
				hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
			}
			DestroyBullet();
		}
		transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    
    public void DestroyBullet() {
		Destroy(gameObject);
	}
}
