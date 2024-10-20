using UnityEngine;

public class PathRaid : MonoBehaviour
{

    [SerializeField] private Transform[] Points;
    [SerializeField] private Transform firstEncounter;
    [SerializeField] private Transform secondEncounter;
    [SerializeField] private Transform thirdEncounter;
    [SerializeField] private Transform endEncounter;

    [SerializeField] private float moveSpeed;

    private int pointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }
        }
    }

}
