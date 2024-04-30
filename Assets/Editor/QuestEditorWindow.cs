using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class QuestEditorWindow : EditorWindow
{
    private QuestSystem questSystem;
    private int questIndex;
    private int selectedGoalTypeIndex = 0;
    private string goalName = "";
    private string goalDescription = "";
    private int numberOfItems = 0;
    private readonly string[] goalTypeNames = { "Collect Goal", "Talk to NPC Goal" };

    public static void OpenWindow(QuestSystem questSystem, int questIndex)
    {
        QuestEditorWindow window = EditorWindow.GetWindow<QuestEditorWindow>();
        window.titleContent = new GUIContent("Quest Editor");
        window.questSystem = questSystem;
        window.questIndex = questIndex;
        window.Show();
    }

    private void OnGUI()
    {
        if (questSystem == null || questIndex < 0 || questIndex >= questSystem.QuestList.Count)
        {
            EditorGUILayout.LabelField("Invalid quest selection.");
            return;
        }

        Quest quest = questSystem.QuestList[questIndex];

        EditorGUILayout.LabelField("Quest Name");
        quest.questName = EditorGUILayout.TextField(quest.questName);

        EditorGUILayout.LabelField("Description");
        quest.description = EditorGUILayout.TextField(quest.description);

        // Display goals
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Goals");
        for (int i = 0; i < quest.Goals.Count; i++)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.LabelField("Goal " + i + ":");
            quest.Goals[i].goalName = EditorGUILayout.TextField("Goal Name", quest.Goals[i].goalName);
            quest.Goals[i].description = EditorGUILayout.TextField("Description", quest.Goals[i].description);

            if (quest.Goals[i] is Collect_Iteams_Goal)
            {
                Collect_Iteams_Goal collectItemsGoal = (Collect_Iteams_Goal)quest.Goals[i];
                collectItemsGoal.requirdAmount = EditorGUILayout.IntField("Number of Items", collectItemsGoal.requirdAmount);
            }

            // Add more properties for other goal types as needed

            if (GUILayout.Button("Remove Goal"))
            {
                quest.Goals.RemoveAt(i);
                GUIUtility.ExitGUI(); // Exit GUI immediately to prevent errors
            }

            EditorGUILayout.EndVertical();
        }

        selectedGoalTypeIndex = EditorGUILayout.Popup("Select Goal Type", selectedGoalTypeIndex, goalTypeNames);
        goalName = EditorGUILayout.TextField("Enter Goal Name", goalName);
        goalDescription = EditorGUILayout.TextField("Enter Goal Description", goalDescription);

        if (GUILayout.Button("Add Goal"))
        {
            Goal newGoal;
            switch (selectedGoalTypeIndex)
            {
                case 0:
                    Collect_Iteams_Goal collectItemsGoal = ScriptableObject.CreateInstance<Collect_Iteams_Goal>();
                    collectItemsGoal.goalName = goalName;
                    collectItemsGoal.description = goalDescription;
                    collectItemsGoal.requirdAmount = numberOfItems;
                    newGoal = collectItemsGoal;
                    break;
                case 1:
                    TalkToNpcGoal talkToNPCGoal = ScriptableObject.CreateInstance<TalkToNpcGoal>();
                    talkToNPCGoal.goalName = goalName;
                    talkToNPCGoal.description = goalDescription;
                    newGoal = talkToNPCGoal;
                    break;
                default:
                    Debug.LogError("Invalid goal type selection.");
                    return;
            }

            // Create a path for the new asset
            string assetPath = AssetDatabase.GenerateUniqueAssetPath("Assets/NewGoal.asset");

            // Save the new asset
            AssetDatabase.CreateAsset(newGoal, assetPath);
            AssetDatabase.SaveAssets();

            // Assign the new goal to the quest's list
            quest.Goals.Add(newGoal);
        }

        // Save changes when the window is closed
        if (Event.current.type == EventType.Layout)
        {
            EditorUtility.SetDirty(questSystem);
        }
    }
}