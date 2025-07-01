using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float coin;
    private int basicLevel = 1;
    private int maxLevel = 20;
    public int currentLevel;
    private float basicExperience = 0f;
    public float experience;
    public float remainingExperience;
    private int basicAp = 100;
    public int maxAp;
    public int currentAp;
    public float endurance;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddCoin()
    {
        coin = coin + 1;
    }

    public void AddExperience()
    {
        experience = experience + 1;

        if (currentLevel == 1 && experience >= 100f)
        {
            remainingExperience = experience - 100f;
            AddLevel();
        }
        else if (currentLevel == 2 && experience >= 200f)
        {
            remainingExperience = experience - 200f;
            AddLevel();
        }
        else if (currentLevel == 3 && experience >= 300f)
        {
            remainingExperience = experience - 300f;
            AddLevel();
        }
        else if (currentLevel == 4 && experience >= 400f)
        {
            remainingExperience = experience - 400f;
            AddLevel();
        }
        else if (currentLevel == 5 && experience >= 500f)
        {
            remainingExperience = experience - 500f;
            AddLevel();
        }
        else if (currentLevel == 6 && experience >= 600f)
        {
            remainingExperience = experience - 600f;
            AddLevel();
        }
        else if (currentLevel == 7 && experience >= 700f)
        {
            remainingExperience = experience - 700f;
            AddLevel();
        }
        else if (currentLevel == 8 && experience >= 800f)
        {
            remainingExperience = experience - 800f;
            AddLevel();
        }
        else if (currentLevel == 9 && experience >= 900f)
        {
            remainingExperience = experience - 900f;
            AddLevel();
        }
        else if (currentLevel == 10 && experience >= 1000f)
        {
            remainingExperience = experience - 1000f;
            AddLevel();
        }
        else if (currentLevel == 11 && experience >= 1100f)
        {
            remainingExperience = experience - 1100f;
            AddLevel();
        }
        else if (currentLevel == 12 && experience >= 1200f)
        {
            remainingExperience = experience - 1200f;
            AddLevel();
        }
        else if (currentLevel == 13 && experience >= 1300f)
        {
            remainingExperience = experience - 1300f;
            AddLevel();
        }
        else if (currentLevel == 14 && experience >= 1400f)
        {
            remainingExperience = experience - 1400f;
            AddLevel();
        }
        else if (currentLevel == 15 && experience >= 1500f)
        {
            remainingExperience = experience - 1500f;
            AddLevel();
        }
        else if (currentLevel == 16 && experience >= 1600f)
        {
            remainingExperience = experience - 600f;
            AddLevel();
        }
        else if (currentLevel == 17 && experience >= 1700f)
        {
            remainingExperience = experience - 1700f;
            AddLevel();
        }
        else if (currentLevel == 18 && experience >= 1800f)
        {
            remainingExperience = experience - 1800f;
            AddLevel();
        }
        else if (currentLevel == 19 && experience >= 1900f)
        {
            remainingExperience = experience - 1900f;
            AddLevel();
        }
    }

    public void AddLevel()
    {
        currentLevel += 1;
        experience = remainingExperience;
        remainingExperience = 0f;
        AddAp();
    }

    public void AddAp()
    {
        maxAp = basicAp + (currentLevel - 1) * 10;
        currentAp += 10;
    }

    public void ReduceEndurance()
    {
        StartCoroutine(DecreaceEndurance());
    }
    
    IEnumerator DecreaceEndurance()
    {
        while (endurance > 0)
        {
            yield return new WaitForSeconds(1f);
            endurance -= 1;
        }
    }
}
