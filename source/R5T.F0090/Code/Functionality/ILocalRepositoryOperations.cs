using System;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0153;

using N004 = R5T.T0153.N004;


namespace R5T.F0090
{
	[FunctionalityMarker]
	public partial interface ILocalRepositoryOperations : IFunctionalityMarker
	{
        public async Task<RepositoryResult> Create_WebStaticRazorComponents(
            LibraryContext libraryContext,
            N004.RepositoryContext repositoryContext)
        {
            var repositoryResult = new RepositoryResult
            {
                RepositoryContext = repositoryContext,
            };

            async Task Internal()
            {
                // Create the console solution.
                var solutionResult = await Instances.SolutionOperations.Create_WebStaticRazorComponents(
                    libraryContext,
                    repositoryContext.IsPrivate,
                    repositoryContext.LocalDirectoryPath);

                // Return the repository result.
                repositoryResult.SolutionContext = solutionResult.SolutionContext;
                repositoryResult.ProjectContext = solutionResult.ServerProjectContext;
            }

            await this.Create(
                libraryContext,
                repositoryContext,
                Internal);

            return repositoryResult;
        }

        public async Task Create(
            LibraryContext libraryContext,
            N004.RepositoryContext repositoryContext,
            Func<Task> createSolutionAction = default)
        {
            // Create the local repository directory.
            await LocalRepositoryOperator.Instance.CreateNew(
                repositoryContext.LocalDirectoryPath,
                // Setup the local repository directory.
                LocalRepositoryOperator.Instance.GetSetupRepository(repositoryContext.LocalDirectoryPath));

            // Create the solution.
            await F0000.ActionOperator.Instance.Run(createSolutionAction);
        }

        public async Task<ConsoleRepositoryResult> Create_Console(
			LibraryContext libraryContext,
			N004.RepositoryContext repositoryContext)
		{
            var repositoryResult = new ConsoleRepositoryResult
            {
                RepositoryContext = repositoryContext,
            };

            async Task Internal()
            {
                // Create the console solution.
                var solutionResult = await Instances.SolutionOperations.Create_ConsoleSolution(
                    libraryContext,
                    repositoryContext.IsPrivate,
                    repositoryContext.LocalDirectoryPath);

                // Return the repository result.
                repositoryResult.SolutionContext = solutionResult.SolutionContext;
                repositoryResult.ConsoleProjectContext = solutionResult.ConsoleProjectContext;
            }

            await this.Create(
                libraryContext,
                repositoryContext,
                Internal);

            return repositoryResult;
		}
    }
}