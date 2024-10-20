using UnityEngine;
using UnityEngine.UI;

public class SummonCheck : MonoBehaviour
{
    [SerializeField] private Button summonButton;
    [SerializeField]
    private Drop[] summonSpaces;
    private int numReady;

    [SerializeField] private GameObject headSprite;
    private BoneBase headBone;
    [SerializeField] private GameObject torsoSprite;
    private BoneBase torsoBone;
    [SerializeField] private GameObject leftArmSprite;
    private BoneBase leftArmBone;
    [SerializeField] private GameObject rightArmSprite;
    private BoneBase rightArmBone;
    [SerializeField] private GameObject leftLegSprite;
    private BoneBase leftLegBone;
    [SerializeField] private GameObject rightLegSprite;
    private BoneBase rightLegBone;

        
    public void SetHead(BoneBase head)
    {
        headBone = head;
        headSprite.GetComponent<Image>().sprite = headBone.BoneSprite;
        headSprite.GetComponent<Image>().color = Color.white;
    }

    public void SetTorso(BoneBase torso)
    {
        torsoBone = torso;
        torsoSprite.GetComponent<Image>().sprite = torsoBone.BoneSprite;
        torsoSprite.GetComponent<Image>().color = Color.white;
    }

    public void SetLeftArm(BoneBase leftArm)
    {
        leftArmBone = leftArm;
        leftArmSprite.GetComponent<Image>().sprite = leftArmBone.BoneSprite;
        leftArmSprite.GetComponent<Image>().color = Color.white;
    }

    public void SetRightArm(BoneBase rightArm)
    {
        rightArmBone = rightArm;
        rightArmSprite.GetComponent<Image>().sprite = rightArmBone.BoneSprite;
        rightArmSprite.GetComponent<Image>().color = Color.white;
    }

    public void SetLeftLeg(BoneBase leftLeg)
    {
        leftLegBone = leftLeg;
        leftLegSprite.GetComponent<Image>().sprite = leftLegBone.BoneSprite;
        leftLegSprite.GetComponent<Image>().color = Color.white;
    }

    public void SetRightLeg(BoneBase rightLeg)
    {
        rightLegBone = rightLeg;
        rightLegSprite.GetComponent<Image>().sprite = rightLegBone.BoneSprite;
        rightLegSprite.GetComponent<Image>().color = Color.white;
    }

    void Start()
    {
        summonSpaces = FindObjectsByType<Drop>(0);
    }

    void Update()
    {
        foreach (Drop space in summonSpaces)
        {
            if (space.IsPlaced)
                numReady++;
        }
        Debug.Log(numReady);
        if (numReady == 6)
            summonButton.interactable = true;
        else
            numReady = 0;
    }
    public void Summon()
    {
        Debug.Log("SUMMON CODE HERE");
        summonButton.interactable = false;
    }
}
