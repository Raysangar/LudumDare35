﻿using UnityEngine;
using System.Collections;

public class ConstructController : MonoBehaviour {

	public GameObject CardboardHouse;
	public GameObject WoodHouse;
	public GameObject BrickHouse;

	public Transform housePosition;

	public void InstantianteCardboardHouse(){
		Instantiate(CardboardHouse, housePosition.position, Quaternion.identity);
	}
	public void InstantianteWoodHouse(){
		Instantiate(WoodHouse, housePosition.position, Quaternion.identity);
	}
	public void InstantianteBrickHouse(){
		Instantiate(BrickHouse, housePosition.position, Quaternion.identity);
	}

	public void ConstructHouseByType(BuildType type){
		switch(type){
		case BuildType.Cardboard:
			InstantianteCardboardHouse();
			break;
		case BuildType.Wood:
			InstantianteWoodHouse();
			break;
		case BuildType.Brick:
			InstantianteBrickHouse();
			break;
		}
	}
}