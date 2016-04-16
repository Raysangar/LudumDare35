using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	public ParticleSystem particle00;

	[ContextMenu("Activate Particle")]
	public void ActivateParticle(){
		
		ResetParticles();
		particle00.Play(true);
	}

	[ContextMenu("Reset Particle")]
	public void ResetParticles(){
		
		particle00.enableEmission =  true;
	}
}
