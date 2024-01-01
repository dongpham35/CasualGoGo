using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveScore : MonoBehaviour
{
    [SerializeField] private InputField txtName;
    public static Dictionary<string, int> Dscore = new Dictionary<string, int>();
    public static int Score = 0;
    private string namePlayer = "";

    public void Save()
    {
        namePlayer = txtName.text;
        if (!string.IsNullOrEmpty(namePlayer))
        {
            if (Dscore.ContainsKey(namePlayer))
            {
                if (Dscore[namePlayer] < Score) {
                    Dscore[namePlayer] = Score;
                }
            }
            else
            {
                Dscore.Add(namePlayer, Score);
            }
            Dscore = SortValue(Dscore);
        }
        Score = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public static void WriteFile(string stringPath)
    {
        int i = 0;
        StreamWriter sw = null;
        using(sw = File.CreateText(stringPath))
        {
            foreach (var item in  Dscore)
            {
                if (i < 5)
                {
                    string s = string.Format(item.Key + ";" + item.Value);
                    sw.WriteLine(s);
                }
                else break;
            }
        }
        sw.Close();
    }

    public static void LoadFileScore(string stringpath)
    {
        
        if(Dscore.Count == 0)
        {
            StreamReader sr = null;
            try
            {
                string s;
                sr = File.OpenText(stringpath);
                if (Dscore.Count != 0) Dscore.Clear();
                while ((s = sr.ReadLine()) != null)
                {
                    //dữ liệu lưu định dạng: name;score
                    string[] data = s.Split(";");
                    int score = Convert.ToInt32(data[1]);
                    Dscore.Add(data[0], score);
                }
            }
            catch (IndexOutOfRangeException IR)
            {
                Debug.Log(IR.Message);
            }
            catch (FileLoadException ex)
            {
                Debug.LogException(ex);
            }
            finally
            {
                sr.Close();
            }
        }
    }

    public static void CountScore()
    {
        int level = SceneManager.sceneCount - 2;
        int point_time = 1;
        if (Timer.runtime <= (60 + level * 10))
        {
            point_time = 80;
        }
        else if(Timer.runtime <= (60 + 10 * level + 30 ))
        {
            point_time = 80 + (60 + level * 10 - (int)Timer.runtime) / 2;
        }
        else
        {
            point_time = 40;
        }
        Score = Score + (PlayerPrefs.GetInt("CurrentHealth") + 1) / 3 * point_time * ItemCollection.score / CountFruit.count;
    }

    private static Dictionary<string, int> SortValue(Dictionary<string, int> d)
    {
        Dictionary<string, int> sorted = d.OrderByDescending(v => v.Value).ToDictionary(x => x.Key, x => x.Value);
        return sorted;
    }


}
