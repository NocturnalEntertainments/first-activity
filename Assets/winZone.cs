using UnityEngine;
public class winZone : MonoBehaviour
{
    public Transform target;
    public GameObject WinUI;

    private playermovement pmovement;

    private void Start()
    {
        pmovement = target.GetComponent<playermovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2)
        + Mathf.Pow(target.position.y - this.transform.position.y, 2));

        var vectorDist = Vector3.Distance(target.position, this.transform.position);

        if (distance < 1f)
        {
            pmovement.enabled = false;
            WinUI.SetActive(true);
        }
    }

}
