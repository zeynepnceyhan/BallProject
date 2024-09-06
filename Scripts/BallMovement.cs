using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    private float speed = 5.0f;
    private float moveAmount = 2.5f;

    private Vector3 startPosition;

    public Text successText;

    void Start()
    {
        startPosition = new(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        if (successText != null)
        {
            successText.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.right * moveAmount * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.left * moveAmount * Time.deltaTime;
        }

        if (gameObject.transform.position.y <= -20.0f)
        {
            RestartGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            RestartGame();
        }

        if (collision.gameObject.CompareTag("Flag"))
        {
            EndGame();
        }
    }

    private void RestartGame()
    {
        gameObject.transform.position = startPosition;
    }

    private void EndGame()
    {
        Debug.Log("Successfu, you are starting again");
        gameObject.transform.position = startPosition;
    }
}
