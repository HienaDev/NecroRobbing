using UnityEngine;

[CreateAssetMenu(fileName = "BoneBase", menuName = "Scriptable Objects/BoneBase")]
[System.Serializable]
public class BoneBase : ScriptableObject
{
    [SerializeField] private BoneType boneType;
    public BoneType BoneType => boneType;
    [SerializeField] private float boneSize;
    public float BoneSize => boneSize;
    [SerializeField] private float powerLevel;
    public float PowerLevel => powerLevel;
    [SerializeField] private Sprite boneSprite;
    public Sprite BoneSprite => boneSprite;
}
