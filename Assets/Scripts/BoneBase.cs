using UnityEngine;

[CreateAssetMenu(fileName = "BoneBase", menuName = "Scriptable Objects/BoneBase")]
public class Bone : ScriptableObject
{
    [SerializeField] private BoneType _boneType;
    public BoneType BoneType => _boneType;
    [SerializeField] private float _boneSize;
    public float BoneSize => _boneSize;
    [SerializeField] private float _powerLevel;
    public float PowerLevel => _powerLevel;
    [SerializeField] private Sprite _boneSprite;
}
