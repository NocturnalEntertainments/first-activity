using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * moveSpeed;


        moveX *= Time.deltaTime;
        moveY *= Time.deltaTime;

        Vector2 movement = new Vector2(moveX, moveY);


        transform.Translate(movement);
    }
}
