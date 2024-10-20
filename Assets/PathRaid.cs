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

    [SerializeField] private GameObject graveRobbing;
    [SerializeField] private GameObject raid;

    [SerializeField]
    private GameObject[] graves;

    private bool stopped = false;
    private bool lastStop = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length - 1 && !stopped)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                if (Points[pointsIndex].transform.position == firstEncounter.position)
                {
                    stopped = true;
                    GetComponent<AudioSource>().Play();
                    StartCoroutine(Stop());
                }
                if (Points[pointsIndex].transform.position == secondEncounter.position)
                {
                    stopped = true;
                    GetComponent<AudioSource>().Play();

                    StartCoroutine(Stop());
                }

                if (Points[pointsIndex].transform.position == thirdEncounter.position)
                {
                    stopped = true;
                    GetComponent<AudioSource>().Play();
                
                StartCoroutine(Stop());}

                if (Points[pointsIndex].transform.position == endEncounter.position)
                {
                    stopped = true;
                    GetComponent<AudioSource>().Play();
                    lastStop = true;
                    StartCoroutine(Stop());

                }
                pointsIndex += 1;
            }



        }
    }

    private IEnumerator Stop()
    {
        yield return new WaitForSeconds(3f);
        stopped = false;

        if(lastStop)
        {

            foreach (GameObject go in graves)
            {
                go.GetComponent<GraveManager>().ResetGrave();
                raid.SetActive(false);
                graveRobbing.SetActive(true);
            }
        }
    }

}
