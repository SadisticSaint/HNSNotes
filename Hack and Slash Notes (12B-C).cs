//Controller and ControllerManager (12B - 12C)
	//AddButtons
	//Distinguish and Assign Controllers
	//Add Input Strings
	
#region Official Scripts with Notes
#region Controller Script	
public class Controller : MonoBehaviour
{
	private string attackButton; //I don't think I'd know to add this at this point in the project (12B - 1:22)
	public int Index { get; private set; } //How would I know to make this a property? (12B - 1:57)
	public bool attack; //Should this be private?
	public bool IsAssigned { get; set; } 
	
	
	private void Start()
	{
		// Index = 1; -- This was removed at 12C - 3:40
			//Removed because index is already being set in ControllerManager.Awake
		// attackButton = "Attack" + Index; -- This was moved to SetIndex at 12C - 4:05
			//Moved because the index needs to be set for each controller 
	}
	
	private void Update()
	{
		if(!string.IsNullOrEmpty(attackButton)) //Attack is only set when a controller is assigned and gives an error until then
		{	
			attack = Input.GetButton(attackButton); //use this instead of an if statement
		}
	}
	
	internal void SetIndex(index) //what is the "internal" modifier?
	{
		Index = index;
		attackButton = "Attack" + Index;
		gameObject.name = "Controller " + Index;
	}
	
	internal bool AnyButtonDown() //More functionality will be added as more buttons are added
	{
		return attack;
	}
}
#endregion

#region ControllerManager Script
public class ControllerManager : MonoBehaviour
{
	private List<Controller> controllers; //What would be the difference between using a list and an array? (12C - 1:05)
	
	private void Awake()
	{
		controllers = FindObjectsOfType<Controller>().ToList(); //Why not use GetComponent(s)? (12C - 1:30)
		
		int index = 1; //Why not use the index from the Controller script? (12C - 2:12)
		foreach(var controller in controllers)
		{
			controller.SetIndex(index); 
			//How would I know to pass in index? (12C - 2:40)
				//How would I know that the index should be set in the controller script?
			
			index++;
		}
	}
	
	private void Update()
	{
		foreach(var controller in controllers)
		{
			if(controller.IsAssigned == false && controller.AnyButtonDown())
			{
				AssignController(controller);
			}
		}
	}
	
	private void AssignController(controller)
	{
		controller.IsAssigned = true;
	}
}
#endregion
#endregion

#region My Scripts
#region Controller Script
public class Controller : MonoBehaviour
{
	public int Index { get; private set; }
	public bool IsAssigned { get; set; }
	private bool attack;
	private string attackButton;
	
	private void Update()
	{
		if(!string.IsNullOrEmpty(attackButton)) //forgot to pass through attackButton
		{
			attack = Input.GetButton(attackButton)
		}
	}
	
	internal void SetIndex(index)
	{
		Index = index;
		string attackButton = "Attack" + Index; //forgot that this needed to be moved from Start()
		gameObject.name = "Controller " + Index; //forgot this line, but not necessary
	}
	
	internal bool AnyButtonDown()
	{
		return attack;
	}
}
#endregion

#region ControllerManager Script
public class ControllerManager : MonoBehaviour
{
	private List<Controller> controllers;
	private int index; //this can be put in Awake()
	
	private void Awake()
	{
		controllers = FindObjectsOfType<Controller>().ToList();
		index = 1;
		
		foreach(var controller in controllers)
		{
			controller.SetIndex(index);
			index++;
		}
	}
	
	private void Update()
	{
		if(controller.IsAssigned == false && controller.AnyButtonDown())
		{
			AssignController(controller);
		}
	}
	
	private void AssignController(controller)
	{
		controller.IsAssigned = true;
	}
}
#endregion

#endregion