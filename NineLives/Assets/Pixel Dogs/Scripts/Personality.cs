using UnityEngine;
using System.Collections;

[System.Serializable]
public class Personality
{
    public float intellect;
    public float playfulness;
    public float lazyness;
    public float apetite;
    public float sociability;

    public Personality()
    {
        //Randomly Set 22 points to each personality stat.
        for (int i = 0; i < 22; i++)
        {
            switch (i)
            {
                case 1:
                    intellect++;
                    break;
                case 2:
                    playfulness++;
                    break;
                case 3:
                    lazyness++;
                    break;
                case 4:
                    apetite++;
                    break;
                case 5:
                    sociability++;
                    break;
            }
        }
    }
}
