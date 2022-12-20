using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.F0087;
using R5T.T0132;
using R5T.T0153;

using RepositoryContext = R5T.T0153.N005.RepositoryContext;


namespace R5T.F0090
{
    [FunctionalityMarker]
    public partial interface IRepositorySetupOperations : IFunctionalityMarker
    {
        public IEnumerable<Func<RepositoryContext, Task>> SetupRepository_WebStaticRazorComponents<TRepositoryResult>(
            LibraryContext libraryContext,
            TRepositoryResult repositoryResult)
            where TRepositoryResult : IHasSolutionResult<WebStaticRazorComponentsSolutionResult>
        {
            var output = RepositorySetupOperations.Instance.SetupRepository_WithStandardActions(
                async repositoryContext =>
                {
                    var solutionResult = await Instances.SolutionOperations.NewSolution_WebStaticRazorComponents(
                        libraryContext,
                        repositoryContext.IsPrivate,
                        repositoryContext.LocalDirectoryPath);

                    repositoryResult.SolutionResult = solutionResult;
                });

            return output;
        }

        public IEnumerable<Func<RepositoryContext, Task>> SetupRepository_Console<TRepositoryResult>(
            LibraryContext libraryContext,
            TRepositoryResult repositoryResult)
            where TRepositoryResult : IHasSolutionResult<ConsoleSolutionResult>
        {
            var output = RepositorySetupOperations.Instance.SetupRepository_WithStandardActions(
                RepositorySetupOperator.Instance.AddSolution_Console(
                    libraryContext,
                    repositoryResult));

            return output;
        }

        public IEnumerable<Func<RepositoryContext, Task>> SetupRepository_GitIgnoreOnly(
            LibraryContext libraryContext)
        {
            var output = RepositorySetupOperations.Instance.SetupRepository_WithGitIgnoreOnly();

            return output;
        }

        public Task SetGitIgnoreFile(RepositoryContext repositoryContext)
        {
            F0042.F002.RepositoryFilesOperator.Instance.Set_GitIgnoreFile(
                repositoryContext.LocalDirectoryPath);

            return Task.CompletedTask;
        }

        public Task SetSourceDirectory(RepositoryContext repositoryContext)
        {
            RepositoryOperator.Instance.SetSourceDirectoryPath(
                repositoryContext.LocalDirectoryPath);

            return Task.CompletedTask;
        }

        public IEnumerable<Func<RepositoryContext, Task>> SetupRepository_WithGitIgnoreOnly(
            IEnumerable<Func<RepositoryContext, Task>> setupRepositoryActions)
        {
            var output = new[]
            {
                this.SetGitIgnoreFile,
            }
            .Append(setupRepositoryActions)
            // Nothing to append at the end, but there might be in the future.
            ;

            return output;
        }

        /// <summary>
        /// The standard operations are:
        /// 1. Before, set the gitignore file.
        /// 2. Before, set the source directory.
        /// </summary>
        public IEnumerable<Func<RepositoryContext, Task>> SetupRepository_WithStandardActions(
            IEnumerable<Func<RepositoryContext, Task>> setupRepositoryActions)
        {
            var output = new[]
            {
                this.SetGitIgnoreFile,
                this.SetSourceDirectory,
            }
            .Append(setupRepositoryActions)
            // Nothing to append at the end, but there might be in the future.
            ;

            return output;
        }

        /// <inheritdoc cref="SetupRepository_WithStandardActions(IEnumerable{Func{RepositoryContext, Task}})"/>
        public IEnumerable<Func<RepositoryContext, Task>> SetupRepository_WithStandardActions(
            params Func<RepositoryContext, Task>[] setupRepositoryActions)
        {
            return this.SetupRepository_WithStandardActions(
                setupRepositoryActions.AsEnumerable());
        }

        public IEnumerable<Func<RepositoryContext, Task>> SetupRepository_WithGitIgnoreOnly(
            params Func<RepositoryContext, Task>[] setupRepositoryActions)
        {
            return this.SetupRepository_WithGitIgnoreOnly(
                setupRepositoryActions.AsEnumerable());
        }
    }
}
