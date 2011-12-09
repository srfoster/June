using UnityEngine;
using System.Collections;

public class JuneConfig : MonoBehaviour {
	public static string java_files_path = ""; 
	public static string application_data_path = ""; 

	
	void Start(){
		if(Application.isEditor)
		{
			java_files_path = Application.dataPath + "/MyJune";	
			application_data_path = Application.dataPath;
		} else {
			java_files_path = Application.dataPath + "/../../MyJune";	
			application_data_path = Application.dataPath + "/../..";
		}
	}
}