using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public float intervaloAtaque;
	private float proximoAtaque;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>()
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && Time.time > proximoAtaque){
			Atacando();
		}
	}

	void Atacando(){
		anim.SetTrigger("Ataque");
		proximoAtaque = Time.time + intervaloAtaque;
	}
}