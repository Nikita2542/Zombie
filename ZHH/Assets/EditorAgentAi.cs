/*using UnityEditor;

[CustomEditor(typeof(AiAgent))]

public class EditorAgentAi : Editor
{
    /*#region SepializedPropertesZombie
    SerializedProperty playerHealth;
    SerializedProperty speedometr;
    SerializedProperty initialState;
    SerializedProperty config;
    SerializedProperty hips;
    SerializedProperty armature;
    SerializedProperty mainObject;
    SerializedProperty damagePeriod;
    bool scripts = true;
    bool objects = true;
    bool period = true;
    #endregion

    private void OnEnable()
    {
        playerHealth = serializedObject.FindProperty("playerHealth");
        speedometr = serializedObject.FindProperty("speedometr");
        initialState = serializedObject.FindProperty("initialState");
        config = serializedObject.FindProperty("config");
        hips = serializedObject.FindProperty("hips");
        armature = serializedObject.FindProperty("armature");
        mainObject = serializedObject.FindProperty("mainObject");
        damagePeriod = serializedObject.FindProperty("damagePeriod");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.LabelField("��������� �����");
        EditorGUILayout.PropertyField(initialState);       

        EditorGUILayout.LabelField("������������ �����");
        EditorGUILayout.PropertyField(config);

        period = EditorGUILayout.BeginFoldoutHeaderGroup(period, "������ ��������� �����");
        if (period)
        {
           
            EditorGUILayout.PropertyField(damagePeriod);

        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        objects = EditorGUILayout.BeginFoldoutHeaderGroup(objects, "������� �� �����");
        if (objects)
        {
            EditorGUILayout.PropertyField(hips);
            EditorGUILayout.PropertyField(armature);
            EditorGUILayout.PropertyField(mainObject);
           
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        scripts = EditorGUILayout.BeginFoldoutHeaderGroup(scripts, "�������");
        if (scripts)
        {
            EditorGUILayout.PropertyField(playerHealth);
            EditorGUILayout.PropertyField(speedometr);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        serializedObject.ApplyModifiedProperties();
    }*/

