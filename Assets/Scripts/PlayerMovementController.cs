using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D body;
    private bool canJump = true;
    private float timeForNextJump = 0f;
    private int jumpsUsed = 0;

    private void Awake() {
        // Can get component here
    }

    // Update is called once per frame
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        if (Input.GetKey(KeyCode.Space)) {
            canJump = Time.time > timeForNextJump && jumpsUsed <= 1;
            if (canJump) {
                body.velocity = new Vector2(body.velocity.x, 8);
                jumpsUsed++;
                timeForNextJump = Time.time + 0.5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("entering");

        // TODO: PUT IN CONDITIONAL TO CHECK IF GROUND
        jumpsUsed = 0;
    }
}
