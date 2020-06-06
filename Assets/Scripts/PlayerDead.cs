using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver = null;
    [SerializeField]
    private GameObject player = null;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if (player == null)
        {
            KillPlayer();
        }
    }
    private void KillPlayer()
    {
        Destroy(player);
        gameOver.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
