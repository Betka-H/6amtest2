using System;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour, IReset
{
	gameManager gameMan;

	public AudioSource musicSource;
	public AudioSource sfxSource;
	public AudioSource alarmSource;

	public AudioClip[] music;

	[Header("sound effects")]
	public AudioClip sfxBuzzerWrong;
	public AudioClip sfxBuzzerRight;
	public AudioClip sfxExplosion;
	public AudioClip sfxPainting1;
	public AudioClip sfxPainting2;
	public AudioClip sfxButtonPush;
	public AudioClip sfxSmallButtonPushSingle;
	public AudioClip sfxSmallButtonPushDouble;
	public AudioClip sfxSafeCreakOpen;
	public AudioClip sfxSafeCreakClose;
	public AudioClip[] sfxScrewLocked;
	public AudioClip[] sfxScrewTurn;
	public AudioClip[] sfxScrewFall;
	public AudioClip[] sfxWireSnip;
	public AudioClip[] sfxWireSparks;
	public AudioClip[] sfxPaper;
	public AudioClip sfxLever;
	public AudioClip sfxKeyPickup;
	public AudioClip sfxKeyUse;
	public AudioClip sfxCheese;
	public AudioClip sfxAlarm;
	public AudioClip sfxItemPickUp;
	public AudioClip sfxDrawerOpen;
	public AudioClip sfxDrawerClose;

	[Header("sliders")]
	public Slider musicSlider;
	public Slider sfxSlider;

	void Start()
	{
		gameMan = FindObjectOfType<gameManager>();

		adjustVolume();

		musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
		sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1);

		adjustVolume();

		// Debug.Log("check all coroutines - resetting before it finishes messes stuff up");

		playMusic();
	}

	public void playSfx(AudioClip clip)
	{
		sfxSource.PlayOneShot(clip);
	}

	public void playRandomSfx(AudioClip[] clips)
	{
		sfxSource.PlayOneShot(clips[UnityEngine.Random.Range(0, clips.Length)]);
	}

	public void playAlarm()
	{
		alarmSource.PlayOneShot(sfxAlarm);
		Invoke("playAlarm", sfxAlarm.length);
	}
	public void alarmVolumeLow()
	{
		// Debug.Log("low");
		alarmSource.volume = sfxSource.volume * 0.25f;
	}
	public void alarmVolumeHigh()
	{
		// Debug.Log("high");
		alarmSource.volume = sfxSource.volume;
	}


	public void adjustVolume()
	{
		musicSource.volume = musicSlider.value;
		sfxSource.volume = sfxSlider.value;
	}

	int prevTrackNumber = -1;
	int trackNumber = -1;
	void playMusic()
	{
		while (trackNumber == prevTrackNumber)
		{
			trackNumber = UnityEngine.Random.Range(0, music.Length);
			if (trackNumber == prevTrackNumber)
			{
				// Debug.Log("skipping track " + trackNumber);
			}
		}
		Debug.LogWarning("playing music track " + trackNumber + ": " + music[trackNumber].name);
		musicSource.clip = music[trackNumber];
		prevTrackNumber = Array.IndexOf(music, musicSource.clip);
		musicSource.Play();
		Invoke("playMusic", musicSource.clip.length);
	}

	public void resetState()
	{
		sfxSource.Stop();
	}

	void OnApplicationQuit()
	{
		gameMan.saveFloat("musicVolume", musicSlider.value);
		gameMan.saveFloat("sfxVolume", sfxSlider.value);
	}
}