using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float gravity = 9.81f;
	public float jumpForce = 20f;

	private PlayerWeaponController weapons;
	private CharacterController controller;
	private Vector3 movement = new Vector3();
	private float velocity;
	private Animator anim;
	private bool isShowingMiddleFinger = false;
	private bool jumping = false;
	private float currentYVel = 0f;
	private bool grounded = true;

	// Use this for initialization
	void Start () {
		weapons = GetComponent<PlayerWeaponController>();
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();

		// Every eight (anim length + 4 secs I think?) seconds check if we are doing anything and if not, play an idle animation
		InvokeRepeating("IdleAnimations", 4f, 8f);
	}
	
	// Update is called once per frame

	void FixedUpdate()
	{
		// Aiming
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		int layerMask = LayerMask.GetMask("Destroyable", "Enemy", "Terrain");
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit, 100f, layerMask)) {
			Vector3 mousePos = hit.point;
			Vector3 offset = Vector3.zero;

			int dl = LayerMask.NameToLayer("Destroyable");
			int el = LayerMask.NameToLayer("Enemy");
			if(hit.collider.gameObject.layer != dl && hit.collider.gameObject.layer != el) {
				// We are aiming at something we don't really need to hit, so just aim straight to the side
				float weaponYOffset = weapons.CurrentWeapon.transform.position.y - transform.position.y;
				offset.y = weaponYOffset;
			}

			weapons.AimAt(mousePos + offset);

			mousePos.y = transform.position.y;
			transform.LookAt(mousePos);
		}

		float h = movement.x;
		float v = movement.z;

		ray = new Ray(transform.position, Vector3.down);
		if(Physics.Raycast(ray, out hit, 0.2f)) {
			grounded = true;
		}
		else {
			grounded = false;
		}

		Animating (h,v);
	}

	void Update () {
		// Enable this line if you want moving "forward" to move towards the mouse
		//movement = transform.TransformDirection(movement);

		Vector3 mov = movement;
		mov *= speed;

		if(!grounded) {
			currentYVel -= gravity;
		}

		if(jumping) {
			jumping = false;
			if(grounded) currentYVel = jumpForce;
		}
		mov.y = currentYVel;

		mov *= Time.deltaTime;
		
		if(!isShowingMiddleFinger) controller.Move(mov);
	}

	// This gets called by the InputManager
	void ShowMiddleFinger() {
		// Can't wave your finger while running or shooting or already showing it or if in the air
		if(anim.GetBool("IsMoving") || anim.GetBool("Shooting") || isShowingMiddleFinger || !grounded) {
			return;
		}

		StartCoroutine(MiddleFingerWait());
	}

	private IEnumerator MiddleFingerWait()
	{
		isShowingMiddleFinger = true;
		anim.SetTrigger("MiddleFinger");

		// This informs the WeaponController that we are flipping the bird
		gameObject.SendMessage("ShowingMiddleFinger");

		yield return new WaitForSeconds(1.5f);
		isShowingMiddleFinger = false;

		// This informs the WeaponController that we are no longer flipping the bird
		gameObject.SendMessage("NotShowingMiddleFinger");
	}

	private void IdleAnimations()
	{
		if (anim.GetBool ("IsMoving") == false && anim.GetBool ("Shooting") == false && isShowingMiddleFinger == false) 
		{
			int animnumber = Random.Range (1, 4);
			anim.SetTrigger("IdleAnim" + animnumber);
		}
	}

	void SetMovement(Vector3 m) {
		movement.x = m.x;
		movement.z = m.z;
	}

	void Animating (float h, float v)
	{
		bool moving = h != 0f || v != 0f;
		anim.SetBool ("IsMoving", moving);
	}

	void Jump() {
		jumping = true;
		anim.SetTrigger ("Jump");
	}
}
