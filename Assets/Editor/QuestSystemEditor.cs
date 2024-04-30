using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestSystem))]
public class QuestSystemEditor : Editor
{
    private SerializedProperty questListProperty , activeQuest , fungusFlowChart , questPanal;

    private void OnEnable()
    {
        questListProperty = serializedObject.FindProperty("QuestList");
        activeQuest = serializedObject.FindProperty("activeQuest");
        fungusFlowChart = serializedObject.FindProperty("fungusFlowChars");
        questPanal = serializedObject.FindProperty("questPanal");
    }

    public override void OnInspectorGUI()
    {
        // Update the serialized object
        serializedObject.Update();

        // Display the default inspector property for the QuestList
        EditorGUILayout.PropertyField(questListProperty, true);
        EditorGUILayout.PropertyField(activeQuest, true);
        EditorGUILayout.PropertyField(fungusFlowChart, true);
        EditorGUILayout.PropertyField(questPanal, true);


        // Add a button for adding a new quest
        EditorGUILayout.Space();
        if (GUILayout.Button("Add Quest"))
        {
            AddQuest();
        }

        // Display buttons for editing and removing quests
        DisplayQuestButtons();

        // Apply changes to the serialized object
        serializedObject.ApplyModifiedProperties();
    }

    private void AddQuest()
    {
        // Add a new quest to the QuestList
        QuestSystem questSystem = (QuestSystem)target;
        questSystem.QuestList.Add(new Quest());
    }

    private void DisplayQuestButtons()
    {
        QuestSystem questSystem = (QuestSystem)target;

        // Display buttons for each quest in the QuestList
        for (int i = 0; i < questSystem.QuestList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            // Display a button to edit the quest
            if (GUILayout.Button("Edit Quest " + i))
            {
                // Open a custom editor window for editing the quest
                QuestEditorWindow.OpenWindow(questSystem, i);
            }

            if (GUILayout.Button("Remove Quest " + i))
            {
                questSystem.QuestList.RemoveAt(i);
                GUIUtility.ExitGUI();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}