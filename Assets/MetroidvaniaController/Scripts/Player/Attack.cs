using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public RotateSword sword;
	private Quaternion swordRot;
	public GameObject swordPos;
	public ReturnSwordSpecial _returnSwordSpecial;

	[Space] 
	public GameObject attackHitbox;
	public GameObject defendHitbox;
	[Space]
	
	public float dmgValue = 4;
	public GameObject throwableObject;
	public Transform attackCheck;
	private Rigidbody2D m_Rigidbody2D;
	
	
	public Animator animator;
    [HideInInspector] public bool canAttack = true;
	[HideInInspector] public bool canDefend = true;
	public bool isTimeToCheck = false;
	private bool canFlip = true;	
	public GameObject cam;

	private Vector2 initSwordPos;
	private bool isFlippingSword = true;
	private void Awake()
	{
		attackHitbox.SetActive(false);
		defendHitbox.SetActive(false);
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		swordRot = sword.transform.rotation;
		initSwordPos = swordPos.transform.position;
	}


	// Update is called once per frame
    void Update()
    {
	    //Attacking
		if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
		{
			canAttack = false;
			//canDefend = false;
			animator.SetBool("IsAttacking", true);
			attackHitbox.SetActive(true);
			_returnSwordSpecial.StartAttack();
			
		//	StartCoroutine(AttackCooldown());
		}
		//ReturnSword
		//if (Input.GetKeyDown(KeyCode.Mouse1) && canDefend)
			
		//Defending
		if (Input.GetKey(KeyCode.Mouse1) && canDefend)
		{
			if (_returnSwordSpecial.isAttacking)
			{
				_returnSwordSpecial.EndAttack();
				canDefend = false;
				StartCoroutine(AttackCooldown());
				attackHitbox.SetActive(false);
				return;
			}
			//TODO implement perfect block maybe idk
			canAttack = false;
			canDefend = false;
			isFlippingSword = false;
			animator.SetBool("IsAttacking", true);
			sword.isShowingRotation = true;
			defendHitbox.SetActive(true);
		}
		//Ending Defend
		if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			canAttack = true;
			canDefend = true;
			isFlippingSword = true;
			sword.isShowingRotation = false;
			sword.transform.rotation = swordRot;
			defendHitbox.SetActive(false);
			FlipSword();
			//FixSpritePos();
		}

		//
		// if (Input.GetKeyDown(KeyCode.V))
		// {
		// 	GameObject throwableWeapon = Instantiate(throwableObject, transform.position + new Vector3(transform.localScale.x * 0.5f,-0.2f), Quaternion.identity) as GameObject; 
		// 	Vector2 direction = new Vector2(transform.localScale.x, 0);
		// 	throwableWeapon.GetComponent<ThrowableWeapon>().direction = direction; 
		// 	throwableWeapon.name = "ThrowableWeapon";
		// }

		
	}
	//TODO merge this attack cooldown with time taking for sword to return
	IEnumerator AttackCooldown()
	{
		yield return new WaitForSeconds(0.075f);
		//swordPos.transform.position = initSwordPos;
		//FixSpritePos();
		canAttack = true;
		canDefend = true;
	}

	
	public void FlipSword()
	{
		if (!isFlippingSword)
		{
			return;
			
		}
		if (transform.localScale.x <= 0.1)
		{
			swordPos.transform.rotation = new Quaternion(swordPos.transform.rotation.x, swordPos.transform.rotation.y, 0, 0);
			
		}
		else
		{
			swordPos.transform.rotation = new Quaternion(swordPos.transform.rotation.x, swordPos.transform.rotation.y, 180, 0);
		}
		// if (swordPos.transform.rotation.z == 0)
		// {
		// 	swordPos.transform.Rotate(0, 0, -180);
		// }
		// if (swordPos.transform.rotation.z <= 10 )
		// {
		// 	swordPos.transform.Rotate(0, 0, -180);
		// }
	}

	public void DoDashDamage()
	{
		dmgValue = Mathf.Abs(dmgValue);
		Collider2D[] collidersEnemies = Physics2D.OverlapCircleAll(attackCheck.position, 0.9f);
		for (int i = 0; i < collidersEnemies.Length; i++)
		{
			if (collidersEnemies[i].gameObject.tag == "Enemy")
			{
				if (collidersEnemies[i].transform.position.x - transform.position.x < 0)
				{
					dmgValue = -dmgValue;
				}
				collidersEnemies[i].gameObject.SendMessage("ApplyDamage", dmgValue);
				cam.GetComponent<CameraFollow>().ShakeCamera();
			}
		}
	}

	public void enableActions(bool enable)
	{
		canAttack = enable;
		canDefend = enable;
	}

	private void FixSpritePos()
	{
		// print("fixingPos");
		// swordSprite.enabled = true;
		// swordSprite.time = 0;
		// sword.transform.localPosition = new Vector3(0, 0, 0);
	}
}
