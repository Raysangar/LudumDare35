using UnityEngine;
using System.Collections;

public class ConstructController : MonoBehaviour {

	public GameObject CardboardHouse;
	public GameObject WoodHouse;
	public GameObject BrickHouse;

	public Transform housePosition;

	public GameObject actualHouse;

	public void InstantianteCardboardHouse(){
		actualHouse = (GameObject) Instantiate(CardboardHouse, housePosition.position, CardboardHouse.transform.rotation);
	}
	public void InstantianteWoodHouse(){
		actualHouse = (GameObject) Instantiate(WoodHouse, housePosition.position, WoodHouse.transform.rotation);
	}
	public void InstantianteBrickHouse(){
		actualHouse = (GameObject) Instantiate(BrickHouse, housePosition.position, BrickHouse.transform.rotation);
	}

	public void CleanHouses(){
		Destroy(actualHouse);
	}

	public void CloseDoor(){
		actualHouse.GetComponent<AnimController>().CloseDoor();
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
