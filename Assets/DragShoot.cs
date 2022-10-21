using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public GameObject oneCoin;
    public GameObject twoCoin;

    public Vector2 minPower;
    public Vector2 maxPower;

    public GameObject UI;

    TrajectoryLine trajectoryLine;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    public bool playerOne;

    private void Start()
    {
        cam = Camera.main;
        oneCoin = GameObject.FindGameObjectWithTag("One");
        twoCoin = GameObject.FindGameObjectWithTag("Two");
        playerOne = true;
        turnStart();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 10;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 10;
            trajectoryLine = GetComponent<TrajectoryLine>();
            trajectoryLine.renderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 10;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.x));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            trajectoryLine.endLine();
            StartCoroutine(wait());
            turnStart();
        }
    }

    private void turnStart()
    {
        if (playerOne == true)
        {
            rb = oneCoin.GetComponent<Rigidbody2D>();
            playerOne = false;
        } else if (playerOne == false)
        {
            rb = twoCoin.GetComponent<Rigidbody2D>();
            playerOne = true;
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        UI.SetActive(true);
        yield return new WaitForSeconds(2);
        UI.SetActive(false);
    }
}
