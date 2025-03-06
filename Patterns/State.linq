<Query Kind="Program" />

void Main()
{
	var workflow = new Workflow();
	workflow.Next();
	workflow.Next();
	workflow.Next();
	workflow.Next();
}

//context
class Workflow
{
	private WorkflowState state;

	public Workflow()
	{
		state = new VirusScanCompleted(this);
	}

	public void Next()
	{
		state.Next();
	}

	public void ChangeState(WorkflowState state)
	{
		this.state = state;
	}
}

//state
abstract class WorkflowState
{
	protected Workflow workflow;
	public WorkflowState(Workflow workflow)
	{
		this.workflow = workflow;
	}
	
	public abstract void Next();
}

class VirusScanCompleted : WorkflowState
{
	public VirusScanCompleted(Workflow workflow): base(workflow)
	{
		
	}
	
	public override void Next()
	{
		Console.WriteLine("Virus scan completed!");

		workflow.ChangeState(new TranscodeScanCompleted(workflow));
	}
}

class TranscodeScanCompleted : WorkflowState
{
	public TranscodeScanCompleted(Workflow workflow) : base(workflow)
	{

	}

	public override void Next()
	{
		Console.WriteLine("Transcode completed!");

		workflow.ChangeState(new WorkflowCompleted(workflow));		
	}
}

class WorkflowCompleted : WorkflowState
{
	public WorkflowCompleted(Workflow workflow) : base(workflow)
	{

	}

	public override void Next()
	{
		Console.WriteLine("Workflow completed completed!");		
	}
}