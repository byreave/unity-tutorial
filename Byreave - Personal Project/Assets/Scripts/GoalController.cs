using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public int ScoreToGain = 5;

    [SerializeField] private AudioClip GoalSFX;
    [SerializeField] private AudioClip MissSFX;
    [SerializeField] private ParticleSystem GoalParticle;
    [SerializeField] private ParticleSystem MissParticle;

    [SerializeField] private float xBound;
    [SerializeField] private float zBound;

    [SerializeField] GameObject GoodBall;
    [SerializeField] GameObject BadBall;

    [SerializeField] GoalController AnotherGoal;

    private float rotateSpeed = 120.0f;
    private GameManager gameManager;
    private AudioSource audioSource;
    private Transform playerTrans;
    public int WallNumber = 1; //which wall the goal is on
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        playerTrans = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    IEnumerator SpeedUp(float time, float multiplier)
    {
        rotateSpeed *= multiplier;
        yield return new WaitForSeconds(time);
        rotateSpeed /= multiplier;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(GoodBall.tag))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(ScoreToGain);
            StartCoroutine(SpeedUp(1.0f, 2.0f));
            audioSource.PlayOneShot(GoalSFX);
            Instantiate(GoalParticle, transform.position, GoalParticle.transform.rotation);
            float spawnX = playerTrans.position.x + Random.Range(-4, 4);
            Debug.Log(playerTrans.position.x);
            float spawnZ = playerTrans.position.z + Random.Range(-5, 5);
            Instantiate(GoodBall, new Vector3(spawnX, GoodBall.transform.position.y, spawnZ), GoodBall.transform.rotation);
            MoveToAnotherPlace();
        }
        else if (collision.gameObject.CompareTag(BadBall.tag))
        {
            Destroy(collision.gameObject);
            gameManager.AddScore(-ScoreToGain);
            StartCoroutine(SpeedUp(1.0f, 0.5f));
            audioSource.PlayOneShot(MissSFX);
            Instantiate(MissParticle, transform.position, GoalParticle.transform.rotation);
            float spawnX = playerTrans.position.x + Random.Range(-4, 4);
            Debug.Log(playerTrans.position.x);
            float spawnZ = playerTrans.position.z + Random.Range(-5, 5);
            Instantiate(BadBall, new Vector3(spawnX, GoodBall.transform.position.y, spawnZ), BadBall.transform.rotation);
        }
    }


    void MoveToAnotherPlace()
    {
        WallNumber = Random.Range(0, 4);

        while (WallNumber == AnotherGoal.WallNumber)
        {
            WallNumber = Random.Range(0, 4);
        }

        switch(WallNumber)
        {
            case 0://left
                transform.localPosition = new Vector3(-xBound, transform.localPosition.y, Random.Range(-zBound, zBound));
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0.0f, transform.eulerAngles.z);
                break;
            case 1://top
                transform.localPosition = new Vector3(Random.Range(-xBound, xBound), transform.localPosition.y, zBound);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90.0f, transform.eulerAngles.z);
                break;
            case 2://right
                transform.localPosition = new Vector3(xBound, transform.localPosition.y, Random.Range(-zBound, zBound));
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0.0f, transform.eulerAngles.z);
                break;
            case 3://down
                transform.localPosition = new Vector3(Random.Range(-xBound, xBound), transform.localPosition.y, -zBound);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 90.0f, transform.eulerAngles.z);
                break;
            default:
                break;
        }
    }
}
