namespace Common.Errors;

public class ParametersException : Exception
{
	public string ParameterSender { get; set; }

	public ParametersException(string parameterSender, string message) : base(message)
	{
		ParameterSender = parameterSender;
	}
}