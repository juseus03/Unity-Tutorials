using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
    private int count;

	public float speed;
    public Text countText;
    public Text winText;

	void Start() {
		rb = GetComponent<Rigidbody> ();
        count = 0;
        winText.text = "";
        SetCountText();
    }

	// Update is called once per frame
	void Update () {
		
	}

	//Update when physics is going to happen
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		rb.AddForce(movement*speed);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
            winText.text = "You Win !!!!!";
    }
}
