using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using R5T.F0000;
using R5T.F0087;
using R5T.F0089;
using R5T.T0132;
using R5T.T0153;

using RepositoryContext = R5T.T0153.N005.RepositoryContext;


namespace R5T.F0090
{
	[FunctionalityMarker]
	public partial interface IRepositoryOperator : IFunctionalityMarker
	{
        public async Task CreateRepository(
            RepositoryContext repositoryContext,
            IEnumerable<Func<RepositoryContext, Task>> repositoryActions)
        {
            await ActionOperator.Instance.Run(
                repositoryContext,
                repositoryActions);
        }

        public Task CreateRepository(
           LibraryContext libraryContext,
           string ownerName,
           bool isPrivate,
           IEnumerable<Func<RepositoryContext, Task>> repositoryActions)
        {
            var repositoryContext = RepositoryContextOperations.Instance.GetRepositoryContext(
                ownerName,
                libraryContext,
                isPrivate);

            return this.CreateRepository(
                repositoryContext,
                repositoryActions);
        }

        public async Task CreateNew(
			string repositoryDirectoryPath,
			Func<Task> setupRepositoryAction = default)
		{
			Instances.FileSystemOperator.CreateDirectory(
				repositoryDirectoryPath);

			await F0000.ActionOperator.Instance.Run(setupRepositoryAction);
		}

		public Func<Task> GetSetupRepository(string repositoryDirectoryPath)
		{
			return () => this.SetupRepository(repositoryDirectoryPath);
		}

        public Task SetupRepository(string repositoryDirectoryPath)
        {
            Instances.RepositoryFilesOperator.Set_GitIgnoreFile(repositoryDirectoryPath);

			this.SetSourceDirectoryPath(repositoryDirectoryPath);

            return Task.CompletedTask;
        }

		public void SetSourceDirectoryPath(string repositoryDirectoryPath)
		{
            var repositorySourceDirectoryPath = Instances.RepositoryPathsOperator.GetSourceDirectoryPath(repositoryDirectoryPath);
            Instances.FileSystemOperator.CreateDirectory(repositorySourceDirectoryPath);
        }
    }
}