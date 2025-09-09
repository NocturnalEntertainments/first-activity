using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class noZone : MonoBehaviour
{
    public Transform target;
    public float intensity;

    private Vector2 origPos;
    private SpriteRenderer pSpriteRenderer;
    private playermovement pmovement;
    private void Start()
    {
        pmovement = target.GetComponent<playermovement>();
        pSpriteRenderer = GetComponent<SpriteRenderer>();
        origPos = this.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        this.transform.position = origPos;
        var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2)
        + Mathf.Pow(target.position.y - this.transform.position.y, 2));

        var vectorDist = Vector3.Distance(target.position, this.transform.position);

        if (distance < 1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StartCoroutine("LoseGame");
        }
        else if (distance < 5f)
        {   
            TargetNear();
        }
        else
        {
            pSpriteRenderer.color = Color.white;
        }

    }

    IEnumerator LoseGame()
    {
        pmovement.enabled = false;

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TargetNear()
    {

        var shake = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
        this.transform.position += shake * Time.deltaTime * intensity;

        pSpriteRenderer.color = Color.red;
    }
}
