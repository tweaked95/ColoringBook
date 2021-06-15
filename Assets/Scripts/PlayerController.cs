using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb2d;
    private Collider2D col;
    private MeshRenderer meshRen;
    //private InputControls playerInputs;
    //private Vector3 currentPosition;
    [SerializeField] private LayerMask ground;
    [SerializeField] private List<string> colors = new List<string>(3);

    public float moveSpeed;
    public float jumpHeight;
    public float playerSpeedModifier = 1.0f;
    public float playerJumpModifier = 1.0f;
    public float slowdownFactor = 0.05f;
    public float velMag = 0.0f;

    public UIController uiController;
    public SceneController sceneController;
    public BlockController blockController;
    public AudioController audioController;
    public List<Material> playerMaterials;
    public List<PhysicsMaterial2D> bounceMats;

    public Camera mainCam;
    #endregion

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        meshRen = GetComponent<MeshRenderer>();
        col.sharedMaterial = bounceMats[0];
        rb2d.sharedMaterial = bounceMats[0];
    }

    private void Update()
    {
        Move();
        Jump();
        PickColor();
        OpenSettings();
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        Vector2 movement = new Vector2(moveHorizontal * playerSpeedModifier, 0);
        rb2d.AddForce(movement);
        if (rb2d.velocity.x != 0)
        {
            velMag = rb2d.velocity.magnitude;
        }
        if (playerSpeedModifier == 1)
        {
            if (velMag >= 20)
            {
                velMag = 20;
            }
        }
        else if (playerSpeedModifier == 1.5)
        {
            if (velMag >= 30)
            {
                velMag = 30;
            }
        }
        else
        {
            Debug.Log("Invalid Speed being input");
        }
        //KeepUp();
    }

    #region Jump
    public void Jump()
    {
        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.AddForce(new Vector2(0, jumpHeight * playerJumpModifier), ForceMode2D.Impulse);
                audioController.MakeJumpSound();
            }
        }
    }

    private bool IsGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += col.bounds.extents.x;
        bottomRightPoint.y -= col.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }
    #endregion

    /*private void KeepUp()
    {
        if (transform.rotation.z > 0.5 || transform.rotation.z <= -0.5)
        {
            Debug.Log(transform.rotation);
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles,new Vector3(transform.rotation.x, transform.rotation.y, 0),4*Time.fixedDeltaTime));
        }
    }*/

    public void PickColor()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (colors.Count > 0)
            {
                uiController.OpenColorPicker();
                DoSlowMo();
            }
        }
    }

    public void OpenSettings()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            uiController.OpenSettings();
        }
    }

    public void SetSelfColor(string color)
    {
        if (color == "red")
        {
            meshRen.material = playerMaterials[0];
            SetPublicSpeedModifier(1.5f);
            SetPublicJumpModifier(1);
            SetPublicBounceModifier("normal");
        }

        else if (color == "green")
        {
            meshRen.material = playerMaterials[1];
            SetPublicSpeedModifier(1);
            SetPublicJumpModifier(1.3f);
            SetPublicBounceModifier("normal");
        }

        else if (color == "blue")
        {
            meshRen.material = playerMaterials[2];
            SetPublicSpeedModifier(1);
            SetPublicJumpModifier(1);
            SetPublicBounceModifier("bouncy");
        }

        else if (color == "default")
        {
            meshRen.material = playerMaterials[3];
            SetPublicSpeedModifier(1);
            SetPublicJumpModifier(1);
            SetPublicBounceModifier("normal");
        }
        else
        {
            Debug.Log("Error, wrong color set.");
        }
        NormalTime();
    }

    public void AddColor(string unlockedColor)
    {
        colors.Add(unlockedColor);
        blockController.ChangeMaterialColors(unlockedColor);
        uiController.ShowButton(unlockedColor);
    }

    public void DoSlowMo()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void NormalTime()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.fixedUnscaledDeltaTime;
    }

    void SetPublicSpeedModifier(float val)
    {
        playerSpeedModifier = val;
    }
    void SetPublicJumpModifier(float val)
    {
        playerJumpModifier = val;
    }
    void SetPublicBounceModifier(string type)
    {
        if (type == "normal")
        {
            col.sharedMaterial = bounceMats[0];
            rb2d.sharedMaterial = bounceMats[0];
        }
        else
        {
            col.sharedMaterial = bounceMats[1];
            rb2d.sharedMaterial = bounceMats[1];
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collid = collision.gameObject;
        if (collid.CompareTag("Blocks") && (velMag > 20 || velMag < -20))
        {
            Debug.Log(collid);
            if (collid.GetComponent<BlockController>().blockColor == sceneController.GetCurrentColor())
            {
                collid.SetActive(false);
            }
        }
    }
}
