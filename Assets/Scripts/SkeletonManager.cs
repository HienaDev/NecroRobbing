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

    }

    public void SummonSkeleton(BoneBase head, BoneBase torso, BoneBase legRight, BoneBase legLeft, BoneBase armRight, BoneBase armLeft)
    {
        this.head.sprite = head.BoneSprite;
        this.torso.sprite = torso.BoneSprite;
        this.legRight.sprite = legRight.BoneSprite;
        this.legLeft.sprite = legLeft.BoneSprite;
        this.armRight.sprite = armRight.BoneSprite;
        this.armLeft.sprite = armLeft.BoneSprite;
    }
}
