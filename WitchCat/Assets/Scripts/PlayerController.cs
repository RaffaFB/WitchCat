using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov2d : MonoBehaviour {
	public float velocidade = 5f;
	public bool noChao = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Pulo ();
		Vector3 movimento = new Vector3 (Input.GetAxis("Horizontal"), 0f, 0f);
		transform.position += movimento * Time.deltaTime * velocidade;
	}

	void Pulo(){
		if (Input.GetButtonDown("Jump") && noChao == true){
			gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,5f), ForceMode2D.Impulse);
		}

	}
}
