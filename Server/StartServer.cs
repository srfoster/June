/* See the copyright information at https://github.com/srfoster/June/blob/master/COPYRIGHT */

/**
* The June Project.
*
* Depends on "Shell.js"  // Must import Shell package 
* StartServer.js + Prefab with StartServer attached
*   -- Put this in your scene
* JavaDeligate.js
*   -- Lets you "attach" the Java to an entity.  Will run Java on startup.
*   -- Calls into "June.js"
* June.js contains simple API for running java programs "on" entity objects.
*   -- Calls correct java program with correct command line objects.
* Java libraries for talking to the unity server.
*
* A working example:
*	Scene with working server.
*	Object with attached Java
*	Java that controls object.


  Make sure it works when the game is deployed. 
  
  
  Should we worry about making it work on windows too?
  
  
  Add some Documenation
  
  Put it on GitHub
*
**/


using System;
using UnityEngine;



public class StartServer : MonoBehaviour
{
	public Server server;
	
	public CallResponseQueue queue;

	void Start () {
		Debug.Log("Listening for clients...");
	
		queue = new CallResponseQueue();
		server = new Server(queue);
	}
	
	void Update () {
		while(queue.notEmpty())
		{
			CallResponse call = queue.remove();
			
			try{
				Debug.Log("Trying to eval '" + call.getCall() + "'");
				
				if(call.getCall().Equals("\n"))
				{
					call.setResponse("");
				} else{ 
					string response = Eval.eval(call.getCall()).ToString();
					call.setResponse(response);
				}
				call.respond();
			} catch(Exception e) {
				call.setResponse("Error: " + e.ToString().Replace("\n",""));
			}
			
		}
	}
	
}
