using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    //Use these for adding options to the Dropdown List
    Dropdown.OptionData m_NewData, m_NewData2;
    //The list of messages for the Dropdown
    List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData>();


    //This is the Dropdown
    Dropdown m_Dropdown;
    string m_MyString;
    int m_Index;

    void Start()
    {
        //Fetch the Dropdown GameObject the script is attached to
        m_Dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        m_Dropdown.ClearOptions();

        //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
        m_NewData = new Dropdown.OptionData();
        m_NewData.text = "Option 1";
        m_Messages.Add(m_NewData);

        //Create a new option for the Dropdown menu which reads "Option 2" and add to messages List
        m_NewData2 = new Dropdown.OptionData();
        m_NewData2.text = "Option 2";
        m_Messages.Add(m_NewData2);

        //Take each entry in the message List
        foreach (Dropdown.OptionData message in m_Messages)
        {
            //Add each entry to the Dropdown
            m_Dropdown.options.Add(message);
            //Make the index equal to the total number of entries
            m_Index = m_Messages.Count - 1;
        }
    }

    //This OnGUI function is used here for a quick demonstration. See the UI Section for more information about setting up your own UI.
    void OnGUI()
    {
        //TextField for user to type new entry to add to Dropdown
        m_MyString = GUI.TextField(new Rect(0, 40, 100, 40), m_MyString);

        //Press the "Add" Button to add a new entry to the Dropdown
        if (GUI.Button(new Rect(0, 0, 100, 40), "Add"))
        {
            //Make the index the last number of entries
            m_Index = m_Messages.Count;
            //Create a temporary option
            Dropdown.OptionData temp = new Dropdown.OptionData();
            //Make the option the data from the TextField
            temp.text = m_MyString;

            //Update the messages list with the TextField data
            m_Messages.Add(temp);

            //Add the Textfield data to the Dropdown
            m_Dropdown.options.Insert(m_Index, temp);
        }

        //Press the "Remove" button to delete the selected option
        if (GUI.Button(new Rect(110, 0, 100, 40), "Remove"))
        {
            //Remove the current selected item from the Dropdown from the messages List
            m_Messages.RemoveAt(m_Dropdown.value);
            //Remove the current selection from the Dropdown
            m_Dropdown.options.RemoveAt(m_Dropdown.value);
        }
    }
}
