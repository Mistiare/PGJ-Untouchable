using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver = null;
    [SerializeField]
    private GameObject player = null;
    [SerializeField]
    private GameObject deathParticle = null;
    private Vector3 position;
    private Quaternion rotation;
    private bool oneShot;
    [SerializeField]
    private float fadeSpeed = 0;
    private float fade = -1;
    [SerializeField]
    private Image fadeScreen = null;

    private void Start()
    {
        gameOver.SetActive(false);
        oneShot = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(player);
        }
        if (player == null)
        {
            fade += fadeSpeed;
            fadeScreen.color = new Color(0, 0, 0, fade);

            if (fadeScreen.color.a > 1)
            {
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
            

            if (oneShot)
            {
                GameObject particle = Instantiate(deathParticle, position, rotation);
                particle.transform.GetComponent<ParticleSystem>().Play();

                oneShot = false;
            }
        }

        else
        {
            position = player.transform.position;
            rotation = player.transform.rotation;
        }
    }
}
