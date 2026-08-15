using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int playerScore;
    public int PlayScore {  get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPositons;
    
    [SerializeField]
    private GameObject ballPrefabs;

    [SerializeField]
    private GameObject cueball;

    [SerializeField]
    private float xInput = 0f;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shootball();

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.1f;
        else
            xInput = 0f;
    }

    private void SetBall(BallColor col, int i)
    {
        GameObject obj = Instantiate(ballPrefabs,
                                     ballPositons[i].transform.position,
                                     Quaternion.identity);
        Ball b = obj.GetComponent<Ball>();
        b.SetColor(col);
    }

    private void Shootball()
    {
        Rigidbody rd  = cueball.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
    }

    private void RotateBall()
    {
        if (cueball != null)
            cueball.transform.Rotate(new Vector3(0f, xInput, 0f));
    }
}
