using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ChooseProgram : MonoBehaviour
{
    public static ChooseProgram instance;
    [SerializeField] Text textElementProgramName;
    [SerializeField] Text textElementProgramQuestion;
    public string answer;
    public string difficulty;
    public int time;
    string path = "Assets/Files/qa_mainframe_2.csv";
    List<List<string>> listContent = new List<List<string>>();

    // Start is called before the first frame update
    void Start()
    {
        //readTextFile();
        instance = this;
        ReadCSVFile();
    }

    void ReadCSVFile(){
        StreamReader strReader = new StreamReader(path);
        bool endOfLine = false;
        while(!endOfLine){
            string data_String = strReader.ReadLine();
            if(data_String == null){
                endOfLine = true;
                break;
            }
            var data_values = data_String.Split(',');
            listContent.Add(new List<string> {data_values[0],data_values[1],data_values[2],data_values[3]});
        }
        //[0]: Question, [1]: Answer, [2]: file, [3]: Difficulty
        print(listContent[1][1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
