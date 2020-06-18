using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class InventorySaver : MonoBehaviour
{
    [SerializeField] Inventory myInventory;

    public void ResetScriptables()
    {
        int i = 0;
       
        while (File.Exists(Application.persistentDataPath +
            string.Format("/{0}.inv", i)))
        {
            File.Delete(Application.persistentDataPath +
            string.Format("/{0}.inv", i));

            i++;
        }

        
    }

    public void SaveScriptables()
    {
        ResetScriptables();

        for (int i = 0; i < myInventory.myInventory.Count; i++)
        {
            FileStream file = File.Create(Application.persistentDataPath +
                string.Format("/{0}.dat", i));

            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(myInventory.myInventory[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        int i = 0;
        while(File.Exists(Application.persistentDataPath + 
            string.Format("/{0}.inv", i)))
        {
            var temp = ScriptableObject.CreateInstance<InventoryItem>();

            FileStream file = File.Open(Application.persistentDataPath +
            string.Format("/{0}.inv", i), FileMode.Open);

            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file),
            myInventory.myInventory[i]);

            file.Close();
            myInventory.myInventory.Add(temp);
            i++;
        }
    }


    private void OnEnable()
    {
        myInventory.myInventory.Clear();
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }
}
