namespace E_Learning_Service.Abstracts
{
    public interface IRoleService
    {
        public Task<string> EditRole(int userId, string name);
        public Task<string> DeleteRole(int userId);
    }
}
