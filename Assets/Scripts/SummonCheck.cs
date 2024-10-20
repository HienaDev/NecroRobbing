using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SummonCheck : MonoBehaviour
{
    [SerializeField] private Button summonButton;

    [SerializeField] private GameObject headSprite;
    private BoneBase headBone;
    [SerializeField] private GameObject torsoSprite;
    private BoneBase torsoBone;
    [SerializeField] private GameObject leftArmSprite;
    private BoneBase leftArmBone;
    [SerializeField] private GameObject rightArmSprite;
    private BoneBase rightArmBone;
    public bool leftArm = false;
    [SerializeField] private GameObject leftLegSprite;
    private BoneBase leftLegBone;
    [SerializeField] private GameObject rightLegSprite;
    private BoneBase rightLegBone;
    public bool leftLeg = false;

    [SerializeField] private SkeletonManager skeletonManager;
    private SoundsScript soundScript;

    [SerializeField]
    private GameObject summonButtonOn;
    [SerializeField]
    private GameObject summonButtonOff;

    void Start()
    {
        soundScript = GetComponent<SoundsScript>();
    }
    private bool CheckIfReady()
    {
        summonButtonOn.SetActive(true);
        summonButtonOff.SetActive(false);
        return (headBone != null && torsoBone != null && leftArmBone != null && rightArmBone != null && leftLegBone != null && rightLegBone != null);
    }

    public void SetHead(BoneBase head)
    {
        headBone = head;
        headSprite.GetComponent<Image>().sprite = headBone.BoneSprite;
        headSprite.GetComponent<Image>().color = Color.white;

        if(CheckIfReady())
        {
            summonButton.interactable = true;
        }
    }

    public BoneBase GetHead() => headBone;

    public void SetTorso(BoneBase torso)
    {
        torsoBone = torso;
        torsoSprite.GetComponent<Image>().sprite = torsoBone.BoneSprite;
        torsoSprite.GetComponent<Image>().color = Color.white;

        if (CheckIfReady())
        {
            summonButton.interactable = true;
        }
    }

    public BoneBase GetTorso() => torsoBone;

    public void SetLeftArm(BoneBase leftArm)
    {
        leftArmBone = leftArm;
        leftArmSprite.GetComponent<Image>().sprite = leftArmBone.BoneSprite;
        leftArmSprite.GetComponent<Image>().color = Color.white;

        if (CheckIfReady())
        {
            soundScript.PlayAudio();
            summonButton.interactable = true;
        }
    }

    public BoneBase GetLeftArm() => leftArmBone;

    public void SetRightArm(BoneBase rightArm)
    {
        rightArmBone = rightArm;
        rightArmSprite.GetComponent<Image>().sprite = rightArmBone.BoneSprite;
        rightArmSprite.GetComponent<Image>().color = Color.white;

        if (CheckIfReady())
        {
            summonButton.interactable = true;
        }
    }

    public BoneBase GetRightArm() => rightArmBone;

    public void SetLeftLeg(BoneBase leftLeg)
    {
        leftLegBone = leftLeg;
        leftLegSprite.GetComponent<Image>().sprite = leftLegBone.BoneSprite;
        leftLegSprite.GetComponent<Image>().color = Color.white;

        if (CheckIfReady())
        {
            summonButton.interactable = true;
        }
    }

    public BoneBase GetLeftLeg() => leftLegBone;

    public void SetRightLeg(BoneBase rightLeg)
    {
        rightLegBone = rightLeg;
        rightLegSprite.GetComponent<Image>().sprite = rightLegBone.BoneSprite;
        rightLegSprite.GetComponent<Image>().color = Color.white;

        if (CheckIfReady())
        {
            summonButton.interactable = true;
        }
    }

    public BoneBase GetRightLeg() => headBone;


    public void Summon()
    {
        skeletonManager.SummonSkeleton(headBone, torsoBone, rightLegBone, leftLegBone, rightArmBone, leftArmBone);

        summonButton.interactable = false;
    }
}
