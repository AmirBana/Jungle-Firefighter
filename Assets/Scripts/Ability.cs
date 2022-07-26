using UnityEngine;

public class Ability : MonoBehaviour
{
    float moveSpeed;
    [SerializeField] float fallSpeed = 10f;
    [HideInInspector] public bool planeAbility=false;
    private string problemTag;
    Color problemColor;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameManager.instance.environmentSpeed;
        if (transform.CompareTag("Water"))
        {
            problemTag = "FireSolved";
            problemColor = Color.green;
        }
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
            if(other.gameObject.GetComponent<MeshRenderer>().material.color == problemColor)
        {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            Destroy(gameObject);
        }
    }
}
