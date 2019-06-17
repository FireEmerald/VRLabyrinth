using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetectionWithDamage : MonoBehaviour
{	
	public GameObject walls;
	
	[Range(1.0f, 100.0f)]
	public float MaxHealth = 100.0f;
	
	[Range(0.0f, 5.0f)]
	public float deathFader = 1.0f;
	
	public GameObject DamageOverlayImage;
	
	public Color normalColor;
	public Color collisionColor;
	
	[Range(1.0f, 10.0f)]
	public float fadeTime = 5.0f;
		
	private Image imageComponent;
	private bool isColliding;
	private float currentHealth;
	
	private Vector3 StartPosition;
	
	void Start()
	{
		imageComponent = DamageOverlayImage.GetComponent<Image>();
		currentHealth = MaxHealth;
		StartPosition = transform.position;
	}
	
	void Update()
	{
		if (isColliding)
		{
			imageComponent.color = Color.Lerp(imageComponent.color, collisionColor, fadeTime * Time.deltaTime);
			currentHealth = Mathf.Lerp(currentHealth, 0.0f, deathFader * Time.deltaTime);
		} else {
			imageComponent.color = Color.Lerp(imageComponent.color, normalColor, fadeTime * Time.deltaTime);
			currentHealth = Mathf.Lerp(currentHealth, MaxHealth, deathFader * Time.deltaTime);
		}
		
		//Debug.Log("currentHealth: " + currentHealth);
		
		if (currentHealth < 0.5f)
		{
			Debug.Log("I'm dead");
			transform.position = StartPosition;
			currentHealth = MaxHealth;
		}
	}

    void OnCollisionEnter (Collision col)
	{		
		if (col.gameObject.name == walls.name) {
			isColliding = true;
		}
	}
	
	void OnCollisionExit (Collision col)
	{
		if (col.gameObject.name == walls.name) {
			isColliding = false;
		}
	}
}
