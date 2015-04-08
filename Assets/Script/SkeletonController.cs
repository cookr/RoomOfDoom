﻿using UnityEngine;
using System.Collections;

public class SkeletonController : BaseEnemy {
	public GameObject bone;
	public int shotSpeed = 1000;
	public GameObject launchBox;
	public int launchBoxRotatationSpeed;

	private bool coolDown;
	private float coolDownDuration;
	
	void Start()
	{
		base.Start(); //call BaseEnemy's start function
		coolDownDuration = 1.0f;
		coolDown = false;
	}
	
	void Update()
	{
		if(IsDead) //check if enemy has been killed before updating
			return;
		base.Update();
		transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
		direction = player.transform.position - transform.position;

		launchBox.transform.RotateAround (transform.position, Vector3.forward, launchBoxRotatationSpeed * Time.deltaTime);

		if(coolDown)
		{
			if(coolDownDuration < 0)
			{
				coolDown = false;
				coolDownDuration = 1.0f;
			}
			else
				coolDownDuration -= Time.deltaTime;
		}
		else
			ThrowBone();

	}

	void ThrowBone()
	{
		if(direction.magnitude < 25)
		{
			direction.Normalize ();
			GameObject shot = Instantiate(bone, launchBox.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
			shot.rigidbody2D.AddForce(direction * shotSpeed);
			coolDown = true;
		}
	}
}
