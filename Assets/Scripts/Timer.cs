using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text TimePassed;
    private Radar radar;

    private float SecondPassedfloat;

    [SerializeField] private float AddTime;

    public TMP_Text MissionComplitedIn;
    [SerializeField] private float scoreFor5Stars;

    public Image FillStars;

    private void Awake()
    {
        radar = FindObjectOfType<Radar>();
    }
    void FixedUpdate()
    {
        SecondPassedfloat += AddTime * Time.deltaTime;
        TimePassed.text = SecondPassedfloat.ToString("N0") + " sec";
    }
    public void MissionPassed()
    {
        if(PlayerPrefs.GetFloat("recordTime") > SecondPassedfloat || PlayerPrefs.GetFloat("recordTime") == 0)
        {
            PlayerPrefs.SetFloat("recordTime", SecondPassedfloat);
        }

        print("saved" + PlayerPrefs.GetFloat("recordTime").ToString());

        print("savedworked" + SecondPassedfloat);


        MissionComplitedIn.text = "Mission complited in " + SecondPassedfloat.ToString("N0") + " sec";

        FillStars.fillAmount = scoreFor5Stars / SecondPassedfloat;
    }
}
