using UnityEngine;

public class Ability : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] float fallSpeed = 10f;
    [HideInInspector] public bool planeAbility=false;
    private string problemTag;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameManager.environmentSpeed;
        if (transform.CompareTag("Water"))
            problemTag = "FireSolved";
        else if (transform.CompareTag("Ladder"))
            problemTag = "HumanSolved";
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward* moveSpeed *Time.deltaTime);
        if(planeAbility)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        if(transform.position.z < -70f) Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(problemTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
