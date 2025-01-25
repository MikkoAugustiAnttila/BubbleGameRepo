
using UnityEngine;

public class FlyController : MonoBehaviour
{
    private Vector3 startPosition;
    
    [SerializeField] private float speed = 1f;
    [SerializeField] private float width = 5f;
    [SerializeField] private float height = 2f;
    
    private float elapsedTime = 0f;

    public bool randomizeMovement = true;
    public bool canMove = true;
    private void Start()
    {
        startPosition = transform.position;
        
        //Randomizing the start variables
        if (randomizeMovement)
        {
            speed = Random.Range(0.5f, 1.5f) * Mathf.Sign(Random.Range(-1f, 1f));
            
            width = Random.Range(1f, 4f) * Mathf.Sign(Random.Range(-1f, 1f));
            
            height = Random.Range(1f, 3f) * Mathf.Sign(Random.Range(-1f, 1f));
            
            elapsedTime = Random.Range(0, 100f);
        }
    }

    private void Update()
    {
        if (canMove)
        {
            elapsedTime += Time.deltaTime * speed;
        
            float x = Mathf.Sin(elapsedTime) * width;
            float y = Mathf.Sin(2 * elapsedTime) * height;
        
            transform.position = startPosition + new Vector3(x, y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            soundManager.instance.PlaySound("Bite");
        }
    }
}
