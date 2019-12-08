using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class WeatherRetrieve : MonoBehaviour {
 
    private Dictionary<string, string> myWeatherLabel = new Dictionary<string, string>();
    public GameObject myPrefab;
    
    //retrieved from weather API
    public string retrievedCountry;
    public string retrievedCity;
    public int conditionID;
    public string conditionName;
    public float Temperature;
    
    void Start()
    {
        StartCoroutine(SendRequest());
    }
    

    IEnumerator SendRequest()
    {

        WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=" + "Lille" +
                              "&appid=18241453d7573951f239c1057a75f227"); //get our weather
        yield return request;

        if (request.error == null || request.error == "")
        {
            var N = JSON.Parse(request.text);

            retrievedCountry = N["sys"]["country"].Value; //get the country
            retrievedCity = N["name"].Value; //get the city

            string temp = N["main"]["temp"].Value; //get the temperature
            
            float tempTemp; //variable to hold the parsed temperature
            //tempTemp = float.Parse(temp);
             //parse the temperature
            temp = temp.Replace(".", ",");
            float.TryParse(temp, out tempTemp);
            Temperature = Mathf.Round((tempTemp - 273.0f) * 10) / 10; //holds the actual converted temperature

            
            int.TryParse(N["weather"][0]["id"].Value, out conditionID); //get the current condition ID
            conditionName = N["weather"][0]["main"].Value; //get the current condition Name
            //conditionName = N["weather"][0]["description"].Value; //get the current condition Description

            //put all the retrieved stuff in the label
            myWeatherLabel.Add("Country", retrievedCountry);
            myWeatherLabel.Add("City", retrievedCity);
            myWeatherLabel.Add("Current Condition", conditionName);
            myWeatherLabel.Add("Condition Code", conditionID.ToString());
        }
        else
        {
            Debug.Log("WWW error: " + request.error);
        }
        
        GameObject prefab;
        if (myWeatherLabel["Current Condition"] == "Rain")
        {
            prefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity); 
            //prefab.
        }
        else if (Temperature <= 5)
        {
            prefab = GameObject.Find("ARCamera");
            prefab.GetComponent<FrostEffect>().enabled = true;
        }
    }
}
 