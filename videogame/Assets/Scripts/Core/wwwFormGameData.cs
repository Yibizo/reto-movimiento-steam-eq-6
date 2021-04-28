using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

    /*    Debug.Log(playerUnit.Program.Level);

        //return last area
        Debug.Log(currentAreaIdx);

        //return problems solved per area
        Debug.Log(playerUnit.Program.ProblemsArea1);
        Debug.Log(playerUnit.Program.ProblemsArea2);
        Debug.Log(playerUnit.Program.ProblemsArea3);*/

        
public class wwwFormGameData : MonoBehaviour 
{
    // The route for the api that inserts data.
    [SerializeField] string apiURLPost = "http://localhost:5000/api/initial";
    [SerializeField] string apiURLPut = "http://localhost:5000/api/update";
    string id = null;
    // References for the scripts that hold the information that is going to be inserted.

    /*private void Start() 
    {
        Program = GetComponent<Program>();
    }*/

    // We need to start a coroutine that calls the request
    public IEnumerator UploadData(int Level, int Area, int ProblemsA1, int ProblemsA2, int ProblemsA3)
    {
        // Unity sends a form, just as a html form. 
        WWWForm form = new WWWForm();

        // We need to create the form first, by manually adding fields. These fields match the names of the columns in the database.
        // The values from the other scripts is checked here and added to the form.
        form.AddField("level", Level.ToString());
        form.AddField("area_id", Area.ToString());
        form.AddField("problems_a1", ProblemsA1.ToString());
        form.AddField("problems_a2", ProblemsA2.ToString());
        form.AddField("problems_a3", ProblemsA3.ToString());

        Debug.Log(form);

        // We create a request that makes a post to the url, and sends the form we just created.
        using (UnityWebRequest request = UnityWebRequest.Post(apiURLPost, form))
        {
            // The yield return line is the point at which execution will pause, and be resumed after the request ends.
            yield return request.SendWebRequest();

            // If there are no errors...
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                // We get the response text and log it in the console.
                id = request.downloadHandler.text;
                Debug.Log("Form upload complete!");
            }
        }

        
    }

    public IEnumerator UpdateData(int Level, int Area, int ProblemsA1, int ProblemsA2, int ProblemsA3)
    {
        // Unity sends a form, just as a html form. 
        /*WWWForm form = new WWWForm();

        // We need to create the form first, by manually adding fields. These fields match the names of the columns in the database.
        // The values from the other scripts is checked here and added to the form.
        form.AddField("Level", Level.ToString());
        form.AddField("AreaID", Area.ToString());
        form.AddField("ProblemsA1", ProblemsA1.ToString());
        form.AddField("ProblemsA2", ProblemsA2.ToString());
        form.AddField("ProblemsA3", ProblemsA3.ToString());

        Debug.Log(form);*/

        //byte[] myData = System.Text.Encoding.UTF8.GetBytes ("?user_id=" + id + "&level=" + Level.ToString() + "&area_id=" + Area.ToString() + "&problems_a1=" + ProblemsA1.ToString() + "&problems_a2=" + ProblemsA2.ToString() + "&problems_a3=" + ProblemsA3.ToString());


        string key = "{";
        string key2 = "}";
        //Console.WriteLine(Encoding.Default.GetString(myData));

        // We create a request that makes a post to the url, and sends the form we just created.
        using (UnityWebRequest request = UnityWebRequest.Put(apiURLPut, $"{key}\"user_id\":\"{id}\",\"level\":\"{Level}\",\"problems_a1\":\"{ProblemsA1}\",\"problems_a2\":\"{ProblemsA2}\",\"problems_a3\":\"{ProblemsA3}\",\"area_id\":\"{Area}\"{key2}"))
        {
            request.SetRequestHeader ("Content-Type", "application/json");
            
            // The yield return line is the point at which execution will pause, and be resumed after the request ends.
            yield return request.SendWebRequest();

            // If there are no errors...
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                // We get the response text and log it in the console.
                Debug.Log(request.downloadHandler.text);
                Debug.Log("Form upload complete!");
            }
        }
    }

}