using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Rigidbody>().AddForce(new Vector3(0,0, 2));
	}
}
