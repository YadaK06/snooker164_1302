using System;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
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
    private GameObject ballLine;

   [SerializeField]
    private float xInput = 0f;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private TMP_Text notitext;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CameraBehideCueball();

        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);

        if(Setting.fromSave)
            LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Shootball();

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.5f;

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.5f;
        else
            xInput = 0f;

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();

        if (Keyboard.current.leftShiftKey.isPressed)
            SaveGame();
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

        ballLine.SetActive(false);
        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 60f, 0f);
        cam.transform.eulerAngles = new Vector3(90f, 0f, 0f);
    }

    private void RotateBall()
    {
        if (cueball != null)
            cueball.transform.Rotate(new Vector3(0f, xInput, 0f));
    }

    private void StopBall()
    {
        Rigidbody rb = cueball.GetComponent<Rigidbody>();
        rb. linearVelocity = Vector3.zero;
        rb. angularVelocity = Vector3.zero;
        cueball.transform.eulerAngles = new Vector3(0f, 0f, 0f);

        ballLine.SetActive(true);
        CameraBehideCueball();
    }

    private void CameraBehideCueball()
    {
        cam.transform.parent = cueball.transform;
        cam.transform.position = cueball.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }

    public void ShowscoreText(int n)
    {
        playerScore += n;
        notitext.text = $"Ball Point: {n}\nTotal Score: {playerScore}";

    }

    public void ShowString(string s)
    {
        notitext.text = s;

    }

    public void SaveGame()
    {
        StopBall();
        if (cueball != null )
        {
            PlayerPrefs.SetFloat("cueBallPosX", cueball.transform.position.x);
            PlayerPrefs.SetFloat("cueBallPosX", cueball.transform.position.y);
            PlayerPrefs.SetFloat("cueBallPosX", cueball.transform.position.z);
            Debug.Log("Saved");
        }
    }

    public void LoadGame()
    {
        if (cueball != null)
        {
            float x = PlayerPrefs.GetFloat("cueBallPosx");
            float y = PlayerPrefs.GetFloat("cueBallPosx");
            float z = PlayerPrefs.GetFloat("cueBallPosx");
            Debug.Log("Loaded");
        }
    }
}
