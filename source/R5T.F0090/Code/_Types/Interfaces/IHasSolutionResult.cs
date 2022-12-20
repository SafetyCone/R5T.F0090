using System;


namespace R5T.F0090
{
    public interface IHasSolutionResult<TSolutionResult>
    {
        TSolutionResult SolutionResult { get; set; }
    }
}
