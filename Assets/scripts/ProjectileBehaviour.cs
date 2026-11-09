using TMPro;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4.5f;
    private PointManager pointManager;

    void Start() 
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();

    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Inimigo")
        {
            other.gameObject.SetActive(false);
            pointManager.UpdateScore(10);
            Destroy(gameObject);
        }

    }
}
