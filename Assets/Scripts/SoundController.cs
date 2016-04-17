using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public AudioClip Act01Track;
	public AudioClip Act02Track;
	public AudioClip Act03Track;

	public AudioClip Boo00;
	public AudioClip Boo01;
	public AudioClip Clap00;
	public AudioClip Clap01;
	public AudioClip House;
	public AudioClip PigLaugh;
	public AudioClip PigYell;
	public AudioClip SmokeBomb;
	public AudioClip WolfScare;
	public AudioClip WolfBlow;

	private AudioSource sourceMusic;

	void Play(AudioClip clip){

		GameObject go = new GameObject ("Audio");
		AudioSource source = go.AddComponent<AudioSource>();
		source.clip 	= clip;
		source.volume 	= 1.0f;
		source.loop 	= false;
		source.Play();

		Destroy(go,source.clip.length);
	}

	//Tracks
	void PlayActTrack(int trackNumber) {

		if(sourceMusic == null) {

			GameObject go 		= new GameObject ("Audio");
			sourceMusic 		= go.AddComponent<AudioSource>();
			sourceMusic.volume 	= 1.0f;
			sourceMusic.loop 	= true;
		}

		switch (trackNumber){
			case 1:
				sourceMusic.clip = Act01Track;
				break;
			case 2:
				sourceMusic.clip = Act02Track;
				break;
			case 3:
				sourceMusic.clip = Act03Track;
				break;
		}
	
		sourceMusic.Play();
	}
		
	public void PlayTransitionTo(SoundType soundType){
		switch (soundType){
			case SoundType.Act01Track:

				PlayActTrack(01);
				break;
			case SoundType.Act02Track:

				PlayActTrack(02);
				break;
			case SoundType.Act03Track:

				PlayActTrack(03);
				break;
			case SoundType.Boo00:

				Play(Boo00);
				break;
			case SoundType.Boo01:

				Play(Boo01);
				break;
			case SoundType.Clap00:

				Play(Clap00);
				break;
			case SoundType.Clap01:

				Play(Clap01);
				break;
			case SoundType.House:

				Play(House);
				break;
			case SoundType.PigLaugh:

				Play(PigLaugh);
				break;
			case SoundType.PigYell:

				Play(PigYell);
				break;
			case SoundType.SmokeBomb:

				Play(SmokeBomb);
				break;
			case SoundType.WolfScare:

				Play(WolfScare);
				break;
			case SoundType.WolfBlow:

				Play(WolfBlow);
				break;
		}
	}
}
