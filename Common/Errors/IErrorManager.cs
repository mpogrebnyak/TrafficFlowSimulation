namespace Common.Errors;

public interface IErrorManager
{
	event ErrorEventHandler ErrorEventHandler;

	void Send(object sender, ErrorEventArgs e);
}

public class ErrorManager : IErrorManager
{
	public event ErrorEventHandler ErrorEventHandler;

	public void Send(object sender, ErrorEventArgs e)
	{
		ErrorEventHandler.Invoke(sender, e);
	}
}