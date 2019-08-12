using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	//floats
	public float speed;
	public float jumpForce;

	//booleans
	private bool noChao = false;
	private bool facingRight = true;
	private bool jump = false;

	//other
	private Animator anim;
	private Transform groundCheck;
	private Rigidbody2D rb;


	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		groundCheck = gameObject.transform.Find("GroundCheck");
	}
	
	// Update is called once per frame
	void Update () {
		noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if(Input.GetButtonDown("Jump") && noChao){
			jump = true;
			//anim = SetTrigger("Pulou");
		}
	}
	void FixedUpdate(){
		float direcao = Input.GetAxisRaw("Horizontal");
		anim.SetFloat("Velocidade", Mathf.Abs(direcao));
		//mantem a velocidade do personagem constante
		rb.velocity = new Vector2(direcao*speed,rb.velocity.y);

		if(direcao > 0 && !facingRight){
			Flip();
		} else if(direcao < 0 && facingRight){
			Flip();
		}
		if(jump){
			rb.AddForce(new Vector2(0,jumpForce));
			jump = false;
		}

	}
	void Flip(){
		facingRight = !facingRight;
		//inverte o valor da coordenada x no vetor
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
