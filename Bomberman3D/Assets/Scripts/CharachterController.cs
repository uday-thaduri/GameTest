using UnityEngine;
using UnityEngine.UI;

public class CharachterController : MonoBehaviour
{
    Animator mummyAnim;
    Rigidbody rb;
    Transform myTrasform;
    public  float moveSpeed = 1.5f;
    public bool canMove = true;
    public bool canDropBombs = true;
    public GameObject bombPrefab;
    public bool dead = false;
    public StateManager stateManager;

    public Text BombText;

     public int bombCount = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTrasform = transform;
        mummyAnim = myTrasform.Find("mummy_rig").GetComponent<Animator>();
        BombText.text = "Bomb " + bombCount.ToString();
    }

    void Update()
    {
        mummyAnim.SetBool("Run", false);
        BombText.text = "Bomb " + bombCount.ToString();
        if (!canMove)
        {
            return;
        }
        PlayerMovement();
    }

    public void PlayerMovement()
    {   
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -moveSpeed);
            myTrasform.rotation = Quaternion.Euler(0, 180, 0);
            mummyAnim.SetBool("Run", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);
            myTrasform.rotation = Quaternion.Euler(0, 90, 0);
            mummyAnim.SetBool("Run", true);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, rb.velocity.z);
            myTrasform.rotation = Quaternion.Euler(0, 270, 0);
            mummyAnim.SetBool("Run", true);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
            myTrasform.rotation = Quaternion.Euler(0, 0, 0);
            mummyAnim.SetBool("Run", true);
        }
        if (canDropBombs && (Input.GetKeyDown(KeyCode.Space)))
        {
            if (bombCount >0)
            {
                DropBomb();
                bombCount--;
            }
            
        }
    }

    void DropBomb()
    {
        if (bombPrefab)
        {
            
                Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(myTrasform.position.x), Mathf.RoundToInt(myTrasform.position.y), Mathf.RoundToInt(myTrasform.position.z)), bombPrefab.transform.rotation);
 
            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            dead = true;
            stateManager.Loose();
            mummyAnim.SetBool("Die", true);
            gameObject.SetActive(false);
           
        }
        if (other.CompareTag("Diamond"))
        {
            stateManager.Win();
            Destroy(other.gameObject);
            gameObject.SetActive(false);

        }
        if (other.CompareTag("BombPickup"))
        {
            BombExplosion.explosionSpread = 3;
            Destroy(other.gameObject);
            stateManager.StausText("Explosion");
        }
        if (other.CompareTag("SpeedPickup"))
        {
            moveSpeed = 2f;
            Destroy(other.gameObject);
            stateManager.StausText("Run");
        }
        if (other.CompareTag("BombCount"))
        {
            bombCount += 5;
            Destroy(other.gameObject);
        }


    }
}