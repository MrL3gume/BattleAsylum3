using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

    public float duration;
    public GameObject hitBox;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            hitBox.SetActive(true);
            StartCoroutine(explodeCoroutine());
        }
    }

    IEnumerator explodeCoroutine()
    {
        yield return new WaitForSeconds(1);
        hitBox.SetActive(false);
        Destroy(gameObject);
    }
}
