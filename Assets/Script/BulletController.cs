﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public int damagePoints = 0;

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag != "Player" && other.gameObject.tag != "Enemy")
			Destroy (gameObject);
	}

	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
