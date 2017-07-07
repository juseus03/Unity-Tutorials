using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public Sprite dmgSprite;
	public int hp = 4;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent <SpriteRenderer> ();
	}
	

	public void DamageWall (int loss) 
	{
		spriteRenderer.sprite = dmgSprite; //Change sprite
		hp -= loss; // substracts damage

		if (hp <= 0)  //Checks if continue showing the wall
		{
			gameObject.SetActive (false);
		}
	}
}
