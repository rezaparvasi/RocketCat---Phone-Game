using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CATController : MonoBehaviour {

	public float jetpackForce = 75.0f;

	public float forwardMovementSpeed = 3.0f;

	public Transform groundCheckTransform;
	
	private bool grounded;
	
	public LayerMask groundCheckLayerMask;
	
	Animator animator;

	public ParticleSystem jetpack;

	private bool dead = false;

	static uint coins = 0;

	public Texture2D coinIconTexture;

	public AudioClip coinCollectSound;

	public AudioSource jetpackAudio;
	
	public AudioSource footstepsAudio;

	public ParallaxScroll parallax;


	//timer variables
	float timeLeft = 20.0f;
	public Text timeIsUp;
	public Text timerText;

	// Use this for initialization
	void Start () {

		coins = 0;
		animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
		Timer ();
	
	}

	void FixedUpdate () 
	{
		bool jetpackActive = Input.GetButton("Fire1");
		
		jetpackActive = jetpackActive && !dead;
		
		if (jetpackActive)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jetpackForce));
		}
		
		if (!dead)
		{
			Vector2 newVelocity = GetComponent<Rigidbody2D>().velocity;
			newVelocity.x = forwardMovementSpeed;
			GetComponent<Rigidbody2D>().velocity = newVelocity;
		}
		
		UpdateGroundedStatus();
		
		AdjustJetpack(jetpackActive);

		AdjustFootstepsAndJetpackSound(jetpackActive);

		parallax.offset = transform.position.x;
	} 

	void UpdateGroundedStatus()
	{
		//1
		grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
		
		//2
		animator.SetBool("grounded", grounded);
	}

	void AdjustJetpack (bool jetpackActive)
	{
		jetpack.enableEmission = !grounded;
		jetpack.emissionRate = jetpackActive ? 300.0f : 75.0f; 

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.CompareTag("Coins"))
			CollectCoin(collider);
		else
			HitByLaser(collider);
	}
		
	void HitByLaser(Collider2D laserCollider)
	{
		if (!dead)
			laserCollider.gameObject.GetComponent<AudioSource>().Play();

		dead = true;

		animator.SetBool("dead", true);
	}

	void CollectCoin(Collider2D coinCollider)
	{
		coins++;
		
		Destroy(coinCollider.gameObject);

		AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);
	}

	void OnGUI()
	{
		DisplayCoinsCount();

		DisplayRestartButton();
	}

	void DisplayCoinsCount()
	{
		Rect coinIconRect = new Rect(10, 10, 32, 32);
		GUI.DrawTexture(coinIconRect, coinIconTexture);                         
		
		GUIStyle style = new GUIStyle();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.yellow;
		
		Rect labelRect = new Rect(coinIconRect.xMax, coinIconRect.y, 60, 32);
		GUI.Label(labelRect, coins.ToString(), style);
	}

	void DisplayRestartButton()
	{
		if (dead && grounded)
		{
			//Rect buttonRect = new Rect(Screen.width * 0.35f, Screen.height * 0.45f, Screen.width * 0.30f, Screen.height * 0.1f);
			//if (GUI.Button(buttonRect, "Tap to restart!"))
			//{
			//	Application.LoadLevel (Application.loadedLevelName);
			//};
			PlayerStats.Points=coins;
			Invoke ("GoToMenu", 1.0f);

		}
	}

	void Timer ()
	{
		timeLeft -= Time.deltaTime;
		timerText.text = Mathf.Round(timeLeft) + "s";
		if(timeLeft < 0)
		{
			PlayerStats.Points=coins;
			timerText.text = "No Time";
			timeIsUp.text = "YOUR TIME IS UP!";
			Invoke ("GoToMenu", 2.0f);
		}

	}

	void AdjustFootstepsAndJetpackSound(bool jetpackActive)    
	{
		footstepsAudio.enabled = !dead && grounded;
		
		jetpackAudio.enabled =  !dead && !grounded;
		jetpackAudio.volume = jetpackActive ? 1.0f : 0.5f;        
	}

	void GoToMenu(){
		SceneManager.LoadScene ("Menu");
	}

}
