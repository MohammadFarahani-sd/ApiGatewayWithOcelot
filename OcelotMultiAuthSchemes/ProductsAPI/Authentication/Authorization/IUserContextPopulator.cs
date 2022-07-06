namespace ProductsAPI.Authentication.Authorization;

public interface IUserContextPopulator
{
    void Populate(ClaimSet claimSet, string? language);
}