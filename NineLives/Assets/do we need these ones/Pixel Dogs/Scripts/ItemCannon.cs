using UnityEngine;

public class ItemCannon : MonoBehaviour {

    public Animator animator;
    public GameObject itemPrefab;
    public float force = 600.0f;
	
	public GameObject Fire()
    {
        // Instantiate the item
        GameObject item = Instantiate(itemPrefab, this.transform.position, Quaternion.identity) as GameObject;
        item.name = "Ball";

        // Add force to its rigidbody
        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(350, 100).normalized;
        rb.AddForce(direction * force);

        item.GetComponent<SpriteRenderer>().sortingOrder = 1;

        // Animate the cannon firing
        animator.SetTrigger("Fire");

        return item;
    }
}