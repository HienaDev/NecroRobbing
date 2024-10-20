using System.Collections;
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


    [SerializeField]
    private GameObject[] graves;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
        StartCoroutine(Path());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Path()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                if (Points[pointsIndex].transform.position == firstEncounter.position)
                {
                    yield return new WaitForSeconds(3f);
                }
                if (Points[pointsIndex].transform.position == secondEncounter.position)
                {
                    yield return new WaitForSeconds(3f);
                }
                if (Points[pointsIndex].transform.position == thirdEncounter.position)
                {
                    yield return new WaitForSeconds(3f);
                }
                if (Points[pointsIndex].transform.position == endEncounter.position)
                {
                    yield return new WaitForSeconds(3f);

                    foreach(GameObject go in graves)
                    {
                        go.GetComponent<GraveManager>().ResetGrave();
                    }
                }
                pointsIndex += 1;
            }

            yield return null;

        }
    }

}
