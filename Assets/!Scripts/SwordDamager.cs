using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class SwordDamager : MonoBehaviour
{
	private Rigidbody Body;
	public PlayerVelocity PlayerVelocity;
	public Damager.DamageRole myRole = Damager.DamageRole.Other;
	public Vector3 previous;
	public Vector3 current;
	public float SwordVelocityValue;
	public float velocity;
	public float velocityNonABS;
	[Header("Displays life hearts (optional)")]
	public DamagerHUD livesDisplay;

	[Header("Limit what kinds of Colliders I can hit (Optional)")]
	public bool ignoreTriggers = false;
	public bool ignoreCollisions = false;
	public bool ignoreCharacterControllers = false;

	[Header("How much damage I deal to others")]
	public float damagePlayerRange1 = 0f;
	public float damagePlayerRange2 = 0f;
	public float damagePlayerRange3 = 0f;
	public float damagePlayerRange4 = 0f;

	public float damagePlayer1 = 0f;
	public float damagePlayer2 = 0f;
	public float damagePlayer3 = 0f;
	public float damagePlayer4 = 0f;

	public float damageEnemyRange1 = 0f;
	public float damageEnemyRange2 = 0f;
	public float damageEnemyRange3 = 0f;
	public float damageEnemyRange4 = 0f;

	public float damageEnemy1 = 0f;
	public float damageEnemy2 = 0f;
	public float damageEnemy3 = 0f;
	public float damageEnemy4 = 0f;

	public float damageOtherRange1 = 0f;
	public float damageOtherRange2 = 0f;
	public float damageOtherRange3 = 0f;
	public float damageOtherRange4 = 0f;

	public float damageOther1 = 0f;
	public float damageOther2 = 0f;
	public float damageOther3 = 0f;
	public float damageOther4 = 0f;

	[Header("How much damage I can take")]
	public float maxHealth = 1f;
	private float _curHealth;
	public float startingHealth = 1f;

	public float currentHealth { get { return _curHealth; } }

	[Header("What to call when I take damage")]
	public UnityEvent damageEvents;

	[Header("Invincibility time after taking a hit")]
	public float invincTime = 0f;
	private bool _invincible = false;
	private float blinkTime = 0.1f;
	public Material invincibleMaterial;

	[Header("Destroy this GameObject when I die")]
	public bool destroyUponDeath = true;

	[Header("Destroy when I hit *anything*")]
	public bool destroyUponHit = false;

	[Header("Create this prefab when I die")]
	public GameObject spawnWhenDestroyed;

	[Header("What to call when I die")]
	public UnityEvent deathEvents;

	//	private WaveGroup _owner;

	void Awake()
	{
		_curHealth = startingHealth;

		if (livesDisplay == null && this.GetComponent<DamagerHUD>() != null)
		{
			this.livesDisplay = this.GetComponent<DamagerHUD>();
		}
		if (this.livesDisplay != null)
		{
			this.livesDisplay.UpdateLives(_curHealth);
		}

	}
	private void Start()
	{
		Body = GetComponent<Rigidbody>();
	}

	void Update()
	{
		current = transform.position;
		SwordVelocityValue = (current - previous).magnitude / Time.deltaTime;
		velocityNonABS = PlayerVelocity.PlayerVelocityValue - SwordVelocityValue;
		velocity = Math.Abs(velocityNonABS);
		previous = transform.position;
	}

	public virtual void Die()
	{
		if (spawnWhenDestroyed != null)
		{
			GameObject.Instantiate(spawnWhenDestroyed, this.transform.position, this.transform.rotation);
		}

		deathEvents.Invoke();

		if (this.destroyUponDeath)
		{
			Destroy(this.gameObject);
		}
	}

	public virtual void OnCollisionEnter(Collision cdata)
	{
		if (ignoreCollisions)
		{
			return;
		}

		Damager i = cdata.collider.GetComponentInParent<Damager>();
		if (i != null)
		{
			HandleInteraction(i);
		}
		if (destroyUponHit)
		{
			this.Die();
		}
	}

	public virtual void OnTriggerEnter(Collider coll)
	{
		if (ignoreTriggers)
		{
			return;
		}

		Damager i = coll.GetComponentInParent<Damager>();
		if (i != null)
		{
			HandleInteraction(i);
		}
	}

	public virtual void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (ignoreCharacterControllers)
		{
			return;
		}

		Damager i = hit.collider.GetComponentInParent<Damager>();

		if (i != null)
		{
			HandleInteraction(i);
		}

		if (destroyUponHit)
		{
			this.Die();
		}
	}


	protected virtual void HandleInteraction(Damager other)
	{
		switch (other.myRole)
		{
			case Damager.DamageRole.Player:
				if (velocity > damagePlayerRange1 && velocity < damagePlayerRange2)
				{

					other.TakeDamage(damagePlayer1);
				}
				if (velocity > damagePlayerRange2 && velocity < damagePlayerRange3)
				{

					other.TakeDamage(damagePlayer2);
				}
				if (velocity > damagePlayerRange3 && velocity < damagePlayerRange4)
				{

					other.TakeDamage(damagePlayer3);
				}
				if (velocity > damagePlayerRange4)
				{

					other.TakeDamage(damagePlayer4);
				}
				break;

			case Damager.DamageRole.Enemy:
				if (velocity > damageEnemyRange1 && velocity < damageEnemyRange2)
				{
					other.TakeDamage(damageEnemy1);
				}
				if (velocity > damageEnemyRange2 && velocity < damageEnemyRange3)
				{
					other.TakeDamage(damageEnemy2);
				}
				if (velocity > damageEnemyRange3 && velocity < damageEnemyRange4)
				{
					other.TakeDamage(damageEnemy3);
				}
				if (velocity > damageEnemyRange4)
				{
					other.TakeDamage(damageEnemy4);
				}
				break;

			case Damager.DamageRole.Other:
				if (velocity > damageOtherRange1 && velocity < damageOtherRange2)
				{
					other.TakeDamage(damageOther1);
				}
				if (velocity > damageOtherRange2 && velocity < damageOtherRange3)
				{
					other.TakeDamage(damageOther2);
				}
				if (velocity > damageOtherRange3 && velocity < damageOtherRange4)
				{
					other.TakeDamage(damageOther3);
				}
				if (velocity > damageOtherRange4)
				{
					other.TakeDamage(damageOther4);
				}
				break;

			default:
				break;
		}
	}

	public virtual void TakeDamage(float damage)
	{

		if (!_invincible)
		{

			this._curHealth -= damage;

			if (livesDisplay != null)
			{
				livesDisplay.UpdateLives(currentHealth);
			}

			damageEvents.Invoke();

			if (this._curHealth <= 0f)
			{
				this.Die();
			}

			if (this.invincTime > 0f)
			{
				StartCoroutine(InvincibilityCoroutine(Time.fixedTime + invincTime));
			}
		}
	}

	public virtual void RecoverHealth(float health)
	{
		this._curHealth = Mathf.Min(this._curHealth + health, this.maxHealth);

		if (livesDisplay != null)
		{
			livesDisplay.UpdateLives(currentHealth);
		}
	}

	private IEnumerator InvincibilityCoroutine(float endTime)
	{
		bool meshOn = false;
		MeshRenderer[] renderers = this.GetComponentsInChildren<MeshRenderer>();
		_invincible = true;

		if (invincibleMaterial != null)
		{
			// we have a cool color-blinking thing going on
			Dictionary<MeshRenderer, Material> prevMaterial = new Dictionary<MeshRenderer, Material>();
			foreach (MeshRenderer mr in renderers)
			{
				prevMaterial[mr] = mr.material;
			}
			while (Time.fixedTime < endTime)
			{
				foreach (MeshRenderer mr in renderers)
				{
					mr.material = meshOn ? prevMaterial[mr] : invincibleMaterial;
				}
				meshOn = !meshOn;
				yield return new WaitForSeconds(blinkTime);
			}
			foreach (MeshRenderer mr in renderers)
			{
				mr.material = prevMaterial[mr];
			}

		}
		else
		{
			// just blink!
			while (Time.fixedTime < endTime)
			{
				foreach (MeshRenderer mr in renderers)
				{
					mr.enabled = meshOn;
				}
				meshOn = !meshOn;
				yield return new WaitForSeconds(blinkTime);
			}
			foreach (MeshRenderer mr in renderers)
			{
				mr.enabled = true;
			}
		}
		_invincible = false;
	}
}
