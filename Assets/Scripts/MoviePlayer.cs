using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class MoviePlayer : MonoBehaviour
{

	public VideoClip AlcoholClip;
	
	public VideoClip LsdClip;

	public VideoClip CokeClip;

	//public Material onMaterial;
	//public Material offMaterial;

	private Color screen_On = Color.white;
	private Color screen_Off = Color.black;
	
	private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;
	private Material _material;

	//private AudioSource audio;
	// Use this for initialization
	void Start ()
	{
		// Getting videoPlayer component
		_videoPlayer = GetComponent<VideoPlayer>();

		// Getting material component
		_material = GetComponent<Renderer> ().material;
		_material.color = screen_Off;

        // Getting AudioSOurce
        _audioSource = GetComponent<AudioSource>();

        //Arranging audio
        _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        _videoPlayer.SetTargetAudioSource(0, _audioSource);
        _videoPlayer.source = VideoSource.VideoClip;
        
        //_videoPlayer.clip = AlcoholClip;
		//_videoPlayer.Play ();

		//PlayAlcoholClip();
	}

	public void Update()
	{
		// Escape has been pressed
		if (Input.GetKeyDown(KeyCode.Escape) && _videoPlayer.isPlaying){
			pauseClip();
			return;
		}
		if (Input.GetKeyDown(KeyCode.Escape) && !_videoPlayer.isPlaying){
			playClip();
			return;
		}
		
	
	}

	public void stopClip(){
		_videoPlayer.Stop ();
		_material.color = screen_Off;
	}

	public void pauseClip(){
		_videoPlayer.Pause ();
	}

	public void playClip(){
		_videoPlayer.Play ();
	}


	public void ChangeMaterial(){
		if (_material.color ==  screen_On) {
			_material.color = screen_Off;
		} else {
			_material.color = screen_On;
		}
	}

	public void PlayAlcoholClip()
	{
		
		if (_material.color == screen_Off){
			_material.color = screen_On;
		}
		_videoPlayer.clip = AlcoholClip;

		_videoPlayer.Stop ();
		_videoPlayer.Play();
	}

	public void PlayLsdClip()
	{
		if (_material.color == screen_Off){
			_material.color = screen_On;
		}

		_videoPlayer.clip = LsdClip;

		_videoPlayer.Stop ();
		_videoPlayer.Play();
	}

	public void PlayCokeClip()
	{
		if (_material.color == screen_Off){
			_material.color = screen_On;
		}
		_videoPlayer.clip = CokeClip;

		_videoPlayer.Stop ();
		_videoPlayer.Play();
	}

	public void Exit(){
		SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
	}
}
