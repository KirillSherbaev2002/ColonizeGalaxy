using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Radar : MonoBehaviour
{
    [Header("RadarProperties")]
    public Image[] RadarParts = new Image[15];
    public GameObject[] Enemies;
    public GameObject[] EnemiesBuilding;

    public TMP_Text DistanceToTheEnemy;
    public GameObject SpaceShip;

    [SerializeField] private Color ActiveColor;
    [SerializeField] private Color DeactiveColor;

    public TMP_Text NumberOfEnemyShips;
    public TMP_Text NumberOfEnemyBuildings;

    [SerializeField] private float[] AngleBetweenGoals;

    private void Awake()
    {
        SearchForTheEnemies();
    }

    private void FixedUpdate()
    {
        GettingTheDifference();
        SetRadar();
    }

    private void SearchForTheEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesBuilding = GameObject.FindGameObjectsWithTag("EnemyBuilding");
        NumberOfEnemyShips.text = Enemies.Length.ToString();
        NumberOfEnemyBuildings.text = EnemiesBuilding.Length.ToString();
    }

    private void GettingTheDifference()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            try
            {
                AngleBetweenGoals[i] = Vector3.SignedAngle(-SpaceShip.transform.up, Enemies[i].transform.position - SpaceShip.transform.position, -Vector3.up);
            }
            catch
            {
                SearchForTheEnemies();
            }
        }

        for (int i = 0; i < EnemiesBuilding.Length; i++)
        {
            try
            {
                AngleBetweenGoals[i] += Vector3.SignedAngle(-SpaceShip.transform.up, EnemiesBuilding[i].transform.position - SpaceShip.transform.position, -Vector3.up);
            }
            catch
            {
                SearchForTheEnemies();
            }
        }
    }

    private void SetRadar()
    {
        //Deactivation before
        foreach(Image img in RadarParts)
        {
            img.color = DeactiveColor;
        }
        for (int i = 0; i < AngleBetweenGoals.Length; i++)
        {
            if (Enemies.Length == 0)
            {
                break;
            }

            //Enemies.Length >= i - needed to not stop the search in case there is no enemies to search for
            //Enemies[i].activeSelf == true - needed to not save the position of the enemy which already was destroyed

            try
            {
                if (Enemies.Length >= i && Enemies[i].activeSelf == true)
                {
                    if (AngleBetweenGoals[i] < 15 && AngleBetweenGoals[i] > -15)
                    {
                        if (AngleBetweenGoals[i] < 5 && AngleBetweenGoals[i] > -5)
                        {
                            RadarParts[7].color = ActiveColor;
                        }

                        if (AngleBetweenGoals[i] < 15 && AngleBetweenGoals[i] > 5)
                        {
                            RadarParts[6].color = ActiveColor;
                        }
                        if (AngleBetweenGoals[i] < -5 && AngleBetweenGoals[i] > -15)
                        {
                            RadarParts[8].color = ActiveColor;
                        }
                        DistanceToTheEnemy.text = Vector3.Distance(Enemies[i].transform.position, SpaceShip.transform.position).ToString("N0") + "Km";
                    }
                    else
                    {
                        DistanceToTheEnemy.text = "Unknown km";
                    }

                    if (AngleBetweenGoals[i] < 25 && AngleBetweenGoals[i] > 15)
                    {
                        RadarParts[5].color = ActiveColor;
                    }
                    if (AngleBetweenGoals[i] < -15 && AngleBetweenGoals[i] > -25)
                    {
                        RadarParts[9].color = ActiveColor;
                    }

                    if (AngleBetweenGoals[i] < 35 && AngleBetweenGoals[i] > 25)
                    {
                        RadarParts[4].color = ActiveColor;
                    }
                    if (AngleBetweenGoals[i] < -25 && AngleBetweenGoals[i] > -35)
                    {
                        RadarParts[10].color = ActiveColor;
                    }

                    if (AngleBetweenGoals[i] < 45 && AngleBetweenGoals[i] > 35)
                    {
                        RadarParts[3].color = ActiveColor;
                    }
                    if (AngleBetweenGoals[i] < -35 && AngleBetweenGoals[i] > -45)
                    {
                        RadarParts[11].color = ActiveColor;
                    }

                    if (AngleBetweenGoals[i] < 55 && AngleBetweenGoals[i] > 45)
                    {
                        RadarParts[2].color = ActiveColor;
                    }
                    if (AngleBetweenGoals[i] < -45 && AngleBetweenGoals[i] > -55)
                    {
                        RadarParts[12].color = ActiveColor;
                    }

                    if (AngleBetweenGoals[i] < 65 && AngleBetweenGoals[i] > 55)
                    {
                        RadarParts[1].color = ActiveColor;
                    }
                    if (AngleBetweenGoals[i] < -55 && AngleBetweenGoals[i] > -65)
                    {
                        RadarParts[13].color = ActiveColor;
                    }

                    if (AngleBetweenGoals[i] < 75 && AngleBetweenGoals[i] > 65)
                    {
                        RadarParts[0].color = ActiveColor;
                    }
                    if (AngleBetweenGoals[i] < -65 && AngleBetweenGoals[i] > -75)
                    {
                        RadarParts[14].color = ActiveColor;
                    }
                }
            }
            catch
            {
                print("No objects found");
            }
        }
    }
}
