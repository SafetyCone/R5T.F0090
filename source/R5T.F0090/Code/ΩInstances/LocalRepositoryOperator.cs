using System;


namespace R5T.F0090
{
	public class LocalRepositoryOperator : ILocalRepositoryOperator
	{
		#region Infrastructure

	    public static ILocalRepositoryOperator Instance { get; } = new LocalRepositoryOperator();

	    private LocalRepositoryOperator()
	    {
        }

	    #endregion
	}
}