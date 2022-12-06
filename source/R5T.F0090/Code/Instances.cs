using System;


namespace R5T.F0090
{
    public static class Instances
    {
        public static F0057.IRepositoryPathsOperator RepositoryPathsOperator => F0057.RepositoryPathsOperator.Instance;
        public static F0042.F002.IRepositoryFilesOperator RepositoryFilesOperator => F0042.F002.RepositoryFilesOperator.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0087.ISolutionOperations SolutionOperations => F0087.SolutionOperations.Instance;
    }
}