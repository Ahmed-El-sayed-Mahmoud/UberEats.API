namespace UberEats.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}