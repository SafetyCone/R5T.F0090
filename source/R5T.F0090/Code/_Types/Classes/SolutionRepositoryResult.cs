using System;

using R5T.F0087;
using R5T.T0142;


namespace R5T.F0090
{
    [DataTypeMarker]
    public class SolutionRepositoryResult<TSolutionResult> :
        IHasLocalRepositoryResult,
        IHasSolutionResult<TSolutionResult>
    {
        public LocalRepositoryResult LocalRepositoryResult { get; set; }
        public TSolutionResult SolutionResult { get; set; }
    }

    [DataTypeMarker]
    public class SolutionRepositoryResult : SolutionRepositoryResult<SolutionResult>
    {
    }
}
