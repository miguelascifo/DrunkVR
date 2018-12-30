using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieManager : MonoBehaviour {

	public  VideoPlayer videoPlayer;

	public VideoClip AlcoholClip;

	public VideoClip LsdClip;

	public VideoClip CokeClip;

	private Color screen_On = Color.white;
	private Color screen_Off = Color.black;

	private  VideoPlayer _videoPlayer;
	private Material _material;



	// Use this for initialization
	void Start () {
		//videoPlayer = GetComponent<Video
		videoPlayer.clip = AlcoholClip;
		videoPlayer.Play();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
