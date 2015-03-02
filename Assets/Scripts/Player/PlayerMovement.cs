using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	private PlayerWeaponController weapons;
	private CharacterController controller;
	private Vector3 movement = new Vector3();
	private float velocity;
	Animator anim;

	// Use this for initialization
	void Start () {
		weapons = GetComponent<PlayerWeaponController>();
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame

	void FixedUpdate()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, 100f)) {
			Vector3 mousePos = hit.point;
			Vector3 offset = Vector3.zero;
			weapons.AimAt(mousePos);

			mousePos.y = transform.position.y;
			transform.LookAt(mousePos);
		}

		if (anim.GetBool ("IsMoving") == false && anim.GetBool ("shooting") == false && anim.GetBool ("Middlefinger") == false) 
		{
			StartCoroutine(idleanimations());
		}
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Animating (h,v);
	}

	void Update () {
		
		//Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.y));
		//mousePos.y = transform.position.y;
		
		// Enable this line if you want moving "forward" to move towards the mouse
		//movement = transform.TransformDirection(movement);
		
		controller.Move(movement * speed * Time.deltaTime);
		
		if(Input.GetButtonDown ("Fire3")&& anim.GetBool("IsMoving") == false && anim.GetBool("shooting") == false)
		{
			CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
			cc.enabled = false;
			anim.SetBool ("Middlefinger", true);
			StartCoroutine(mfwait());
		}
	}

	private IEnumerator mfwait()
	{
		yield return new WaitForSeconds(1.5f);
		CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
		cc.enabled = true;

	}

	private IEnumerator idleanimations()
	{
		yield return new WaitForSeconds(4f);
		int animnumber = Random.Range (1, 4);
		anim.SetBool ("Idlea" + animnumber, true);
		yield break;

	}

	void SetMovement(Vector3 m) {
		movement = m;
	}

	void Animating (float h, float v)
	{
		bool moving = h != 0f || v != 0f;
		anim.SetBool ("IsMoving", moving);
	}
}
