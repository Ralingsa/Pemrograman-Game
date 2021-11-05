using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class tesAnalytics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Use this call to designate the user gender
        Gender gender = Gender.Female;
        Analytics.SetUserGender(gender);
        // Use this call to designate the user birth year
        int birthYear = 1998;
        Analytics.SetUserBirthYear(birthYear);
        //Monetization
        Analytics.Transaction("5Diamons", 0.99m, "USD", null, null);
        //Custom Event Scripting
        int totalDeads = 5;
        int totalScores = 100;
        int totalTimes = 120;
        string Level = "Level5";
        Analytics.CustomEvent("Gameplay", new Dictionary<string, object>{
        { "Deads", totalDeads },
        { "Scores", totalScores },
        { "Times", totalTimes },
        { "Level", Level }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
