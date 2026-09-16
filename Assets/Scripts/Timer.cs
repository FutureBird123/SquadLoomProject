using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    float elapsedTime = 0f;

    [SerializeField] private GameObject quantumFluxText;
    [SerializeField] private GameObject quantumFluxActivateText;
    [SerializeField] private TextMeshProUGUI quantumFluxCountDown;
    [SerializeField] private GameObject quantumFluxCountDownGameObject;
    float CountdownTime = 4f;

    public GameObject enemy;
    private EnemyShooting enemyShootingScript;
    private bool isEnemySpeedBoosted = false;

    public GameObject enemyProjectile;
    private Projectile enemyProjectileScript;
    private bool isEnemyProjectileSpeedBoosted = false;

    public GameObject enemySpawner;
    private EnemySpawner enemySpawnerScript;
    private bool isEnemySpawnIntervalReduced = false;

    public GameObject player1UI;
    public GameObject player1AltUI;
    public GameObject player2UI;
    public GameObject player2AltUI;
    private bool swap1 = false;
    private bool swap2 = false;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if((elapsedTime>=15f && elapsedTime<=22) || elapsedTime>=35f)
        {
            quantumFluxText.SetActive(true);
            
        }
        if((elapsedTime>=17f && elapsedTime <= 22) || elapsedTime>=37f)
        {
            CountdownTime -= Time.deltaTime;
            quantumFluxCountDownGameObject.SetActive(true);
            //int countdownSeconds = Mathf.FloorToInt(CountdownTime % 60f);
            //quantumFluxCountDown.text = string.Format("{0:00}:{1:00}", minutes, countdownSeconds);
            int countdownSeconds = Mathf.FloorToInt(CountdownTime);
            quantumFluxCountDown.text = string.Format("{0:00}", countdownSeconds);
        }
        if ((elapsedTime>=20f && elapsedTime <= 22) || elapsedTime>=40f)
        {
            quantumFluxText.SetActive(false);
            quantumFluxCountDownGameObject.SetActive(false);
            quantumFluxActivateText.SetActive(true);
            //enemy speed boost code
            if(!isEnemySpeedBoosted)
            {
                enemyShootingScript = enemy.GetComponent<EnemyShooting>();
                if (enemyShootingScript != null)
                {
                    enemyShootingScript.movementSpeed *= 1.25f;
                    isEnemySpeedBoosted = true;
                    Debug.Log("Enemy speed boosted!");
                }
            }
            // swap UI code
            if(!swap1)
            {
                player1UI.SetActive(false);
                player1AltUI.SetActive(true);
                player2UI.SetActive(false);
                player2AltUI.SetActive(true);
                swap1 = true;
            }
            if(!swap2 && elapsedTime>=40)
            {
                player1UI.SetActive(true);
                player1AltUI.SetActive(false);
                player2UI.SetActive(true);
                player2AltUI.SetActive(false);
                swap2 = true;
            }
            //enemy projectile speed boost code
            if (!isEnemyProjectileSpeedBoosted && elapsedTime>=40)
            {
                enemyProjectileScript = enemyProjectile.GetComponent<Projectile>();
                if (enemyProjectileScript != null)
                {
                    enemyProjectileScript.projectileSpeed *= 1.5f;
                    isEnemyProjectileSpeedBoosted = true;
                    Debug.Log("Enemy projectile speed boosted");
                }
            }
            //less spawn interval code
            if(!isEnemySpawnIntervalReduced && elapsedTime>=40)
            {
                enemySpawnerScript = enemySpawner.GetComponent<EnemySpawner>();
                if (enemySpawnerScript != null)
                {
                    enemySpawnerScript.spawnDelay *= 0.75f;
                    isEnemySpawnIntervalReduced = true;
                    Debug.Log("Enemy spawn interval reduced");
                }
            }

        }
        if ((elapsedTime>=22f && elapsedTime <= 30f) || elapsedTime>=42f)
        {
            quantumFluxActivateText.SetActive(false);
            CountdownTime = 4f;
        }
        if(elapsedTime>=60f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
