#pragma strict

var topLid : GameObject;
var bottomLid : GameObject;
private var anim1 : Animation;
private var anim2 : Animation;

var timer : float = 10.0;

private var blink : boolean = false;

function Start()
{
	topLid = GameObject.Find("EyeLid_Top");
	bottomLid = GameObject.Find("EyeLid_Bottom");
	anim1 = GetComponent("BlinkingTop");
	anim2 = GetComponent("BlinkingBottom");
}

function Update()
{
	timer -= Time.deltaTime;
	
	if(timer <= 0)
	{
		timer = 2;
		blink = true;
	}
	
	if(blink == true)
	{
		anim1.Play();
		anim2.Play();

		blink = false;
	}
}