using System;

using R5T.T0142;
using R5T.T0153;

using N003 = R5T.T0153.N003;
using N004 = R5T.T0153.N004;


namespace R5T.F0090
{
    [DataTypeMarker]
    public class RepositoryResult
    {
        public N004.RepositoryContext RepositoryContext { get; set; }
        public N003.SolutionContext SolutionContext { get; set; }
        public ProjectContext ProjectContext { get; set; }
    }
}
