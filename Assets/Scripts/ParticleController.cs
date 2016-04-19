using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

	public 	ParticleSystem 		particle00;
	public 	GameObject			particlesPrefab;
	public	float				scaleFactor;

	private Animator			animatorParticles;

	void Start(){
	
		particlesPrefab = Instantiate(particlesPrefab,this.transform.position, particlesPrefab.transform.rotation) as GameObject;
		animatorParticles = particlesPrefab.GetComponent<Animator>();
		particlesPrefab.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
	}

	[ContextMenu("Activate Particle")]
	public void ActivateParticle(){
		
		ResetParticles();

		Transform trCamera = Camera.main.transform;
		Vector3 direction = (trCamera.position - transform.position).normalized;

		animatorParticles.transform.position = transform.position + (direction * 1.5f);
		animatorParticles.CrossFade("SmokeAnim", 0.0f);

		Invoke("ResetParticles2", 2.0f);
	}

	[ContextMenu("Reset Particle")]
	public void ResetParticles(){
      ParticleSystem.EmissionModule emissionModule = particle00.emission;
      emissionModule.enabled = true;
		animatorParticles.CrossFade("None", 0.0f);
	}

	private void ResetParticles2(){

		animatorParticles.CrossFade("None", 0.0f);
	}
}
