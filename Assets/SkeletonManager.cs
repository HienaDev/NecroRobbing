using UnityEngine;

public class SkeletonManager : MonoBehaviour
{

    [SerializeField] private Sprite[] headSprites;
    [SerializeField] private Sprite[] torsoSprites;
    [SerializeField] private Sprite[] legSprites;
    [SerializeField] private Sprite[] armSprites;

    [SerializeField] private SpriteRenderer head;
    [SerializeField] private SpriteRenderer torso;
    [SerializeField] private SpriteRenderer legRight;
    [SerializeField] private SpriteRenderer legLeft;
    [SerializeField] private SpriteRenderer armRight;
    [SerializeField] private SpriteRenderer armLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        head.sprite = headSprites[Random.Range(0, headSprites.Length)];
        torso.sprite = torsoSprites[Random.Range(0, torsoSprites.Length)];
        legRight.sprite = legSprites[Random.Range(0, legSprites.Length)];
        legLeft.sprite = legSprites[Random.Range(0, legSprites.Length)];
        armRight.sprite = armSprites[Random.Range(0, armSprites.Length)];
        armLeft.sprite = armSprites[Random.Range(0, armSprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
