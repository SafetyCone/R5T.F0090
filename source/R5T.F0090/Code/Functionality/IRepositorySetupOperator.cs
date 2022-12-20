using System;
using System.Threading.Tasks;

using R5T.F0087;
using R5T.T0132;
using R5T.T0153;

using RepositoryContext = R5T.T0153.N005.RepositoryContext;


namespace R5T.F0090
{
    [FunctionalityMarker]
    public partial interface IRepositorySetupOperator : IFunctionalityMarker
    {
        public Func<RepositoryContext, Task> AddSolution_Console<TRepositoryResult>(
            LibraryContext libraryContext,
            TRepositoryResult repositoryResult)
            where TRepositoryResult : IHasSolutionResult<ConsoleSolutionResult>
        {
            return async repositoryContext =>
            {
                var solutionResult = await Instances.SolutionOperations.NewSolution_Console(
                    libraryContext,
                    repositoryContext.IsPrivate,
                    repositoryContext.LocalDirectoryPath);

                repositoryResult.SolutionResult = solutionResult;
            };
        }
    }
}
