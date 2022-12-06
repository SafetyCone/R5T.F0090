using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0090
{
	[FunctionalityMarker]
	public partial interface ILocalRepositoryOperator : IFunctionalityMarker
	{
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