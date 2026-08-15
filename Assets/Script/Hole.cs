using Unity.VisualScripting;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball b = other.GetComponent<Ball>();
        if (b != null )
        {
            if (b.Point == 0)
            {
                GameManager.instance.ShowString($"White Ball drop\n Lose");
                Time.timeScale = 0f;
            }

            else
            {
                GameManager.instance.ShowscoreText(b.Point);
            }
            Destroy(b.gameObject);
        }
    }
}
