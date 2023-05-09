using UnityEditor;


public class EditorMenuWeapon : Editor
{

    #region SepializedPropertes
    SerializedProperty key;
    SerializedProperty timeScale;

    SerializedProperty gunZombie;

    SerializedProperty mainFarmUI;
    SerializedProperty ammoText;
    SerializedProperty cyrcleImage;
    
    SerializedProperty saleSlizz;
    SerializedProperty saleAmmo;

    SerializedProperty options;

    bool timeSlowMotion = false;

    bool pulicScript = false;

    bool objectScen = false;

    bool intScene = false;
    #endregion

    private void OnEnable()
    {
        gunZombie = serializedObject.FindProperty("gunZombie");
        options = serializedObject.FindProperty("options");
        key = serializedObject.FindProperty("key");

        timeScale = serializedObject.FindProperty("timeScale");

        mainFarmUI = serializedObject.FindProperty("mainFarmUI");
        ammoText = serializedObject.FindProperty("ammoText");
        cyrcleImage = serializedObject.FindProperty("cyrcleImage");

        saleSlizz = serializedObject.FindProperty("saleSlizz");
        saleAmmo = serializedObject.FindProperty("saleAmmo");

        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        


        EditorGUILayout.PropertyField(key);
        
        timeSlowMotion = EditorGUILayout.BeginFoldoutHeaderGroup(timeSlowMotion, "Время");
        if (timeSlowMotion)
        {
            EditorGUILayout.PropertyField(timeScale);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        objectScen = EditorGUILayout.BeginFoldoutHeaderGroup(objectScen, "Обьекты на сцене");
        if (objectScen)
        {
            EditorGUILayout.PropertyField(mainFarmUI);
            EditorGUILayout.PropertyField(ammoText);
            EditorGUILayout.PropertyField(cyrcleImage);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        intScene = EditorGUILayout.BeginFoldoutHeaderGroup(intScene, "Продажа");
        if (intScene)
        {
            EditorGUILayout.PropertyField(saleAmmo);
            EditorGUILayout.PropertyField(saleSlizz);
            
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        pulicScript = EditorGUILayout.BeginFoldoutHeaderGroup(pulicScript, "Скрипты");
        if (pulicScript)
        {
            EditorGUILayout.PropertyField(gunZombie);
            EditorGUILayout.PropertyField(options);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();

        serializedObject.ApplyModifiedProperties();
    }
}
