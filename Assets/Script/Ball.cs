using UnityEngine;
using UnityEngine.EventSystems;

public enum BallColor
{
    White,
    Red,
    Yellow,
    Green,
    Brown,
    Blue,
    Pink,
    Black
}
public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;
    public int Point {  get { return point; } set { point = value; } }

    [SerializeField]
    private BallColor color;

    private MeshRenderer rb;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayScore += point;
        Destroy(gameObject);
    }

    void Awake()
    {
        rb = GetComponent<MeshRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(BallColor col)
    {
        switch (col)
        {
            case BallColor.White:
                point = 0;
                rb.material.color = Color.white;
                break;

            case BallColor.Red:
                point = 1;
                rb.material.color = Color.red;
                break;

            case BallColor.Yellow:
                point = 2;
                rb.material.color = Color.yellow;
                break;

            case BallColor.Green:
                point = 3;
                rb.material.color = Color.green;
                break;

            case BallColor.Brown:
                point = 4;
                rb.material.color = Color.brown;
                break;

            case BallColor.Blue:
                point = 5;
                rb.material.color = Color.blue;
                break;

            case BallColor.Pink:
                point = 6;
                rb.material.color = Color.pink;
                break;

            case BallColor.Black:
                point = 7;
                rb.material.color = Color.black;
                break;
        }
    }
}
