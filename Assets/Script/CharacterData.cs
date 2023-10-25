using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="characterDB", menuName ="characterDB")]
public class CharacterData : ScriptableObject
{
    public Character[] characterDatabase;
    public int characterCount
    {
        get { return characterDatabase.Length; }
    }
    public Character GetCharacter(int index)
    {
        return characterDatabase[index];
    }
}
