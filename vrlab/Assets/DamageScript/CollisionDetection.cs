using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
	public GameObject walls;
	
	public GameObject DamageOverlayImage;
	
	public Color normalColor;
	public Color collisionColor;
	
	[Range(1.0f, 10.0f)]
	public float fadeTime = 5.0f;
		
	private Image imageComponent;
	private bool isColliding;
	
	void Start()
	{
		imageComponent = DamageOverlayImage.GetComponent<Image>();
	}
	
	void Update()
	{
		if (isColliding)
		{
			imageComponent.color = Color.Lerp(imageComponent.color, collisionColor, fadeTime * Time.deltaTime);
		} else {
			imageComponent.color = Color.Lerp(imageComponent.color, normalColor, fadeTime * Time.deltaTime);
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
