using System;


namespace R5T.F0090
{
    public class RepositorySetupOperator : IRepositorySetupOperator
    {
        #region Infrastructure

        public static IRepositorySetupOperator Instance { get; } = new RepositorySetupOperator();


        private RepositorySetupOperator()
        {
        }

        #endregion
    }
}
