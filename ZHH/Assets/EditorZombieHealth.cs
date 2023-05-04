/*using UnityEditor;

[CustomEditor(typeof(Health))]
public class EditorZombieHealth : Editor
{
    /*#region SepializedPropertesZombie
    SerializedProperty maxHealth;
    SerializedProperty gunOptions;
    SerializedProperty slizPrefab;
    SerializedProperty slizTarget;
    SerializedProperty targetGun;
    SerializedProperty hips;
    SerializedProperty Armature;
    SerializedProperty rem;
    SerializedProperty blinkIntensity;
    SerializedProperty blinkDuration;
   
    bool scripts = true;
    bool objects = true;
    bool intBool = true;
    #endregion

    private void OnEnable()
    {
        maxHealth = serializedObject.FindProperty("maxHealth");
        gunOptions = serializedObject.FindProperty("gunOptions");
        slizPrefab = serializedObject.FindProperty("slizPrefab");
        slizTarget = serializedObject.FindProperty("slizTarget");
        targetGun = serializedObject.FindProperty("targetGun");
        hips = serializedObject.FindProperty("hips");
        Armature = serializedObject.FindProperty("Armature");
        rem = serializedObject.FindProperty("rem");
        blinkIntensity = serializedObject.FindProperty("blinkIntensity");
        blinkDuration = serializedObject.FindProperty("blinkDuration");
        
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
       
        EditorGUILayout.PropertyField(maxHealth);
        intBool = EditorGUILayout.BeginFoldoutHeaderGroup(intBool, "Свечение зомби");
        if (intBool)
        {
            EditorGUILayout.PropertyField(blinkIntensity);
            EditorGUILayout.PropertyField(blinkDuration);           
            
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        objects = EditorGUILayout.BeginFoldoutHeaderGroup(objects, "Обьекты на сцене");
        if (objects)
        {
            EditorGUILayout.PropertyField(slizPrefab);
            EditorGUILayout.PropertyField(slizTarget);
            EditorGUILayout.PropertyField(targetGun);
            EditorGUILayout.PropertyField(hips);
            EditorGUILayout.PropertyField(Armature);
            EditorGUILayout.PropertyField(rem);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        scripts = EditorGUILayout.BeginFoldoutHeaderGroup(scripts, "Скрипты");
        if (scripts)
        {
            EditorGUILayout.PropertyField(gunOptions);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        serializedObject.ApplyModifiedProperties();
    }*/

