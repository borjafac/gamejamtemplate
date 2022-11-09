using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
	public Slider MasterSlider;
	public Slider MusicSlider;
	public Slider SFXSlider;

	public AudioMixerGroup MasterGroup;
	public AudioMixerGroup MusicGroup;
	public AudioMixerGroup SFXGroup;

	public AudioSource LevelMusicAudioSource;

	private void Start()
	{
		InitializeSound();

		if(LevelMusicAudioSource != null)
			LevelMusicAudioSource.Play();
	}

	private void InitializeSound()
	{
		if(MasterSlider != null)
			MasterSlider.onValueChanged.AddListener(SetMasterVolume);

		if(MusicSlider != null)
			MusicSlider.onValueChanged.AddListener(SetMusicVolume);

		if(SFXSlider != null)
			SFXSlider.onValueChanged.AddListener(SetSFXVolume);

		SetSliderValues();
	}

	public void SetMasterVolume(float volume)
	{
		MasterGroup.audioMixer.SetFloat("MasterVolume", volume);
		PlayerPrefs.SetFloat("MasterVolume", volume);
	}

	public void SetMusicVolume(float volume)
	{
		MusicGroup.audioMixer.SetFloat("MusicVolume", volume);
		PlayerPrefs.SetFloat("MusicVolume", volume);
	}

	public void SetSFXVolume(float volume)
	{
		SFXGroup.audioMixer.SetFloat("SFXVolume", volume);
		PlayerPrefs.SetFloat("SFXVolume", volume);
	}

	public void SetSliderValues()
	{
		float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
		MasterSlider.SetValueWithoutNotify(masterVolume);
		MasterGroup.audioMixer.SetFloat("MasterVolume", masterVolume);

		float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
		MusicSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("MusicVolume"));
		MusicGroup.audioMixer.SetFloat("MusicVolume", musicVolume);

		float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
		SFXSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("SFXVolume"));
		SFXGroup.audioMixer.SetFloat("SFXVolume", sfxVolume);
	}

	public void ToggleAccessibility()
	{
		UAP_AccessibilityManager.ToggleAccessibility();
	}

	private void OnDestroy()
	{
		MasterSlider.onValueChanged.RemoveAllListeners();
		MusicSlider.onValueChanged.RemoveAllListeners();
		SFXSlider.onValueChanged.RemoveAllListeners();
	}
}
