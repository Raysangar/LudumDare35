using UnityEngine;
using System.Collections;

public class EndActionController : MonoBehaviour {

	public Light[] lightsToAttenuate;
	public float attenuationValue;
	public Material[] materials;

	private bool att;

	public void AttenuateAll(){
		foreach (Light light  in lightsToAttenuate) {
			if(light.intensity != 0){
				light.intensity -= Time.deltaTime*attenuationValue;
			}
		}
	}

	public void Update(){
		if(att){
			AttenuateAll();
		}
	}

	public void ActivateAttenuate(){
		att = true;
	}
}
