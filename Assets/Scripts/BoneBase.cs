using UnityEngine;

[CreateAssetMenu(fileName = "BoneBase", menuName = "Scriptable Objects/BoneBase")]
public class Bone : ScriptableObject
{
    private BoneType _boneType;
    private float _boneSize;
    private float _powerLevel;
}
