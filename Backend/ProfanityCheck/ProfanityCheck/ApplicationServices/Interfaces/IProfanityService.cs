namespace ProfanityCheck.ApplicationServices.Interfaces
{
    public interface IProfanityService
    {
        bool IsFileAllowed(string content);
    }
}
