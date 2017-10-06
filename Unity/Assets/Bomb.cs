using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public LayerMask ExplodeLayerMask;

	// Use this for initialization
	void Awake () {
        StartCoroutine(Explode());
    }
	
	// Update is called once per frame


    IEnumerator Explode() {
        yield return new WaitForSeconds(2);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 5 , Vector2.zero, 50, ExplodeLayerMask);
        foreach (RaycastHit2D hit in hits) {

            Vector3 direction = hit.transform.position - transform.position;
            float distance = Vector3.Distance(transform.position, hit.transform.position) * 50;



            Vector3 force = direction * (250 - distance);

            hit.transform.GetComponent<Rigidbody2D>().AddForce(force);
            Destroy(gameObject);

        }

    }
}
