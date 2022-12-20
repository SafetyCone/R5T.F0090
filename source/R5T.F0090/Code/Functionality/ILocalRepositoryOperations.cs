using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.F0087;
using R5T.T0132;
using R5T.T0153;

using RepositoryContext = R5T.T0153.N005.RepositoryContext;


namespace R5T.F0090
{
	[FunctionalityMarker]
	public partial interface ILocalRepositoryOperations : IFunctionalityMarker
	{
        public async Task<SolutionRepositoryResult<WebStaticRazorComponentsSolutionResult>> Create_WebStaticRazorComponents(
            LibraryContext libraryContext,
            RepositoryContext repositoryContext)
        {
            var repositoryResult = new SolutionRepositoryResult<WebStaticRazorComponentsSolutionResult>();

            await RepositoryOperator.Instance.CreateRepository(
                repositoryContext,
                RepositorySetupOperations.Instance.SetupRepository_WebStaticRazorComponents(
                    libraryContext,
                    repositoryResult));

            return repositoryResult;
        }

        public async Task<ConsoleRepositoryResult> New_Console(
			LibraryContext libraryContext,
            string ownerName,
            bool isPrivate,
            ILogger logger)
		{
            var repositoryResult = new ConsoleRepositoryResult();

            await RepositoryOperator.Instance.CreateRepository(
                libraryContext,
                ownerName,
                isPrivate,
                RepositorySetupOperations.Instance.SetupRepository_Console(
                    libraryContext,
                    repositoryResult));

            return repositoryResult;
		}

        public async Task<ConsoleRepositoryResult> New_Console(
           LibraryContext libraryContext,
           RepositoryContext repositoryContext,
           ILogger logger)
        {
            var repositoryResult = new ConsoleRepositoryResult();

            await RepositoryOperator.Instance.CreateRepository(
                repositoryContext,
                RepositorySetupOperations.Instance.SetupRepository_Console(
                    libraryContext,
                    repositoryResult));

            return repositoryResult;
        }
    }
}