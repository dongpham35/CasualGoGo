using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[System.Serializable]
public class Character
{
    public string nameCharacter;
    public Sprite spriteCharacter;
    public AnimationClip[] animationClips;
    public AnimatorController controller;
}
