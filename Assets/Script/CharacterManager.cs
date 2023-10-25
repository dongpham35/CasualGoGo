using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterManager : MonoBehaviour
{
    public CharacterData characterDB;
    public Text txtNameCharacter;
    public SpriteRenderer spriteCharacter;
    private static int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selected1")){
            index = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(index);
    }



    public void NextOption()
    {
        index++;
        if(index >= characterDB.characterCount)
        {
            index = 0;
        }
        Save();
        UpdateCharacter(index);
    }

    public void BackOption()
    {
        index--;
        if(index < 0)
        {
            index = characterDB.characterCount - 1;
        }
        Save();
        UpdateCharacter(index);
    }

    private void UpdateCharacter(int selected)
    {
        Character character = characterDB.GetCharacter(index);
        txtNameCharacter.text = character.nameCharacter;
        spriteCharacter.sprite = character.spriteCharacter;
    }

    private void Load()
    {
        index = PlayerPrefs.GetInt("selected1");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selected1", index);
    }
}
